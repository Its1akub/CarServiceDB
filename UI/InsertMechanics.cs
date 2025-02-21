using CarServiceDB.Database;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace CarServiceDB.UI;

public partial class InsertMechanics : Form
{
    private readonly Dao _dao;
    private readonly SqlConnection _connection;
    public InsertMechanics(Dao dao)
    {
        _dao = dao;
        _connection = _dao.Connection;
        InitializeComponent();
        mSpecialization.SelectedIndex = 0;
    }

    private void mInsert_Click(object sender, EventArgs e)
    {
        if (!mName.Text.IsNullOrEmpty() || !mSurname.Text.IsNullOrEmpty()) return;
        
        _dao.AddMechanics(mName.Text, mSurname.Text, mSpecialization.Text, Convert.ToSingle(mHourlyRate.Text),
            mEmployDate.Text, mActive.Checked, _connection);
        Close();
    }
}