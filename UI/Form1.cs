using System.Data;
using System.Xml.Serialization;
using CarServiceDB.Classes;
using CarServiceDB.Database;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace CarServiceDB.UI;

public partial class Form1 : Form
{
    private readonly Dao _dao;
    private readonly SqlConnection _connection;

    private List<Customer> _customers = [];
    private List<Vehicle> _vehicles = [];
    private List<Service> _services = [];
    private List<Repair> _repairs = [];
    private List<Mechanic> _mechanics = [];

    public Form1()
    {
        InitializeComponent();
        _dao = Dao.GetInstance();
        _connection = _dao.Connection;
        Console.WriteLine(_connection.ConnectionString);
        dataFrom.SelectedIndex = 0;
        LoadData();
    }


    private void InsertData_Click(object sender, EventArgs e)
    {
        var newForm = new InsertData(_dao);
        newForm.ShowDialog();
    }

    private void EditData_Click(object sender, EventArgs e)
    {
        var newForm = new UpdateData(_dao);
        newForm.ShowDialog();
    }

    private void DeleteData_Click(object sender, EventArgs e)
    {
        var newForm = new DeleteData(_dao);
        newForm.ShowDialog();
    }
    
    private void InsertMechanics_Click(object sender, EventArgs e)
    {
        var newForm = new InsertMechanics(_dao);
        newForm.ShowDialog();
    }
    
    private void AddRtoM_Click(object sender, EventArgs e)
    {
        var newForm = new AddRepairsToMechanics(_dao);
        newForm.ShowDialog();
    }
    

    /// <summary>
    /// Changes the data source for the table view
    /// </summary>
    private void LoadData()
    {
        if (_connection.State != ConnectionState.Open)
        {
            _connection.ConnectionString = _dao.ConnectionString!;
            _connection.Open();
        }

        switch (dataFrom.Text)
        {
            case "Customers":
                _customers = LoadCustomers(_connection);
                dataView.DataSource = _customers;
                break;
            case "Vehicles":
                _vehicles = LoadVehicles(_connection);
                dataView.DataSource = _vehicles;
                break;
            case "Services":
                _services = LoadServices(_connection);
                dataView.DataSource = _services;
                break;
            case "Repairs":
                _repairs = LoadRepairs(_connection);
                dataView.DataSource = _repairs;
                break;
            case "Mechanics":
                _mechanics = LoadMechanics(_connection);
                dataView.DataSource = _mechanics;
                break;
        }

        if (_connection.State == ConnectionState.Open)
            _connection.Close();
    }

