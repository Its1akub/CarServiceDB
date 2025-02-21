using System.ComponentModel;

namespace CarServiceDB.UI;

partial class InsertMechanics
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
        mName = new System.Windows.Forms.TextBox();
        mSurname = new System.Windows.Forms.TextBox();
        mHourlyRate = new System.Windows.Forms.TextBox();
        mSpecialization = new System.Windows.Forms.ComboBox();
        mEmployDate = new System.Windows.Forms.DateTimePicker();
        mActive = new System.Windows.Forms.CheckBox();
        mInsert = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        label5 = new System.Windows.Forms.Label();
        label6 = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // mName
        // 
        mName.Location = new System.Drawing.Point(139, 63);
        mName.Name = "mName";
        mName.Size = new System.Drawing.Size(181, 23);
        mName.TabIndex = 0;
        // 
        // mSurname
        // 
        mSurname.Location = new System.Drawing.Point(139, 92);
        mSurname.Name = "mSurname";
        mSurname.Size = new System.Drawing.Size(181, 23);
        mSurname.TabIndex = 1;
        // 
        // mHourlyRate
        // 
        mHourlyRate.Location = new System.Drawing.Point(139, 150);
        mHourlyRate.Name = "mHourlyRate";
        mHourlyRate.Size = new System.Drawing.Size(181, 23);
        mHourlyRate.TabIndex = 2;
        // 
        // mSpecialization
        // 
        mSpecialization.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        mSpecialization.FormattingEnabled = true;
        mSpecialization.Items.AddRange(new object[] { "engine", "diagnostics", "paintwork", "transmission", "suspension", "electronics", "other" });
        mSpecialization.Location = new System.Drawing.Point(139, 121);
        mSpecialization.Name = "mSpecialization";
        mSpecialization.Size = new System.Drawing.Size(181, 23);
        mSpecialization.TabIndex = 3;
        // 
        // mEmployDate
        // 
        mEmployDate.Location = new System.Drawing.Point(139, 179);
        mEmployDate.Name = "mEmployDate";
        mEmployDate.Size = new System.Drawing.Size(181, 23);
        mEmployDate.TabIndex = 4;
        // 
        // mActive
        // 
        mActive.Location = new System.Drawing.Point(139, 219);
        mActive.Name = "mActive";
        mActive.Size = new System.Drawing.Size(181, 25);
        mActive.TabIndex = 5;
        mActive.Text = "checkBox1";
        mActive.UseVisualStyleBackColor = true;
        // 
        // mInsert
        // 
        mInsert.Location = new System.Drawing.Point(67, 260);
        mInsert.Name = "mInsert";
        mInsert.Size = new System.Drawing.Size(181, 23);
        mInsert.TabIndex = 6;
        mInsert.Text = "Insert";
        mInsert.UseVisualStyleBackColor = true;
        mInsert.Click += mInsert_Click;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(67, 66);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(54, 21);
        label1.TabIndex = 7;
        label1.Text = "Name :";
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(54, 95);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(67, 21);
        label2.TabIndex = 8;
        label2.Text = "Surname :";
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(29, 124);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(92, 21);
        label3.TabIndex = 9;
        label3.Text = "Specialization :";
        // 
        // label4
        // 
        label4.Location = new System.Drawing.Point(37, 153);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(84, 21);
        label4.TabIndex = 10;
        label4.Text = "  Hourly rate :";
        // 
        // label5
        // 
        label5.Location = new System.Drawing.Point(8, 181);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(113, 21);
        label5.TabIndex = 11;
        label5.Text = "Employment Date :";
        // 
        // label6
        // 
        label6.Location = new System.Drawing.Point(37, 223);
        label6.Name = "label6";
        label6.Size = new System.Drawing.Size(84, 21);
        label6.TabIndex = 12;
        label6.Text = "Active :";
        // 
        // InsertMechanics
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(333, 304);
        Controls.Add(label6);
        Controls.Add(label5);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(mInsert);
        Controls.Add(mActive);
        Controls.Add(mEmployDate);
        Controls.Add(mSpecialization);
        Controls.Add(mHourlyRate);
        Controls.Add(mSurname);
        Controls.Add(mName);
        Text = "InsertMechanics";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label label6;

    private System.Windows.Forms.TextBox mName;
    private System.Windows.Forms.TextBox mSurname;
    private System.Windows.Forms.TextBox mHourlyRate;
    private System.Windows.Forms.ComboBox mSpecialization;
    private System.Windows.Forms.DateTimePicker mEmployDate;
    private System.Windows.Forms.CheckBox mActive;
    private System.Windows.Forms.Button mInsert;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;

    #endregion
}