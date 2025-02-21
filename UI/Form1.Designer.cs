namespace CarServiceDB.UI;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        LoginPanel = new System.Windows.Forms.Panel();
        AddRtoM = new System.Windows.Forms.Button();
        InsertMechanics = new System.Windows.Forms.Button();
        InsertFromFile = new System.Windows.Forms.Button();
        dataFrom = new System.Windows.Forms.ComboBox();
        dataView = new System.Windows.Forms.DataGridView();
        DeleteData = new System.Windows.Forms.Button();
        EditData = new System.Windows.Forms.Button();
        InsertData = new System.Windows.Forms.Button();
        LoginPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataView).BeginInit();
        SuspendLayout();
        // 
        // LoginPanel
        // 
        LoginPanel.Controls.Add(AddRtoM);
        LoginPanel.Controls.Add(InsertMechanics);
        LoginPanel.Controls.Add(InsertFromFile);
        LoginPanel.Controls.Add(dataFrom);
        LoginPanel.Controls.Add(dataView);
        LoginPanel.Controls.Add(DeleteData);
        LoginPanel.Controls.Add(EditData);
        LoginPanel.Controls.Add(InsertData);
        LoginPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        LoginPanel.Location = new System.Drawing.Point(0, 0);
        LoginPanel.Name = "LoginPanel";
        LoginPanel.Size = new System.Drawing.Size(1161, 801);
        LoginPanel.TabIndex = 1;
        // 
        // AddRtoM
        // 
        AddRtoM.Location = new System.Drawing.Point(659, 41);
        AddRtoM.Name = "AddRtoM";
        AddRtoM.Size = new System.Drawing.Size(154, 24);
        AddRtoM.TabIndex = 8;
        AddRtoM.Text = "Add Repair to Mechanic";
        AddRtoM.UseVisualStyleBackColor = true;
        AddRtoM.Click += AddRtoM_Click;
        // 
        // InsertMechanics
        // 
        InsertMechanics.Location = new System.Drawing.Point(537, 41);
        InsertMechanics.Name = "InsertMechanics";
        InsertMechanics.Size = new System.Drawing.Size(116, 24);
        InsertMechanics.TabIndex = 7;
        InsertMechanics.Text = "Insert Mechanics";
        InsertMechanics.UseVisualStyleBackColor = true;
        InsertMechanics.Click += InsertMechanics_Click;
        // 
        // InsertFromFile
        // 
        InsertFromFile.Location = new System.Drawing.Point(384, 42);
        InsertFromFile.Name = "InsertFromFile";
        InsertFromFile.Size = new System.Drawing.Size(147, 24);
        InsertFromFile.TabIndex = 6;
        InsertFromFile.Text = "Insert Data From File";
        InsertFromFile.UseVisualStyleBackColor = true;
        InsertFromFile.Click += InsertFromFile_Click;
        // 
        // dataFrom
        // 
        dataFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        dataFrom.FormattingEnabled = true;
        dataFrom.Items.AddRange(new object[] { "Customers", "Vehicles", "Services", "Repairs", "Mechanics" });
        dataFrom.Location = new System.Drawing.Point(276, 43);
        dataFrom.Name = "dataFrom";
        dataFrom.Size = new System.Drawing.Size(102, 23);
        dataFrom.TabIndex = 5;
        dataFrom.SelectedIndexChanged += dataFrom_SelectedIndexChanged;
        // 
        // dataView
        // 
        dataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        dataView.Location = new System.Drawing.Point(7, 72);
        dataView.Name = "dataView";
        dataView.Size = new System.Drawing.Size(1142, 717);
        dataView.TabIndex = 4;
        // 
        // DeleteData
        // 
        DeleteData.Location = new System.Drawing.Point(188, 43);
        DeleteData.Name = "DeleteData";
        DeleteData.Size = new System.Drawing.Size(82, 23);
        DeleteData.TabIndex = 3;
        DeleteData.Text = "Delete Data";
        DeleteData.UseVisualStyleBackColor = true;
        DeleteData.Click += DeleteData_Click;
        // 
        // EditData
        // 
        EditData.Location = new System.Drawing.Point(100, 43);
        EditData.Name = "EditData";
        EditData.Size = new System.Drawing.Size(82, 23);
        EditData.TabIndex = 2;
        EditData.Text = "Edit Data";
        EditData.UseVisualStyleBackColor = true;
        EditData.Click += EditData_Click;
        // 
        // InsertData
        // 
        InsertData.Location = new System.Drawing.Point(12, 43);
        InsertData.Name = "InsertData";
        InsertData.Size = new System.Drawing.Size(82, 23);
        InsertData.TabIndex = 1;
        InsertData.Text = "Insert Data";
        InsertData.UseVisualStyleBackColor = true;
        InsertData.Click += InsertData_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1161, 801);
        Controls.Add(LoginPanel);
        RightToLeft = System.Windows.Forms.RightToLeft.No;
        Text = "CarServiceDB";
        LoginPanel.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dataView).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button AddRtoM;

    private System.Windows.Forms.Button InsertMechanics;

    private System.Windows.Forms.Button InsertFromFile;

    private System.Windows.Forms.ComboBox dataFrom;

    private System.Windows.Forms.DataGridView dataView;

    private System.Windows.Forms.Button DeleteData;
    private System.Windows.Forms.Button InsertData;

    private System.Windows.Forms.Button EditData;

    private System.Windows.Forms.Panel LoginPanel;

    #endregion
}