using System.Data;
using CarServiceDB.Database;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace CarServiceDB.UI;

public partial class InsertData : Form
{
    private readonly Dao _dao;
    private string? _lastAddedName;
    private string? _lastAddedVehicle;
    private string? _lastAddedService;
    private readonly SqlConnection _connection;

    public InsertData(Dao dao)
    {
        _dao = dao; 
        _connection = _dao.Connection;
        InitializeComponent();
    }

    private void InsertData_Load(object sender, EventArgs e)
    {
        vehicleYear.Format = DateTimePickerFormat.Custom;
        vehicleYear.CustomFormat = "yyyy";
        vehicleYear.ShowUpDown = true;
        LoadDataIntoVehicleCustomer();
    }

    private void InsertData_Leave(object sender, EventArgs e)
    {
        if (_connection.State == ConnectionState.Open) _connection.Close();
        _connection.ConnectionString = _dao.ConnectionString!;
    }

    /// <summary>
    /// Uploads data to the database to be loaded into the vehicle selection field
    /// </summary>
    private void LoadDataIntoVehicleCustomer()
    {
        const string query = "SELECT Customers_id, Name, Surname FROM Customers";
        using (_connection)
            try
            {
                _dao.EnsureConnectionOpen();
                using var cmd = new SqlCommand(query, _connection);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    vehicleCustomer.Items.Add(new KeyValuePair<int, string>((int)reader["Customers_id"],
                        reader["Name"] + " " + reader["Surname"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        vehicleCustomer.DisplayMember = "Value"; // Show Name
        vehicleCustomer.ValueMember = "Key"; // Store ID
        _connection.Close();
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

    private void customer_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(customerName.Text) || string.IsNullOrWhiteSpace(customerSur.Text))
            vehicleCustomer.Items.Remove(_lastAddedName);

        var fullName = customerName.Text + " " + customerSur.Text;

        if (!vehicleCustomer.Items.Contains(fullName)) vehicleCustomer.Items.Add(fullName);
        if (!string.IsNullOrEmpty(_lastAddedName) && vehicleCustomer.Items.Contains(_lastAddedName))
            vehicleCustomer.Items.Remove(_lastAddedName);

        vehicleCustomer.SelectedItem = fullName;
        _lastAddedName = fullName;
    }

    private void vehicle_Leave(object sender, EventArgs e)
    {
        var brand = vehicleBrand.Text.Trim();
        var model = vehicleModel.Text.Trim();

        if (string.IsNullOrWhiteSpace(brand) || string.IsNullOrWhiteSpace(model))
            repairVehicle.Items.Remove(_lastAddedVehicle);

        var vehicleText = brand + " " + model;

        if (!repairVehicle.Items.Contains(vehicleText)) repairVehicle.Items.Add(vehicleText);
        if (!string.IsNullOrEmpty(_lastAddedVehicle) && repairVehicle.Items.Contains(_lastAddedVehicle))
            repairVehicle.Items.Remove(_lastAddedVehicle);

        repairVehicle.SelectedItem = vehicleText;
        _lastAddedVehicle = vehicleText;
    }

    private void serviceName_Leave(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(serviceName.Text)) repairService.Items.Remove(_lastAddedService);
        if (!repairService.Items.Contains(serviceName.Text)) repairService.Items.Add(serviceName.Text);
        if (!string.IsNullOrEmpty(_lastAddedService) && repairService.Items.Contains(_lastAddedService))
            repairService.Items.Remove(_lastAddedService);

        repairService.SelectedItem = serviceName.Text;
        _lastAddedService = serviceName.Text;
    }

    private void Insert_Click(object sender, EventArgs e)
    {
        _dao.EnsureConnectionOpen();

        //customer
        if (!customerName.Text.IsNullOrEmpty())
        {
            var discountSelected = customerDiscount.Text.ToCharArray();
            var discount = Convert.ToSingle(discountSelected.Length > 2
                ? (discountSelected[0] + discountSelected[1]).ToString()
                : discountSelected[0].ToString());
            var isVip = customerVip.Text == "Yes";
            var registrationDate = DateTime.Now.ToString("yyyy-MM-dd");

            _dao.AddCustomers(customerName.Text, customerSur.Text, customerPhone.Text, customerEmail.Text, discount,
                isVip, registrationDate, _connection);
        }


        //vehicle
        if (!vehicleBrand.Text.IsNullOrEmpty() && !vehicleModel.Text.IsNullOrEmpty())
        {
            var idCustomer = GetCustomerId(customerName.Text, customerSur.Text);
            _dao.AddVehicles(idCustomer, vehicleLicensePlate.Text, vehicleBrand.Text, vehicleModel.Text,
                vehicleColor.Text, int.Parse(vehicleYear.Text), Convert.ToSingle(vehicleMileage.Text),
                vehicleLService.Text, _connection);
        }


        if (!serviceName.Text.IsNullOrEmpty())
        {
            //Service
            var warranty = serviceWarranty.Text == "Yes";
            _dao.AddServices(serviceName.Text, Convert.ToDouble(servicePrice.Text), Convert.ToSingle(serviceTime.Text),
                warranty, _connection);

            //Repair

            var idVehicle = GetVehicleId(vehicleBrand.Text, vehicleModel.Text);
            var idService = GetServiceId(serviceName.Text);
            _dao.AddRepairs(idVehicle, idService, repairDate.Text, Convert.ToDouble(repairCost.Text), false,
                _connection);
        }

        Close();
    }
}