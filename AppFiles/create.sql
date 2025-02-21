CREATE TABLE Customers (
                           Customers_id INT IDENTITY(1,1) PRIMARY KEY,
                           Name NVARCHAR(255) NOT NULL,
                           Surname NVARCHAR(255) NOT NULL,
                           PhoneNumber NVARCHAR(20),
                           Email NVARCHAR(255) UNIQUE NOT NULL,
                           Discount FLOAT CHECK (Discount >= 0 AND Discount <= 100),
                           IsVIP BIT DEFAULT 0, 
                           RegistrationDate DATE DEFAULT GETDATE(), 
                           CONSTRAINT CHK_PhoneNumber CHECK (PhoneNumber LIKE '[0-9]%' AND LEN(PhoneNumber) BETWEEN 9 AND 15),
                           CONSTRAINT CHK_Email CHECK (Email LIKE '%@%.%')
);

CREATE TABLE Vehicles (
                          Vehicles_id INT IDENTITY(1,1) PRIMARY KEY,
                          Customers_id INT,
                          LicensePlate NVARCHAR(20) UNIQUE NOT NULL,
                          Brand NVARCHAR(100),
                          Model NVARCHAR(100),
                          Color NVARCHAR(100),
                          Year INT CHECK (Year > 1900 AND Year <= YEAR(GETDATE())),
                          Mileage FLOAT CHECK (Mileage >= 0), 
                          LastService DATE DEFAULT NULL,
                          FOREIGN KEY (Customers_id) REFERENCES Customers(Customers_id)
);

CREATE TABLE Services (
                          Service_id INT IDENTITY(1,1) PRIMARY KEY,
                          ServiceName NVARCHAR(255) NOT NULL,
                          Price DECIMAL(10, 2) CHECK (Price >= 0),
                          EstimatedTime FLOAT CHECK (EstimatedTime > 0),
                          IsWarranty BIT DEFAULT 0
);

CREATE TABLE Repairs (
                         Repair_id INT IDENTITY(1,1) PRIMARY KEY,
                         Vehicles_id INT,
                         Service_id INT,
                         RepairDate DATE CHECK (RepairDate <= GETDATE()),
                         TotalCost FLOAT CHECK (TotalCost >= 0), 
                         IsCompleted BIT DEFAULT 0,
                         FOREIGN KEY (Vehicles_id) REFERENCES Vehicles(Vehicles_id),
                         FOREIGN KEY (Service_id) REFERENCES Services(Service_id)
);

CREATE TABLE Mechanics (
                           Mechanic_id INT IDENTITY(1,1) PRIMARY KEY,
                           Name NVARCHAR(255) NOT NULL,
                           Surname NVARCHAR(255) NOT NULL,
                           Specialization NVARCHAR(255),
                           HourlyRate FLOAT CHECK (HourlyRate > 0), 
                           EmploymentDate DATE DEFAULT GETDATE(), 
                           IsActive BIT DEFAULT 1,
                           CONSTRAINT CHK_Specialization CHECK ( Specialization IN ('engine', 'diagnostics', 'paintwork', 'transmission', 'suspension', 'electronics', 'other'))
);

CREATE TABLE RepairMechanics (
                                 RepairMechanic_id INT IDENTITY(1,1) PRIMARY KEY,
                                 Repair_id INT,
                                 Mechanic_id INT,
                                 WorkHours FLOAT CHECK (WorkHours >= 0),
                                 FOREIGN KEY (Repair_id) REFERENCES Repairs(Repair_id),
                                 FOREIGN KEY (Mechanic_id) REFERENCES Mechanics(Mechanic_id)
);