    private void dataFrom_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadData();
    }

    /// <summary>
    /// Reads data into the List from the database
    /// </summary>
    /// <param name="connection">connection to database</param>
    /// <returns>List of Customers</returns>
    private static List<Customer> LoadCustomers(SqlConnection connection)
    {
        var list = new List<Customer>();
        const string query = "SELECT * FROM Customers";
        using var command = new SqlCommand(query, connection);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new Customer
            {
                CustomersId = reader.GetInt32(0),
                CustomersName = reader.GetString(1),
                CustomersSurname = reader.GetString(2),
                CustomersPhoneNumber = reader.GetString(3),
                CustomersEmail = reader.GetString(4),
                CustomersDiscount = reader.GetDouble(5),
                CustomersIsVip = reader.GetBoolean(6) ? "Yes" : "No",
                CustomersRegistrationDate = reader.GetDateTime(7)
            });
        }


        return list;
    }

    /// <summary>
    /// Reads data into the List from the database
    /// </summary>
    /// <param name="connection">connection to database</param>
    /// <returns>List of Vehicles</returns>
    private static List<Vehicle> LoadVehicles(SqlConnection connection)
    {
        var list = new List<Vehicle>();
        const string query = "SELECT * FROM Vehicles";
        using var command = new SqlCommand(query, connection);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new Vehicle
            {
                VehiclesId = reader.GetInt32(0),
                VCustomersId = reader.GetInt32(1),
                VehiclesLicensePlate = reader.GetString(2),
                VehiclesBrand = reader.GetString(3),
                VehiclesModel = reader.GetString(4),
                VehiclesColor = reader.GetString(5),
                VehiclesYear = reader.GetInt32(6),
                VehiclesMileage = reader.GetDouble(7),
                VehiclesLastService = reader.IsDBNull(8) ? null : reader.GetDateTime(8)
            });
        }


        return list;
    }

    /// <summary>
    /// Reads data into the List from the database
    /// </summary>
    /// <param name="connection">connection to database</param>
    /// <returns>List of Services</returns>
    private static List<Service> LoadServices(SqlConnection connection)
    {
        var list = new List<Service>();
        const string query = "SELECT * FROM Services";
        using var command = new SqlCommand(query, connection);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new Service
            {
                ServiceId = reader.GetInt32(0),
                ServiceName = reader.GetString(1),
                ServicePrice = reader.GetDecimal(2),
                ServiceEstimatedTime = reader.GetDouble(3),
                ServiceIsWarranty = reader.GetBoolean(4) ? "Yes" : "No"
            });
        }

        return list;
    }

    /// <summary>
    /// Reads data into the List from the database
    /// </summary>
    /// <param name="connection">connection to database</param>
    /// <returns>List of Repairs</returns>
    private static List<Repair> LoadRepairs(SqlConnection connection)
    {
        var list = new List<Repair>();
        const string query = "SELECT * FROM Repairs";
        using var command = new SqlCommand(query, connection);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new Repair
            {
                RepairId = reader.GetInt32(0),
                RVehiclesId = reader.GetInt32(1),
                RServiceId = reader.GetInt32(2),
                RepairRepairDate = reader.GetDateTime(3),
                RepairTotalCost = reader.GetDouble(4),
                RepairIsCompleted = reader.GetBoolean(5) ? "Yes" : "No"
            });
        }

        return list;
    }

    /// <summary>
    /// Reads data into the List from the database
    /// </summary>
    /// <param name="connection">connection to database</param>
    /// <returns>List of Mechanics</returns>
    private static List<Mechanic> LoadMechanics(SqlConnection connection)
    {
        var list = new List<Mechanic>();
        const string query = "SELECT * FROM Mechanics";
        using var command = new SqlCommand(query, connection);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new Mechanic
            {
                MechanicId = reader.GetInt32(0),
                MechanicName = reader.GetString(1),
                MechanicSurname = reader.GetString(2),
                MechanicSpecialization = reader.GetString(3),
                MechanicHourlyRate = reader.GetDouble(4),
                MechanicEmploymentDate = reader.GetDateTime(5),
                MechanicIsActive = reader.GetBoolean(6) ? "Yes" : "No"
            });
        }

        return list;
    }
    
    //Generated by AI
    /// <summary>
    /// Reads data from file
    /// </summary>
    private void InsertFromFile_Click(object sender, EventArgs e)
    {
        var openFileDialog = new OpenFileDialog
        {
            Title = "Select a file to import",
            Filter = "XML files (*.xml)|*.xml|JSON files (*.json)|*.json",
            Multiselect = false
        };


        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            var selectedFile = openFileDialog.FileName;

            if (selectedFile.EndsWith(".xml"))
            {
                ImportFromXml(selectedFile);
            }
            else if (selectedFile.EndsWith(".json"))
            {
                ImportFromJson(selectedFile);
            }
            else
            {
                Console.WriteLine("Unsupported file format.");
            }
        }
        else
        {
            Console.WriteLine("No file was selected.");
        }
    }

    /// <summary>
    ///  Import data from Xml
    /// </summary>
    /// <param name="filePath">Path to the file</param>
    private void ImportFromXml(string filePath)
    {
        var serializer = new XmlSerializer(typeof(Data));
        using var reader = new StreamReader(filePath);
        var data = (Data)serializer.Deserialize(reader)!;
        InsertFromFolder(data);
    }

    /// <summary>
    /// Import data from Json
    /// </summary>
    /// <param name="filePath">Path to the file</param>
    private void ImportFromJson(string filePath)
    {
        var json = File.ReadAllText(filePath);
        var data = JsonConvert.DeserializeObject<Data>(json)!;
        InsertFromFolder(data);
    }

    /// <summary>
    /// Uploads data to the database from file
    /// </summary>
    /// <param name="data"> Data to be sent to the database</param>
    private void InsertFromFolder(Data data)
    {
        _dao.EnsureConnectionOpen();
        foreach (var customer in data.Customers!)
        {
            const string query =
                "INSERT INTO Customers (Name, Surname, PhoneNumber, Email, Discount, IsVIP) VALUES (@Name, @Surname, @PhoneNumber, @Email, @Discount, @IsVIP)";
            using var command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@Name", customer.CustomersName);
            command.Parameters.AddWithValue("@Surname", customer.CustomersSurname);
            command.Parameters.AddWithValue("@PhoneNumber", customer.CustomersPhoneNumber);
            command.Parameters.AddWithValue("@Email", customer.CustomersEmail);
            command.Parameters.AddWithValue("@Discount", customer.CustomersDiscount);
            command.Parameters.AddWithValue("@IsVIP", customer.CustomersIsVip);
            command.ExecuteNonQuery();
        }

        foreach (var vehicle in data.Vehicles!)
        {
            const string query =
                "INSERT INTO Vehicles (Customers_id, LicensePlate, Brand, Model, Color, Year, Mileage) VALUES (@Customers_id, @LicensePlate, @Brand, @Model, @Color, @Year, @Mileage)";
            using var command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@Customers_id", vehicle.VCustomersId);
            command.Parameters.AddWithValue("@LicensePlate", vehicle.VehiclesLicensePlate);
            command.Parameters.AddWithValue("@Brand", vehicle.VehiclesBrand);
            command.Parameters.AddWithValue("@Model", vehicle.VehiclesModel);
            command.Parameters.AddWithValue("@Color", vehicle.VehiclesColor);
            command.Parameters.AddWithValue("@Year", vehicle.VehiclesYear);
            command.Parameters.AddWithValue("@Mileage", vehicle.VehiclesMileage);
            command.ExecuteNonQuery();
        }
    }


    
}