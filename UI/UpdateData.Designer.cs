using System.ComponentModel;

namespace CarServiceDB.UI;

partial class UpdateData
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
        ValueNew = new System.Windows.Forms.TextBox();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        updateButton = new System.Windows.Forms.Button();
        label4 = new System.Windows.Forms.Label();
        atributes = new System.Windows.Forms.ComboBox();
        SuspendLayout();
        // 
        // dataFrom
        // 
        dataFrom.FormattingEnabled = true;
        dataFrom.Items.AddRange(new object[] { "Customers", "Vehicles", "Services", "Mechanics" });
        dataFrom.Location = new System.Drawing.Point(313, 62);
        dataFrom.Name = "dataFrom";
        dataFrom.Size = new System.Drawing.Size(135, 23);
        dataFrom.TabIndex = 0;
        dataFrom.SelectedIndexChanged += dataFrom_SelectedIndexChanged;
        // 
        // data
        // 
        data.FormattingEnabled = true;
        data.Location = new System.Drawing.Point(313, 118);
        data.Name = "data";
        data.Size = new System.Drawing.Size(135, 23);
        data.TabIndex = 1;
        // 
        // ValueNew
        // 
        ValueNew.Location = new System.Drawing.Point(313, 223);
        ValueNew.Name = "ValueNew";
        ValueNew.Size = new System.Drawing.Size(135, 23);
        ValueNew.TabIndex = 2;
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.Location = new System.Drawing.Point(233, 62);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(63, 23);
        label1.TabIndex = 3;
        label1.Text = " Table :";
        // 
        // label2
        // 
        label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label2.Location = new System.Drawing.Point(203, 118);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(93, 23);
        label2.TabIndex = 4;
        label2.Text = "Which thing :";
        // 
        // label3
        // 
        label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label3.Location = new System.Drawing.Point(246, 223);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(50, 23);
        label3.TabIndex = 5;
        label3.Text = "Data :";
        // 
        // Update
        // 
        updateButton.Location = new System.Drawing.Point(313, 272);
        updateButton.Name = "updateButton";
        updateButton.Size = new System.Drawing.Size(135, 28);
        updateButton.TabIndex = 6;
        updateButton.Text = "Update";
        updateButton.UseVisualStyleBackColor = true;
        updateButton.Click += UpdateButtonClick;
        // 
        // label4
        // 
        label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label4.Location = new System.Drawing.Point(203, 170);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(93, 23);
        label4.TabIndex = 8;
        label4.Text = " What thing :";
        // 
        // atributes
        // 
        atributes.FormattingEnabled = true;
        atributes.Location = new System.Drawing.Point(313, 170);
        atributes.Name = "atributes";
        atributes.Size = new System.Drawing.Size(135, 23);
        atributes.TabIndex = 7;
        // 
        // UpdateData
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(label4);
        Controls.Add(atributes);
        Controls.Add(updateButton);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(ValueNew);
        Controls.Add(data);
        Controls.Add(dataFrom);
        Text = "UpdateData";
        Load += UpdateData_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ComboBox atributes;

    private System.Windows.Forms.Button updateButton;

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.TextBox ValueNew;
    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.ComboBox dataFrom;
    private System.Windows.Forms.ComboBox data;

    #endregion
}