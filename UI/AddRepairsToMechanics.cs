using System.Data;
using CarServiceDB.Classes;
using CarServiceDB.Database;
using Microsoft.Data.SqlClient;

namespace CarServiceDB.UI;

public partial class AddRepairsToMechanics : Form
{
    private readonly Dao _dao;
    private readonly SqlConnection _connection;
    
    private List<Service> _services = [];
    private List<Mechanic> _mechanics = [];
    
    
    public AddRepairsToMechanics(Dao dao)
    {
        _dao = dao;
        _connection = dao.Connection;
        InitializeComponent();
        LoadData();
    }
    
    private void Add_Click(object sender, EventArgs e)
    {
        var repairId = GetRepairId(GetServiceId(repairBox.Text));
        var mName = mechanicBox.Text.Split(" ")[0];
        var mSurname = mechanicBox.Text.Split(" ")[1];
        _dao.AddRepairMechanics(repairId,GetMechanicId(mName, mSurname), 0,_connection);
        Close();
    }
    
    /// <summary>
    /// Loads data to combo boxes
    /// </summary>
    private void LoadData()
    {
        _dao.EnsureConnectionOpen();
        repairBox.Items.Clear();
        mechanicBox.Items.Clear();
        
        _services =LoadServices(_connection);
        if (_services.Count > 0)
        {
            repairBox.Items.AddRange(_services.Select(s => s.ServiceName)!.ToArray<object>());
            repairBox.SelectedIndex = 0;
        }
        _mechanics = LoadMechanics(_connection);
        if (_mechanics.Count > 0)
        {
            mechanicBox.Items.AddRange(_mechanics.Select(m => m.MechanicName + " " + m.MechanicSurname).ToArray<object>());
            mechanicBox.SelectedIndex = 0;
        }
        
        if (_connection.State == ConnectionState.Open)
            _connection.Close();
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
    /// <param name="serviceId"> ID of the service</param>
    /// <returns> ID of the repair</returns>
    private int GetRepairId(int serviceId)
    {
        var id = 0;
        using (_connection)
            try
            {
                _dao.EnsureConnectionOpen();
                using var cmd =
                    new SqlCommand("SELECT Repair_id FROM Repairs WHERE Service_id = @ServiceId",
                        _connection);
                cmd.Parameters.AddWithValue("@ServiceId", serviceId);
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