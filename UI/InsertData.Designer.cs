using System.ComponentModel;

namespace CarServiceDB.UI;

partial class InsertData
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
        customerName = new System.Windows.Forms.TextBox();
        cName = new System.Windows.Forms.Label();
        cSurname = new System.Windows.Forms.Label();
        customerSur = new System.Windows.Forms.TextBox();
        cPhone = new System.Windows.Forms.Label();
        customerPhone = new System.Windows.Forms.TextBox();
        cEmail = new System.Windows.Forms.Label();
        customerEmail = new System.Windows.Forms.TextBox();
        Cdiscount = new System.Windows.Forms.Label();
        groupBox1 = new System.Windows.Forms.GroupBox();
        customerVip = new System.Windows.Forms.ComboBox();
        cVip = new System.Windows.Forms.Label();
        customerDiscount = new System.Windows.Forms.ComboBox();
        groupBox2 = new System.Windows.Forms.GroupBox();
        vehicleLService = new System.Windows.Forms.DateTimePicker();
        vLS = new System.Windows.Forms.Label();
        vehicleModel = new System.Windows.Forms.ComboBox();
        vehicleBrand = new System.Windows.Forms.ComboBox();
        vehicleYear = new System.Windows.Forms.DateTimePicker();
        vehicleCustomer = new System.Windows.Forms.ComboBox();
        vehicleMileage = new System.Windows.Forms.TextBox();
        vMileage = new System.Windows.Forms.Label();
        vYear = new System.Windows.Forms.Label();
        vehicleColor = new System.Windows.Forms.ComboBox();
        vBrand = new System.Windows.Forms.Label();
        vC = new System.Windows.Forms.Label();
        vColor = new System.Windows.Forms.Label();
        vLPlate = new System.Windows.Forms.Label();
        vehicleLicensePlate = new System.Windows.Forms.TextBox();
        vModel = new System.Windows.Forms.Label();
        groupBox3 = new System.Windows.Forms.GroupBox();
        serviceWarranty = new System.Windows.Forms.ComboBox();
        serviceTime = new System.Windows.Forms.TextBox();
        serviceName = new System.Windows.Forms.TextBox();
        sTime = new System.Windows.Forms.Label();
        sSname = new System.Windows.Forms.Label();
        sPrice = new System.Windows.Forms.Label();
        servicePrice = new System.Windows.Forms.TextBox();
        sWarranty = new System.Windows.Forms.Label();
        groupBox4 = new System.Windows.Forms.GroupBox();
        repairDate = new System.Windows.Forms.DateTimePicker();
        repairService = new System.Windows.Forms.ComboBox();
        repairVehicle = new System.Windows.Forms.ComboBox();
        rDate = new System.Windows.Forms.Label();
        rV = new System.Windows.Forms.Label();
        repairCost = new System.Windows.Forms.TextBox();
        rS = new System.Windows.Forms.Label();
        rCost = new System.Windows.Forms.Label();
        Insert = new System.Windows.Forms.Button();
        groupBox1.SuspendLayout();
        groupBox2.SuspendLayout();
        groupBox3.SuspendLayout();
        groupBox4.SuspendLayout();
        SuspendLayout();
        // 
        // customerName
        // 
        customerName.Location = new System.Drawing.Point(125, 12);
        customerName.Name = "customerName";
        customerName.PlaceholderText = "Name";
        customerName.Size = new System.Drawing.Size(152, 23);
        customerName.TabIndex = 1;
        customerName.Leave += customer_Leave;
        // 
        // cName
        // 
        cName.Location = new System.Drawing.Point(67, 12);
        cName.Name = "cName";
        cName.Size = new System.Drawing.Size(51, 21);
        cName.TabIndex = 2;
        cName.Text = "Name :";
        // 
        // cSurname
        // 
        cSurname.Location = new System.Drawing.Point(54, 41);
        cSurname.Name = "cSurname";
        cSurname.Size = new System.Drawing.Size(65, 21);
        cSurname.TabIndex = 4;
        cSurname.Text = "Surname :";
        // 
        // customerSur
        // 
        customerSur.Location = new System.Drawing.Point(125, 41);
        customerSur.Name = "customerSur";
        customerSur.PlaceholderText = "Surname";
        customerSur.Size = new System.Drawing.Size(152, 23);
        customerSur.TabIndex = 3;
        customerSur.Leave += customer_Leave;
        // 
        // cPhone
        // 
        cPhone.Location = new System.Drawing.Point(67, 70);
        cPhone.Name = "cPhone";
        cPhone.Size = new System.Drawing.Size(51, 21);
        cPhone.TabIndex = 6;
        cPhone.Text = "Phone :";
        // 
        // customerPhone
        // 
        customerPhone.Location = new System.Drawing.Point(125, 70);
        customerPhone.Name = "customerPhone";
        customerPhone.PlaceholderText = "123456789";
        customerPhone.Size = new System.Drawing.Size(152, 23);
        customerPhone.TabIndex = 5;
        // 
        // cEmail
        // 
        cEmail.Location = new System.Drawing.Point(72, 99);
        cEmail.Name = "cEmail";
        cEmail.Size = new System.Drawing.Size(51, 21);
        cEmail.TabIndex = 8;
        cEmail.Text = "email :";
        // 
        // customerEmail
        // 
        customerEmail.Location = new System.Drawing.Point(125, 99);
        customerEmail.Name = "customerEmail";
        customerEmail.PlaceholderText = "jan.novak@gmail.com";
        customerEmail.Size = new System.Drawing.Size(152, 23);
        customerEmail.TabIndex = 7;
        // 
        // Cdiscount
        // 
        Cdiscount.Location = new System.Drawing.Point(54, 128);
        Cdiscount.Name = "Cdiscount";
        Cdiscount.Size = new System.Drawing.Size(65, 21);
        Cdiscount.TabIndex = 10;
        Cdiscount.Text = "discount :";
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(customerVip);
        groupBox1.Controls.Add(cVip);
        groupBox1.Controls.Add(customerDiscount);
        groupBox1.Controls.Add(customerName);
        groupBox1.Controls.Add(cName);
        groupBox1.Controls.Add(Cdiscount);
        groupBox1.Controls.Add(customerSur);
        groupBox1.Controls.Add(cEmail);
        groupBox1.Controls.Add(cSurname);
        groupBox1.Controls.Add(customerEmail);
        groupBox1.Controls.Add(customerPhone);
        groupBox1.Controls.Add(cPhone);
        groupBox1.Location = new System.Drawing.Point(12, 12);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new System.Drawing.Size(283, 189);
        groupBox1.TabIndex = 11;
        groupBox1.TabStop = false;
        groupBox1.Text = "Customer";
        // 
        // customerVip
        // 
        customerVip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        customerVip.FormattingEnabled = true;
        customerVip.Items.AddRange(new object[] { "No", "Yes" });
        customerVip.Location = new System.Drawing.Point(125, 157);
        customerVip.Name = "customerVip";
        customerVip.Size = new System.Drawing.Size(152, 23);
        customerVip.TabIndex = 15;
        // 
        // cVip
        // 
        cVip.Location = new System.Drawing.Point(84, 157);
        cVip.Name = "cVip";
        cVip.Size = new System.Drawing.Size(34, 21);
        cVip.TabIndex = 14;
        cVip.Text = "vip :";
        // 
        // customerDiscount
        // 
        customerDiscount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
        customerDiscount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        customerDiscount.Items.AddRange(new object[] { "0%", "10%", "20%", "30%", "40%", "50%" });
        customerDiscount.Location = new System.Drawing.Point(125, 128);
        customerDiscount.Name = "customerDiscount";
        customerDiscount.Size = new System.Drawing.Size(152, 23);
        customerDiscount.TabIndex = 12;
        // 
        // groupBox2
        // 
        groupBox2.Controls.Add(vehicleLService);
        groupBox2.Controls.Add(vLS);
        groupBox2.Controls.Add(vehicleModel);
        groupBox2.Controls.Add(vehicleBrand);
        groupBox2.Controls.Add(vehicleYear);
        groupBox2.Controls.Add(vehicleCustomer);
        groupBox2.Controls.Add(vehicleMileage);
        groupBox2.Controls.Add(vMileage);
        groupBox2.Controls.Add(vYear);
        groupBox2.Controls.Add(vehicleColor);
        groupBox2.Controls.Add(vBrand);
        groupBox2.Controls.Add(vC);
        groupBox2.Controls.Add(vColor);
        groupBox2.Controls.Add(vLPlate);
        groupBox2.Controls.Add(vehicleLicensePlate);
        groupBox2.Controls.Add(vModel);
        groupBox2.Location = new System.Drawing.Point(12, 208);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new System.Drawing.Size(283, 266);
        groupBox2.TabIndex = 12;
        groupBox2.TabStop = false;
        groupBox2.Text = "Vehicle";
        // 
        // vehicleLService
        // 
        vehicleLService.CustomFormat = "yyyy-MM-dd";
        vehicleLService.Location = new System.Drawing.Point(124, 220);
        vehicleLService.Name = "vehicleLService";
        vehicleLService.ShowUpDown = true;
        vehicleLService.Size = new System.Drawing.Size(151, 23);
        vehicleLService.TabIndex = 42;
        // 
        // vLS
        // 
        vLS.Location = new System.Drawing.Point(37, 218);
        vLS.Name = "vLS";
        vLS.Size = new System.Drawing.Size(81, 21);
        vLS.TabIndex = 41;
        vLS.Text = "Last Service :";
        // 
        // vehicleModel
        // 
        vehicleModel.FormattingEnabled = true;
        vehicleModel.Location = new System.Drawing.Point(124, 104);
        vehicleModel.Name = "vehicleModel";
        vehicleModel.Size = new System.Drawing.Size(153, 23);
        vehicleModel.TabIndex = 40;
        vehicleModel.Leave += vehicle_Leave;
        // 
        // vehicleBrand
        // 
        vehicleBrand.Location = new System.Drawing.Point(124, 75);
        vehicleBrand.Name = "vehicleBrand";
        vehicleBrand.Size = new System.Drawing.Size(153, 23);
        vehicleBrand.TabIndex = 39;
        vehicleBrand.Leave += vehicle_Leave;
        // 
        // vehicleYear
        // 
        vehicleYear.CustomFormat = "yyyy";
        vehicleYear.Location = new System.Drawing.Point(125, 164);
        vehicleYear.Name = "vehicleYear";
        vehicleYear.ShowUpDown = true;
        vehicleYear.Size = new System.Drawing.Size(151, 23);
        vehicleYear.TabIndex = 38;
        // 
        // vehicleCustomer
        // 
        vehicleCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        vehicleCustomer.FormattingEnabled = true;
        vehicleCustomer.Location = new System.Drawing.Point(124, 14);
        vehicleCustomer.Name = "vehicleCustomer";
        vehicleCustomer.Size = new System.Drawing.Size(153, 23);
        vehicleCustomer.TabIndex = 37;
        // 
        // vehicleMileage
        // 
        vehicleMileage.Location = new System.Drawing.Point(125, 191);
        vehicleMileage.Name = "vehicleMileage";
        vehicleMileage.PlaceholderText = "100000";
        vehicleMileage.Size = new System.Drawing.Size(152, 23);
        vehicleMileage.TabIndex = 35;
        // 
        // vMileage
        // 
        vMileage.Location = new System.Drawing.Point(54, 191);
        vMileage.Name = "vMileage";
        vMileage.Size = new System.Drawing.Size(65, 21);
        vMileage.TabIndex = 36;
        vMileage.Text = "Mileage :";
        // 
        // vYear
        // 
        vYear.Location = new System.Drawing.Point(72, 162);
        vYear.Name = "vYear";
        vYear.Size = new System.Drawing.Size(47, 21);
        vYear.TabIndex = 34;
        vYear.Text = "Year :";
        // 
        // vehicleColor
        // 
        vehicleColor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
        vehicleColor.Location = new System.Drawing.Point(125, 133);
        vehicleColor.Name = "vehicleColor";
        vehicleColor.Size = new System.Drawing.Size(152, 23);
        vehicleColor.TabIndex = 32;
        // 
        // vBrand
        // 
        vBrand.Location = new System.Drawing.Point(54, 75);
        vBrand.Name = "vBrand";
        vBrand.Size = new System.Drawing.Size(65, 21);
        vBrand.TabIndex = 28;
        vBrand.Text = "Brand :";
        // 
        // vC
        // 
        vC.Location = new System.Drawing.Point(54, 17);
        vC.Name = "vC";
        vC.Size = new System.Drawing.Size(65, 21);
        vC.TabIndex = 24;
        vC.Text = "Customer :";
        // 
        // vColor
        // 
        vColor.Location = new System.Drawing.Point(67, 133);
        vColor.Name = "vColor";
        vColor.Size = new System.Drawing.Size(52, 21);
        vColor.TabIndex = 31;
        vColor.Text = "Color :";
        // 
        // vLPlate
        // 
        vLPlate.Location = new System.Drawing.Point(37, 46);
        vLPlate.Name = "vLPlate";
        vLPlate.Size = new System.Drawing.Size(82, 21);
        vLPlate.TabIndex = 26;
        vLPlate.Text = "License plate :";
        // 
        // vehicleLicensePlate
        // 
        vehicleLicensePlate.Location = new System.Drawing.Point(125, 46);
        vehicleLicensePlate.Name = "vehicleLicensePlate";
        vehicleLicensePlate.PlaceholderText = "ABC1234";
        vehicleLicensePlate.Size = new System.Drawing.Size(152, 23);
        vehicleLicensePlate.TabIndex = 25;
        // 
        // vModel
        // 
        vModel.Location = new System.Drawing.Point(54, 104);
        vModel.Name = "vModel";
        vModel.Size = new System.Drawing.Size(65, 21);
        vModel.TabIndex = 30;
        vModel.Text = "Model :";
        // 
        // groupBox3
        // 
        groupBox3.Controls.Add(serviceWarranty);
        groupBox3.Controls.Add(serviceTime);
        groupBox3.Controls.Add(serviceName);
        groupBox3.Controls.Add(sTime);
        groupBox3.Controls.Add(sSname);
        groupBox3.Controls.Add(sPrice);
        groupBox3.Controls.Add(servicePrice);
        groupBox3.Controls.Add(sWarranty);
        groupBox3.Location = new System.Drawing.Point(312, 12);
        groupBox3.Name = "groupBox3";
        groupBox3.Size = new System.Drawing.Size(345, 134);
        groupBox3.TabIndex = 13;
        groupBox3.TabStop = false;
        groupBox3.Text = "Service";
        // 
        // serviceWarranty
        // 
        serviceWarranty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        serviceWarranty.FormattingEnabled = true;
        serviceWarranty.Items.AddRange(new object[] { "Yes", "No" });
        serviceWarranty.Location = new System.Drawing.Point(124, 99);
        serviceWarranty.Name = "serviceWarranty";
        serviceWarranty.Size = new System.Drawing.Size(172, 23);
        serviceWarranty.TabIndex = 21;
        // 
        // serviceTime
        // 
        serviceTime.Location = new System.Drawing.Point(124, 70);
        serviceTime.Name = "serviceTime";
        serviceTime.Size = new System.Drawing.Size(173, 23);
        serviceTime.TabIndex = 17;
        // 
        // serviceName
        // 
        serviceName.Location = new System.Drawing.Point(124, 12);
        serviceName.Name = "serviceName";
        serviceName.Size = new System.Drawing.Size(173, 23);
        serviceName.TabIndex = 13;
        serviceName.Leave += serviceName_Leave;
        // 
        // sTime
        // 
        sTime.Location = new System.Drawing.Point(23, 70);
        sTime.Name = "sTime";
        sTime.Size = new System.Drawing.Size(95, 21);
        sTime.TabIndex = 18;
        sTime.Text = "Estimated time :";
        // 
        // sSname
        // 
        sSname.Location = new System.Drawing.Point(33, 12);
        sSname.Name = "sSname";
        sSname.Size = new System.Drawing.Size(85, 21);
        sSname.TabIndex = 14;
        sSname.Text = "Service name :";
        // 
        // sPrice
        // 
        sPrice.Location = new System.Drawing.Point(76, 41);
        sPrice.Name = "sPrice";
        sPrice.Size = new System.Drawing.Size(42, 21);
        sPrice.TabIndex = 16;
        sPrice.Text = "Price :";
        // 
        // servicePrice
        // 
        servicePrice.Location = new System.Drawing.Point(124, 41);
        servicePrice.Name = "servicePrice";
        servicePrice.Size = new System.Drawing.Size(173, 23);
        servicePrice.TabIndex = 15;
        // 
        // sWarranty
        // 
        sWarranty.Location = new System.Drawing.Point(53, 99);
        sWarranty.Name = "sWarranty";
        sWarranty.Size = new System.Drawing.Size(65, 21);
        sWarranty.TabIndex = 20;
        sWarranty.Text = "Warranty :";
        // 
        // groupBox4
        // 
        groupBox4.Controls.Add(repairDate);
        groupBox4.Controls.Add(repairService);
        groupBox4.Controls.Add(repairVehicle);
        groupBox4.Controls.Add(rDate);
        groupBox4.Controls.Add(rV);
        groupBox4.Controls.Add(repairCost);
        groupBox4.Controls.Add(rS);
        groupBox4.Controls.Add(rCost);
        groupBox4.Location = new System.Drawing.Point(314, 169);
        groupBox4.Name = "groupBox4";
        groupBox4.Size = new System.Drawing.Size(343, 160);
        groupBox4.TabIndex = 14;
        groupBox4.TabStop = false;
        groupBox4.Text = "Repair";
        // 
        // repairDate
        // 
        repairDate.CustomFormat = "yyyy-MM-dd";
        repairDate.Location = new System.Drawing.Point(124, 72);
        repairDate.Name = "repairDate";
        repairDate.Size = new System.Drawing.Size(173, 23);
        repairDate.TabIndex = 16;
        // 
        // repairService
        // 
        repairService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        repairService.FormattingEnabled = true;
        repairService.Location = new System.Drawing.Point(125, 43);
        repairService.Name = "repairService";
        repairService.Size = new System.Drawing.Size(173, 23);
        repairService.TabIndex = 42;
        // 
        // repairVehicle
        // 
        repairVehicle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        repairVehicle.FormattingEnabled = true;
        repairVehicle.Location = new System.Drawing.Point(125, 14);
        repairVehicle.Name = "repairVehicle";
        repairVehicle.Size = new System.Drawing.Size(173, 23);
        repairVehicle.TabIndex = 41;
        // 
        // rDate
        // 
        rDate.Location = new System.Drawing.Point(33, 75);
        rDate.Name = "rDate";
        rDate.Size = new System.Drawing.Size(85, 21);
        rDate.TabIndex = 38;
        rDate.Text = "Repair date :";
        // 
        // rV
        // 
        rV.Location = new System.Drawing.Point(53, 17);
        rV.Name = "rV";
        rV.Size = new System.Drawing.Size(65, 21);
        rV.TabIndex = 34;
        rV.Text = "Vehicle :";
        // 
        // repairCost
        // 
        repairCost.Location = new System.Drawing.Point(124, 104);
        repairCost.Name = "repairCost";
        repairCost.Size = new System.Drawing.Size(173, 23);
        repairCost.TabIndex = 39;
        // 
        // rS
        // 
        rS.Location = new System.Drawing.Point(53, 46);
        rS.Name = "rS";
        rS.Size = new System.Drawing.Size(65, 21);
        rS.TabIndex = 36;
        rS.Text = "Service :";
        // 
        // rCost
        // 
        rCost.Location = new System.Drawing.Point(40, 104);
        rCost.Name = "rCost";
        rCost.Size = new System.Drawing.Size(85, 21);
        rCost.TabIndex = 40;
        rCost.Text = "Total Cost :";
        // 
        // Insert
        // 
        Insert.Location = new System.Drawing.Point(436, 394);
        Insert.Name = "Insert";
        Insert.Size = new System.Drawing.Size(112, 25);
        Insert.TabIndex = 15;
        Insert.Text = "Insert";
        Insert.UseVisualStyleBackColor = true;
        Insert.Click += Insert_Click;
        // 
        // InsertData
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 486);
        Controls.Add(Insert);
        Controls.Add(groupBox4);
        Controls.Add(groupBox3);
        Controls.Add(groupBox2);
        Controls.Add(groupBox1);
        Text = "InserData";
        Load += InsertData_Load;
        Leave += InsertData_Leave;
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        groupBox2.ResumeLayout(false);
        groupBox2.PerformLayout();
        groupBox3.ResumeLayout(false);
        groupBox3.PerformLayout();
        groupBox4.ResumeLayout(false);
        groupBox4.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.DateTimePicker vehicleLService;
    private System.Windows.Forms.Label vLS;

    private System.Windows.Forms.ComboBox vehicleModel;
    private System.Windows.Forms.ComboBox vehicleBrand;

    private System.Windows.Forms.DateTimePicker vehicleYear;

    private System.Windows.Forms.DateTimePicker repairDate;

    private System.Windows.Forms.Button Insert;

    private System.Windows.Forms.ComboBox repairVehicle;
    private System.Windows.Forms.ComboBox repairService;
    private System.Windows.Forms.ComboBox serviceWarranty;
    private System.Windows.Forms.ComboBox vehicleCustomer;
    private System.Windows.Forms.ComboBox customerVip;

    private System.Windows.Forms.Label cVip;

    private System.Windows.Forms.TextBox vehicleY;
    private System.Windows.Forms.Label vYear;
    private System.Windows.Forms.TextBox vehicleMileage;
    private System.Windows.Forms.Label vMileage;

    private System.Windows.Forms.TextBox serviceName;
    private System.Windows.Forms.Label sSname;
    private System.Windows.Forms.TextBox servicePrice;
    private System.Windows.Forms.Label sWarranty;
    private System.Windows.Forms.Label sPrice;
    private System.Windows.Forms.TextBox serviceTime;
    private System.Windows.Forms.Label sTime;
    private System.Windows.Forms.ComboBox vehicleColor;
    private System.Windows.Forms.Label vC;
    private System.Windows.Forms.Label vColor;
    private System.Windows.Forms.TextBox vehicleLicensePlate;
    private System.Windows.Forms.Label vModel;
    private System.Windows.Forms.Label vLPlate;
    private System.Windows.Forms.Label vBrand;
    private System.Windows.Forms.Label rV;
    private System.Windows.Forms.Label rCost;
    private System.Windows.Forms.Label rS;
    private System.Windows.Forms.TextBox repairCost;
    private System.Windows.Forms.Label rDate;

    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.GroupBox groupBox4;

    private System.Windows.Forms.ComboBox customerDiscount;

    private System.Windows.Forms.Label Cdiscount;
    private System.Windows.Forms.GroupBox groupBox1;

    private System.Windows.Forms.Label cName;
    private System.Windows.Forms.Label cSurname;
    private System.Windows.Forms.TextBox customerSur;
    private System.Windows.Forms.Label cPhone;
    private System.Windows.Forms.TextBox customerPhone;
    private System.Windows.Forms.Label cEmail;
    private System.Windows.Forms.TextBox customerEmail;

    private System.Windows.Forms.TextBox customerName;

    #endregion
}