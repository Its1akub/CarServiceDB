using System.Data;
using CarServiceDB.Classes;
using CarServiceDB.Database;
using Microsoft.Data.SqlClient;

namespace CarServiceDB.UI;

public partial class UpdateData : Form
{
    private readonly Dao _dao;
    private readonly SqlConnection _connection;

    private List<Customer> _customers = [];
    private List<Vehicle> _vehicles = [];
    private List<Service> _services = [];
    private List<Mechanic> _mechanics = [];

    public UpdateData(Dao dao)
    {
        _dao = dao;
        _connection = _dao.Connection;
        InitializeComponent();
        dataFrom.SelectedIndex = 0;
    }

    private void dataFrom_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadData();
    }

    private void UpdateData_Load(object sender, EventArgs e)
    {
        LoadData();
    }


    private void LoadData()
    {
        _dao.EnsureConnectionOpen();
        data.Items.Clear();
        atributes.Items.Clear();

        switch (dataFrom.Text)
        {
            case "Customers":
                _customers = LoadCustomers(_connection);
                data.Items.AddRange(
                    _customers.Select(c => c.CustomersName + " " + c.CustomersSurname).ToArray<object>());
                atributes.Items.AddRange([
                    "Name", "Surname", "PhoneNumber", "Email", "Discount", "IsVIP", "RegistrationDate"
                ]);
                break;
            case "Vehicles":
                _vehicles = LoadVehicles(_connection);
                data.Items.AddRange(_vehicles.Select(v => v.VehiclesBrand + " " + v.VehiclesModel).ToArray<object>());
                atributes.Items.AddRange(["LicensePlate", "Brand", "Model", "Color", "Year", "Mileage", "LastService"]);
                break;
            case "Services":
                _services = LoadServices(_connection);
                data.Items.AddRange(_services.Select(s => s.ServiceName)!.ToArray<object>());
                atributes.Items.AddRange(["ServiceName", "Price", "EstimatedTime", "IsWarranty"]);
                break;
            case "Mechanics":
                _mechanics = LoadMechanics(_connection);
                data.Items.AddRange(_mechanics.Select(m => m.MechanicName + " " + m.MechanicSurname).ToArray<object>());
                atributes.Items.AddRange([
                    "Name", "Surname", "Specialization", "HourlyRate", "EmploymentDate", "IsActive"
                ]);
                break;
        }

        if (data.Items.Count > 0)
            data.SelectedIndex = 0;


        if (_connection.State == ConnectionState.Open)
            _connection.Close();
    }

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
            });
        }


        return list;
    }

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
                VehiclesBrand = reader.GetString(3),
                VehiclesModel = reader.GetString(4),
            });
        }


        return list;
    }

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
            });
        }

        return list;
    }

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
            });
        }

        return list;
    }


    private void UpdateButtonClick(object sender, EventArgs e)
    {
        UpdateDataFromDatabase();
        MessageBox.Show("Data has been successfully Updated!", "Confirmation", MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        LoadData();
        Close();
    }


    private void UpdateDataFromDatabase()
    {
        var dataSelected = data.Text.Split(" ");
        var text = atributes.Text;
        switch (dataFrom.Text)
        {
            case "Customers":
                _dao.UpdateCustomer(ValueNew.Text, GetCustomerId(dataSelected[0], dataSelected[1]), text == "Name",
                    text == "Surname",
                    text == "PhoneNumber", text == "Email", text == "Discount", text == "IsVIP",
                    text == "RegistrationDate", _connection);
                break;
            case "Vehicles":
                _dao.UpdateVehicle(ValueNew.Text, GetVehicleId(dataSelected[0], dataSelected[1]),
                    text == "LicensePlate", text == "Brand",
                    text == "Model", text == "Color", text == "Year", text == "Mileage", text == "LastService",
                    _connection);
                break;
            case "Services":
                _dao.UpdateService(ValueNew.Text, GetServiceId(dataSelected[0]), text == "ServiceName", text == "Price",
                    text == "EstimatedTime", text == "IsWarranty", _connection);
                break;
            case "Mechanics":
                _dao.UpdateMechanic(ValueNew.Text, GetMechanicId(dataSelected[0], dataSelected[1]), text == "Name",
                    text == "Surname",
                    text == "Specialization", text == "HourlyRate", text == "EmploymentDate", text == "IsActive",
                    _connection);
                break;
        }
    }

    /// <summary>
    ///  Gets id from table using defined inputs
    /// </summary>
    /// <param name="name"> Name of the customer</param>
    /// <param name="surname"> Surname of the customer</param>
    /// <returns> ID of the customer</returns>
    private int GetCustomerId(string name, string surname)
    {
        var id = 0;
        using (_connection)
            try
            {
                _dao.EnsureConnectionOpen();
                using var cmd =
                    new SqlCommand("SELECT Customers_id FROM Customers WHERE Name = @Name AND Surname = @Surname",
                        _connection);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Surname", surname);

                id = (int)cmd.ExecuteScalar();

                _connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        return id as int? ?? 0;
    }

    /// <summary>
    ///  Gets id from table using defined inputs
    /// </summary>
    /// <param name="brand"> Brand of the vehicle</param>
    /// <param name="model"> Model of the vehicle</param>
    /// <returns> ID of the customer</returns>
    private int GetVehicleId(string brand, string model)
    {
        var id = 0;
        using (_connection)
            try
            {
                _dao.EnsureConnectionOpen();
                using var cmd =
                    new SqlCommand("SELECT Vehicles_id FROM Vehicles WHERE Brand = @Brand AND Model = @Model",
                        _connection);
                cmd.Parameters.AddWithValue("@Brand", brand);
                cmd.Parameters.AddWithValue("@Model", model);
                id = (int)cmd.ExecuteScalar();

                _connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        return id as int? ?? 0;
    }

    /// <summary>
    ///  Gets id from table using defined inputs
    /// </summary>
    /// <param name="name"> Name of the service</param>
    /// <returns> ID of the serivce</returns>
    private int GetServiceId(string name)
    {
        var id = 0;
        using (_connection)
            try
            {
                _dao.EnsureConnectionOpen();
                using var cmd = new SqlCommand("SELECT Service_id FROM Services WHERE ServiceName = @ServiceName",
                    _connection);
                cmd.Parameters.AddWithValue("@ServiceName", name);
                id = (int)cmd.ExecuteScalar();

                _connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        return id as int? ?? 0;
    }

    /// <summary>
    ///  Gets id from table using defined inputs
    /// </summary>
    /// <param name="name"> Name of the mechanic</param>
    /// <param name="surname"> Surname of the mechanic</param>
    /// <returns> ID of the mechanic</returns>
    private int GetMechanicId(string name, string surname)
    {
        var id = 0;
        using (_connection)
        {
            try
            {
                _dao.EnsureConnectionOpen();
                using var cmd =
                    new SqlCommand("SELECT Mechanic_id FROM Mechanics WHERE Name = @Name AND Surname = @Surname",
                        _connection);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Surname", surname);
                id = (int)cmd.ExecuteScalar();

                _connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        return id as int? ?? 0;
    }

    
}