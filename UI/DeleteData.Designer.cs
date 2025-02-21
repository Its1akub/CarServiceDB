using System.ComponentModel;

namespace CarServiceDB.UI;

partial class DeleteData
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
        dataFrom = new System.Windows.Forms.ComboBox();
        data = new System.Windows.Forms.ComboBox();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        Delete = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // dataFrom
        // 
        dataFrom.FormattingEnabled = true;
        dataFrom.Items.AddRange(new object[] { "Customers", "Vehicles", "Services", "Mechanics" });
        dataFrom.Location = new System.Drawing.Point(82, 12);
        dataFrom.Name = "dataFrom";
        dataFrom.Size = new System.Drawing.Size(163, 23);
        dataFrom.TabIndex = 0;
        dataFrom.SelectedIndexChanged += dataFrom_SelectedIndexChanged;
        // 
        // data
        // 
        data.FormattingEnabled = true;
        data.Location = new System.Drawing.Point(82, 41);
        data.Name = "data";
        data.Size = new System.Drawing.Size(163, 23);
        data.TabIndex = 1;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(4, 12);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(66, 23);
        label1.TabIndex = 2;
        label1.Text = "Table :";
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(4, 41);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(66, 23);
        label2.TabIndex = 3;
        label2.Text = "What :";
        // 
        // Delete
        // 
        Delete.Location = new System.Drawing.Point(73, 96);
        Delete.Name = "Delete";
        Delete.Size = new System.Drawing.Size(112, 22);
        Delete.TabIndex = 4;
        Delete.Text = "Delete";
        Delete.UseVisualStyleBackColor = true;
        Delete.Click += Delete_Click;
        // 
        // DeleteData
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(257, 130);
        Controls.Add(Delete);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(data);
        Controls.Add(dataFrom);
        Text = "DeleteData";
        Load += DeleteData_Load;
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button Delete;

    private System.Windows.Forms.ComboBox dataFrom;
    private System.Windows.Forms.ComboBox data;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;

    #endregion
}