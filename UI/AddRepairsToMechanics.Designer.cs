using System.ComponentModel;

namespace CarServiceDB.UI;

partial class AddRepairsToMechanics
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
        repairBox = new System.Windows.Forms.ComboBox();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        mechanicBox = new System.Windows.Forms.ComboBox();
        Add = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // repairBox
        // 
        repairBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        repairBox.FormattingEnabled = true;
        repairBox.Location = new System.Drawing.Point(46, 35);
        repairBox.Name = "repairBox";
        repairBox.Size = new System.Drawing.Size(138, 23);
        repairBox.TabIndex = 0;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(5, 35);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(35, 23);
        label1.TabIndex = 1;
        label1.Text = "Add";
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(189, 35);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(28, 23);
        label2.TabIndex = 2;
        label2.Text = "to";
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(46, 9);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(138, 23);
        label3.TabIndex = 3;
        label3.Text = "Repair";
        // 
        // label4
        // 
        label4.Location = new System.Drawing.Point(223, 9);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(138, 23);
        label4.TabIndex = 4;
        label4.Text = "Mechanic";
        // 
        // mechanicBox
        // 
        mechanicBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        mechanicBox.FormattingEnabled = true;
        mechanicBox.Location = new System.Drawing.Point(223, 35);
        mechanicBox.Name = "mechanicBox";
        mechanicBox.Size = new System.Drawing.Size(138, 23);
        mechanicBox.TabIndex = 5;
        // 
        // Add
        // 
        Add.Location = new System.Drawing.Point(125, 75);
        Add.Name = "Add";
        Add.Size = new System.Drawing.Size(107, 23);
        Add.TabIndex = 6;
        Add.Text = "Add";
        Add.UseVisualStyleBackColor = true;
        Add.Click += Add_Click;
        // 
        // AddRepairsToMechanics
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(381, 105);
        Controls.Add(Add);
        Controls.Add(mechanicBox);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(repairBox);
        Text = "AddRepairsToMechanics";
        ResumeLayout(false);
    }

    private System.Windows.Forms.ComboBox repairBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ComboBox mechanicBox;
    private System.Windows.Forms.Button Add;

    #endregion
}