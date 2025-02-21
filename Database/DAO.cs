using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CarServiceDB.Database;

public class Dao
{
    private static Dao? _instance;
    private readonly SqlConnection _masterConnection;

    private readonly string _databaseName;
    private readonly string _createScriptPath;

    private string? _connectionString;

    private Dao()
    {
        _createScriptPath = "AppFiles\\create.sql";

        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("AppFiles\\appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        _connectionString = configuration.GetConnectionString("DefaultConnection");

        var builder = new SqlConnectionStringBuilder(_connectionString);
        _databaseName = builder.InitialCatalog;

        var masterConnectionString = _connectionString;
        masterConnectionString = masterConnectionString?.Replace($"Database={_databaseName};", "Database=master;");

        _masterConnection = new SqlConnection(masterConnectionString);
        _masterConnection.Open();

        if (!DatabaseExists()) CreateDatabase();
        _masterConnection.Close();

        //_connectionString = _connectionString?.Replace("Database=master;", $"Database={_databaseName};");

        Connection = new SqlConnection(_connectionString);
        if (!TablesExist()) ExecuteSqlScript();
    }

    public SqlConnection Connection { get; }

    public string? ConnectionString
    {
        get => _connectionString;
        set => _connectionString = value ?? throw new ArgumentNullException(nameof(value));
    }

    /// <summary>
    /// Checks that the connection is open. If not the connection will open
    /// </summary>
    public void EnsureConnectionOpen()
    {
        if (Connection.State == ConnectionState.Open) return;
        Connection.ConnectionString = ConnectionString!;
        Connection.Open();
    }

    public static Dao GetInstance()
    {
        return _instance ??= new Dao();
    }

    /// <summary>
    /// Checks if database exist
    /// </summary>
    /// <returns> returns true if database exist</returns>
    private bool DatabaseExists()
    {
        var query = $"SELECT COUNT(*) FROM sys.databases WHERE name = '{_databaseName}'";
        using var command = new SqlCommand(query, _masterConnection);
        var dbCount = (int)command.ExecuteScalar();
        return dbCount > 0;
    }

    /// <summary>
    /// Creates a database
    /// </summary>
    private void CreateDatabase()
    {
        var query = $"CREATE DATABASE {_databaseName}";
        using var command = new SqlCommand(query, _masterConnection);
        command.ExecuteNonQuery();
        Console.WriteLine("Databáze byla vytvořena.");
    }

    /// <summary>
    /// Checks if tables exist
    /// </summary>
    /// <returns>returns true if tables exist</returns>
    private bool TablesExist()
    {
        Connection.Open();
        const string query = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";
        using var command = new SqlCommand(query, Connection);
        var tableCount = (int)command.ExecuteScalar();
        Connection.Close();
        return tableCount > 0;
    }

    /// <summary>
    /// Loads sql script into database to create
    /// </summary>
    private void ExecuteSqlScript()
    {
        if (!File.Exists(_createScriptPath))
        {
            Console.WriteLine("Soubor create.sql nebyl nalezen.");
            return;
        }

        var script = File.ReadAllText(_createScriptPath);
        ExecuteNonQuery(script);
    }

    private void ExecuteNonQuery(string sql)
    {
        using var command = new SqlCommand(sql, Connection);
        ExecuteNonQuery(command);
    }

    private void ExecuteNonQuery(SqlCommand command)
    {
        EnsureConnectionOpen();
        command.ExecuteNonQuery();
        Connection.Close();
    }


    #region Add methods

    public void AddCustomers(string name, string surname, string phoneNumber, string email, float discount, bool isVip,
        string registrationDate, SqlConnection connection)
    {
        const string query =
            "INSERT INTO Customers (Name, Surname, PhoneNumber, Email, Discount, IsVIP, RegistrationDate) " +
            "VALUES (@Name, @Surname, @PhoneNumber, @Email, @Discount, @IsVIP, @RegistrationDate)";

        using var command = new SqlCommand(query, connection);
        command.Parameters.Add(new SqlParameter("@Name", name));
        command.Parameters.Add(new SqlParameter("@Surname", surname));
        command.Parameters.Add(new SqlParameter("@PhoneNumber", phoneNumber));
        command.Parameters.Add(new SqlParameter("@Email", email));
        command.Parameters.Add(new SqlParameter("@Discount", discount));
        command.Parameters.Add(new SqlParameter("@IsVIP", isVip ? 1 : 0));
        command.Parameters.Add(new SqlParameter("@RegistrationDate", DateTime.Parse(registrationDate)));
        ExecuteNonQuery(command);
    }

    public void AddVehicles(int customerId, string licensePlate, string brand, string model, string color, int year,
        float mileage, string lastService, SqlConnection connection)
    {
        const string query =
            "INSERT INTO Vehicles (Customers_id, LicensePlate, Brand, Model, Color, Year, Mileage, LastService) " +
            "VALUES (@Customers_id, @LicensePlate, @Brand, @Model, @Color, @Year, @Mileage, @LastService)";
        using var command = new SqlCommand(query, connection);
        command.Parameters.Add(new SqlParameter("@Customers_id", customerId));
        command.Parameters.Add(new SqlParameter("@LicensePlate", licensePlate));
        command.Parameters.Add(new SqlParameter("@Brand", brand));
        command.Parameters.Add(new SqlParameter("@Model", model));
        command.Parameters.Add(new SqlParameter("@Color", color));
        command.Parameters.Add(new SqlParameter("@Year", year));
        command.Parameters.Add(new SqlParameter("@Mileage", mileage));
        command.Parameters.Add(new SqlParameter("@LastService", DateTime.Parse(lastService)));
        ExecuteNonQuery(command);
    }

    public void AddServices(string serviceName, double price, float estimatedTime, bool isWarranty,
        SqlConnection connection)
    {
        const string query = "INSERT INTO Services (ServiceName, Price, EstimatedTime, IsWarranty) " +
                             "VALUES (@ServiceName, @Price, @EstimatedTime, @IsWarranty)";
        using var command = new SqlCommand(query, connection);
        command.Parameters.Add(new SqlParameter("@ServiceName", serviceName));
        command.Parameters.Add(new SqlParameter("@Price", price));
        command.Parameters.Add(new SqlParameter("@EstimatedTime", estimatedTime));
        command.Parameters.Add(new SqlParameter("@IsWarranty", isWarranty ? 1 : 0));
        ExecuteNonQuery(command);
    }

    public void AddRepairs(int vehicleId, int serviceId, string repairDate, double totalCost, bool isCompleted,
        SqlConnection connection)
    {
        const string query = "INSERT INTO Repairs (Vehicles_id, Service_id, RepairDate, TotalCost, IsCompleted) " +
                             "VALUES (@Vehicles_id, @Service_id, @RepairDate, @TotalCost, @IsCompleted)";
        using var command = new SqlCommand(query, connection);
        command.Parameters.Add(new SqlParameter("@Vehicles_id", vehicleId));
        command.Parameters.Add(new SqlParameter("@Service_id", serviceId));
        command.Parameters.Add(new SqlParameter("@RepairDate", DateTime.Parse((repairDate))));
        command.Parameters.Add(new SqlParameter("@TotalCost", totalCost));
        command.Parameters.Add(new SqlParameter("@IsCompleted", isCompleted ? 1 : 0));
        ExecuteNonQuery(command);
    }

    public void AddMechanics(string name, string surname, string specialization, float hourlyRate,
        string employmentDate, bool isActive, SqlConnection connection)
    {
        const string query =
            "INSERT INTO Mechanics (Name, Surname, Specialization, HourlyRate, EmploymentDate, IsActive) " +
            "VALUES (@Name, @Surname, @Specialization, @HourlyRate, @EmploymentDate, @IsActive)";
        using var command = new SqlCommand(query, connection);
        command.Parameters.Add(new SqlParameter("@Name", name));
        command.Parameters.Add(new SqlParameter("@Surname", surname));
        command.Parameters.Add(new SqlParameter("@Specialization", specialization));
        command.Parameters.Add(new SqlParameter("@HourlyRate", hourlyRate));
        command.Parameters.Add(new SqlParameter("@EmploymentDate", DateTime.Parse(employmentDate)));
        command.Parameters.Add(new SqlParameter("@IsActive", isActive ? 1 : 0));
        ExecuteNonQuery(command);
    }

    public void AddRepairMechanics(int repairId, int mechanicId, float workHours, SqlConnection connection)
    {
        const string query = "INSERT INTO RepairMechanics (Repairs_id, Mechanics_id, WorkHours) " +
                             "VALUES (@Repairs_id, @Mechanics_id, @WorkHours)";
        using var command = new SqlCommand(query, connection);
        command.Parameters.Add(new SqlParameter("@Repairs_id", repairId));
        command.Parameters.Add(new SqlParameter("@Mechanics_id", mechanicId));
        command.Parameters.Add(new SqlParameter("@WorkHours", workHours));
        ExecuteNonQuery(command);
    }

    #endregion

    #region Remove methods

    public void RemoveCustomer(int customerId, SqlConnection connection)
    {
        const string query = "DELETE FROM Customers WHERE Customers_id = @Id";
        using var command = new SqlCommand(query, connection);
        command.Parameters.Add(new SqlParameter("@Id", customerId));
        ExecuteNonQuery(command);
    }

    public void RemoveVehicle(int vehicleId, SqlConnection connection)
    {
        const string query = "DELETE FROM Vehicles WHERE Vehicles_id = @Id";
        using var command = new SqlCommand(query, connection);
        command.Parameters.Add(new SqlParameter("@Id", vehicleId));
        ExecuteNonQuery(command);
    }

    public void RemoveService(int serviceId, SqlConnection connection)
    {
        const string query = "DELETE FROM Services WHERE Service_id = @Id";
        using var command = new SqlCommand(query, connection);
        command.Parameters.Add(new SqlParameter("@Id", serviceId));
        ExecuteNonQuery(command);
    }

    public void RemoveRepair(int serviceId, SqlConnection connection)
    {
        const string query = "DELETE FROM Repairs WHERE Service_id = @Service_id";
        using var command = new SqlCommand(query, connection);
        command.Parameters.Add(new SqlParameter("@Service_id", serviceId));
        ExecuteNonQuery(command);
    }

    public void RemoveMechanic(int mechanicId, SqlConnection connection)
    {
        const string query = "DELETE FROM Mechanics WHERE Mechanics_id = @Id";
        using var command = new SqlCommand(query, connection);
        command.Parameters.Add(new SqlParameter("@Id", mechanicId));
        ExecuteNonQuery(command);
    }

    #endregion

    #region Update methods

    public void UpdateCustomer(string data, int customerId, bool updateName, bool updateSurname, bool updatePhoneNumber,
        bool updateEmail, bool updateDiscount, bool updateIsVip, bool updateRegistrationDate, SqlConnection connection)
    {
        var queryBuilder = new StringBuilder("UPDATE Customers SET");
        var parameters = new List<SqlParameter>();

        if (updateName)
        {
            queryBuilder.Append(" Name = @Name, ");
            parameters.Add(new SqlParameter("@Name", data));
        }

        if (updateSurname)
        {
            queryBuilder.Append(" Surname = @Surname, ");
            parameters.Add(new SqlParameter("@Surname", data));
        }

        if (updatePhoneNumber)
        {
            queryBuilder.Append(" PhoneNumber = @PhoneNumber, ");
            parameters.Add(new SqlParameter("@PhoneNumber", data));
        }

        if (updateEmail)
        {
            queryBuilder.Append(" Email = @Email, ");
            parameters.Add(new SqlParameter("@Email", data));
        }

        if (updateDiscount)
        {
            queryBuilder.Append(" Discount = @Discount, ");
            parameters.Add(new SqlParameter("@Discount", float.Parse(data)));
        }

        if (updateIsVip)
        {
            queryBuilder.Append(" IsVIP = @IsVIP, ");
            parameters.Add(new SqlParameter("@IsVIP", bool.Parse(data) ? 1 : 0));
        }

        if (updateRegistrationDate)
        {
            queryBuilder.Append(" RegistrationDate = @RegistrationDate, ");
            parameters.Add(new SqlParameter("@RegistrationDate", DateTime.Parse(data)));
        }

        if (parameters.Count == 0)
        {
            throw new ArgumentException("No update fields specified");
        }
        
        queryBuilder.Length -= 2;
        queryBuilder.Append(" WHERE Customers_id = @Id");
        parameters.Add(new SqlParameter("@Id", customerId));

        using var command = new SqlCommand(queryBuilder.ToString(), connection);
        command.Parameters.AddRange(parameters.ToArray());
        ExecuteNonQuery(command);
    }


    public void UpdateVehicle(string data, int vehicleId, bool updateLicensePlate, bool updateBrand, bool updateModel,
        bool updateColor, bool updateYear, bool updateMileage, bool updateLastService, SqlConnection connection)
    {
        var queryBuilder = new StringBuilder("UPDATE Vehicles SET");
        var parameters = new List<SqlParameter>();

        if (updateLicensePlate)
        {
            queryBuilder.Append(" LicensePlate = @LicensePlate, ");
            parameters.Add(new SqlParameter("@LicensePlate", data));
        }

        if (updateBrand)
        {
            queryBuilder.Append(" Brand = @Brand, ");
            parameters.Add(new SqlParameter("@Brand", data));
        }

        if (updateModel)
        {
            queryBuilder.Append(" Model = @Model, ");
            parameters.Add(new SqlParameter("@Model", data));
        }

        if (updateColor)
        {
            queryBuilder.Append(" Color = @Color, ");
            parameters.Add(new SqlParameter("@Color", data));
        }

        if (updateYear)
        {
            queryBuilder.Append(" Year = @Year, ");
            parameters.Add(new SqlParameter("@Year", int.Parse(data)));
        }

        if (updateMileage)
        {
            queryBuilder.Append(" Mileage = @Mileage, ");
            parameters.Add(new SqlParameter("@Mileage", float.Parse(data)));
        }

        if (updateLastService)
        {
            queryBuilder.Append(" LastService = @LastService, ");
            parameters.Add(new SqlParameter("@LastService", data));
        }

        if (parameters.Count == 0)
        {
            throw new ArgumentException("No update fields specified");
        }
        
        queryBuilder.Length -= 2;
        queryBuilder.Append(" WHERE Vehicles_id = @Id");
        parameters.Add(new SqlParameter("@Id", vehicleId));

        using var command = new SqlCommand(queryBuilder.ToString(), connection);
        command.Parameters.AddRange(parameters.ToArray());
        ExecuteNonQuery(command);
    }

    public void UpdateService(string data, int serviceId, bool updateServiceName, bool updatePrice, 
        bool updateEstimatedTime, bool updateIsWarranty, SqlConnection connection)
    {
        var queryBuilder = new StringBuilder("UPDATE Services SET");
        var parameters = new List<SqlParameter>();

        if (updateServiceName)
        {
            queryBuilder.Append(" ServiceName = @ServiceName, ");
            parameters.Add(new SqlParameter("@ServiceName", data));
        }
        if (updatePrice)
        {
            queryBuilder.Append(" Price = @Price, ");
            parameters.Add(new SqlParameter("@Price", double.Parse(data)));
        }
        if (updateEstimatedTime)
        {
            queryBuilder.Append(" EstimatedTime = @EstimatedTime, ");
            parameters.Add(new SqlParameter("@EstimatedTime", float.Parse(data)));
        }
        if (updateIsWarranty)
        {
            queryBuilder.Append(" IsWarranty = @IsWarranty, ");
            parameters.Add(new SqlParameter("@IsWarranty", bool.Parse(data) ? 1 : 0));
        }

        if (parameters.Count == 0)
        {
            throw new ArgumentException("No update fields specified");
        }
        
        queryBuilder.Length -= 2;
        queryBuilder.Append(" WHERE Service_id = @Id");
        parameters.Add(new SqlParameter("@Id", serviceId));

        using var command = new SqlCommand(queryBuilder.ToString(), connection);
        command.Parameters.AddRange(parameters.ToArray());
        ExecuteNonQuery(command);
    }


    public void UpdateRepair(string data,int repairId, bool updateVehicleId, bool updateServiceId, 
        bool updateRepairDate, bool updateTotalCost, bool updateIsCompleted, SqlConnection connection)
    {
        var queryBuilder = new StringBuilder("UPDATE Repairs SET");
        var parameters = new List<SqlParameter>();

        if (updateVehicleId)
        {
            queryBuilder.Append(" Vehicles_id = @Vehicles_id, ");
            parameters.Add(new SqlParameter("@Vehicles_id", int.Parse(data)));
        }
        if (updateServiceId)
        {
            queryBuilder.Append(" Services_id = @Services_id, ");
            parameters.Add(new SqlParameter("@Services_id", int.Parse(data)));
        }
        if (updateRepairDate)
        {
            queryBuilder.Append(" RepairDate = @RepairDate, ");
            parameters.Add(new SqlParameter("@RepairDate", data));
        }
        if (updateTotalCost)
        {
            queryBuilder.Append(" TotalCost = @TotalCost, ");
            parameters.Add(new SqlParameter("@TotalCost", double.Parse(data)));
        }
        if (updateIsCompleted)
        {
            queryBuilder.Append(" IsCompleted = @IsCompleted, ");
            parameters.Add(new SqlParameter("@IsCompleted", bool.Parse(data) ? 1 : 0));
        }

        if (parameters.Count == 0)
        {
            throw new ArgumentException("No update fields specified");
        }
        
        queryBuilder.Length -= 2;
        queryBuilder.Append(" WHERE Repair_id = @Id");
        parameters.Add(new SqlParameter("@Id", repairId));

        using var command = new SqlCommand(queryBuilder.ToString(), connection);
        command.Parameters.AddRange(parameters.ToArray());
        ExecuteNonQuery(command);
    }


    public void UpdateMechanic(string data, int mechanicId, bool updateName, bool updateSurname, bool updateSpecialization, 
        bool updateHourlyRate, bool updateEmploymentDate, bool updateIsActive, SqlConnection connection)
    {
        var queryBuilder = new StringBuilder("UPDATE Mechanics SET");
        var parameters = new List<SqlParameter>();

        if (updateName)
        {
            queryBuilder.Append(" Name = @Name, ");
            parameters.Add(new SqlParameter("@Name", data));
        }
        if (updateSurname)
        {
            queryBuilder.Append(" Surname = @Surname, ");
            parameters.Add(new SqlParameter("@Surname", data));
        }
        if (updateSpecialization)
        {
            queryBuilder.Append(" Specialization = @Specialization, ");
            parameters.Add(new SqlParameter("@Specialization", data));
        }
        if (updateHourlyRate)
        {
            queryBuilder.Append(" HourlyRate = @HourlyRate, ");
            parameters.Add(new SqlParameter("@HourlyRate", float.Parse(data)));
        }
        if (updateEmploymentDate)
        {
            queryBuilder.Append(" EmploymentDate = @EmploymentDate, ");
            parameters.Add(new SqlParameter("@EmploymentDate", data));
        }
        if (updateIsActive)
        {
            queryBuilder.Append(" IsActive = @IsActive, ");
            parameters.Add(new SqlParameter("@IsActive", bool.Parse(data) ? 1 : 0));
        }

        if (parameters.Count == 0)
        {
            throw new ArgumentException("No update fields specified");
        }
        
        queryBuilder.Length -= 2;
        queryBuilder.Append(" WHERE Mechanic_id = @Id");
        parameters.Add(new SqlParameter("@Id", mechanicId));

        using var command = new SqlCommand(queryBuilder.ToString(), connection);
        command.Parameters.AddRange(parameters.ToArray());
        ExecuteNonQuery(command);
    }


    #endregion
}