using System.ComponentModel;

namespace CarServiceDB.UI;

partial class ConfirmationDialog
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
        label1 = new System.Windows.Forms.Label();
        button1 = new System.Windows.Forms.Button();
        button2 = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.Location = new System.Drawing.Point(31, 9);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(342, 53);
        label1.TabIndex = 0;
        label1.Text = "Do you really want to delete this data?";
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(31, 92);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(111, 32);
        button1.TabIndex = 1;
        button1.Text = "Yes";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(262, 92);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(111, 30);
        button2.TabIndex = 2;
        button2.Text = "No";
        button2.UseVisualStyleBackColor = true;
        // 
        // ConfirmationDialog
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(416, 149);
        Controls.Add(button2);
        Controls.Add(button1);
        Controls.Add(label1);
        Text = "ConfirmationDialog";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;

    private System.Windows.Forms.Label label1;

    #endregion
}