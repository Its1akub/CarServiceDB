namespace CarServiceDB.UI;

public partial class ConfirmationDialog : Form
{
    public ConfirmationDialog()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        YesNo = true;
        Close();
    }

    public bool YesNo { get; set; }
}