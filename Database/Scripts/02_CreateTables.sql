-- =============================================
-- Create Tables Script
-- =============================================

USE InsuranceDB;
GO

-- =============================================
-- Table: User
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Users')
BEGIN
    CREATE TABLE Users (
        UserID INT PRIMARY KEY IDENTITY(1,1),
        FirstName NVARCHAR(50) NOT NULL,
        LastName NVARCHAR(50) NOT NULL,
        Email NVARCHAR(100) UNIQUE NOT NULL,
        Password NVARCHAR(255) NOT NULL,
        Phone NVARCHAR(15),
        Address NVARCHAR(255),
        DateOfBirth DATE,
        Gender NVARCHAR(10),
        CreatedDate DATETIME DEFAULT GETDATE(),
        IsActive BIT DEFAULT 1,
        Role NVARCHAR(20) DEFAULT 'User'
    );
    PRINT 'Table Users created successfully.';
END
GO

-- =============================================
-- Table: Policy
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Policies')
BEGIN
    CREATE TABLE Policies (
        PolicyID INT PRIMARY KEY IDENTITY(1,1),
        UserID INT NOT NULL,
        PolicyNumber NVARCHAR(50) UNIQUE NOT NULL,
        PolicyType NVARCHAR(20) NOT NULL,
        CoverageAmount DECIMAL(18,2) NOT NULL,
        TermPeriod INT NOT NULL,
        PremiumAmount DECIMAL(18,2) NOT NULL,
        StartDate DATE,
        EndDate DATE,
        Status NVARCHAR(20) DEFAULT 'Pending',
        ApplicationDate DATETIME DEFAULT GETDATE(),
        ApprovalDate DATETIME,
        ApprovedBy INT,
        FOREIGN KEY (UserID) REFERENCES Users(UserID),
        FOREIGN KEY (ApprovedBy) REFERENCES Users(UserID)
    );
    PRINT 'Table Policies created successfully.';
END
GO

-- =============================================
-- Table: LifeInsurance
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'LifeInsurance')
BEGIN
    CREATE TABLE LifeInsurance (
        LifeInsuranceID INT PRIMARY KEY IDENTITY(1,1),
        PolicyID INT NOT NULL,
        Age INT NOT NULL,
        Height DECIMAL(5,2),
        Weight DECIMAL(5,2),
        HealthStatus NVARCHAR(50),
        SmokingStatus BIT,
        Occupation NVARCHAR(100),
        Nominee NVARCHAR(100) NOT NULL,
        NomineeRelation NVARCHAR(50),
        FOREIGN KEY (PolicyID) REFERENCES Policies(PolicyID)
    );
    PRINT 'Table LifeInsurance created successfully.';
END
GO

-- =============================================
-- Table: MedicalInsurance
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'MedicalInsurance')
BEGIN
    CREATE TABLE MedicalInsurance (
        MedicalInsuranceID INT PRIMARY KEY IDENTITY(1,1),
        PolicyID INT NOT NULL,
        Age INT NOT NULL,
        PreExistingConditions NVARCHAR(500),
        BloodGroup NVARCHAR(5),
        FamilyMembersCount INT,
        CoverageType NVARCHAR(50),
        FOREIGN KEY (PolicyID) REFERENCES Policies(PolicyID)
    );
    PRINT 'Table MedicalInsurance created successfully.';
END
GO

-- =============================================
-- Table: MotorInsurance
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'MotorInsurance')
BEGIN
    CREATE TABLE MotorInsurance (
        MotorInsuranceID INT PRIMARY KEY IDENTITY(1,1),
        PolicyID INT NOT NULL,
        VehicleType NVARCHAR(50) NOT NULL,
        VehicleMake NVARCHAR(50) NOT NULL,
        VehicleModel NVARCHAR(50) NOT NULL,
        VehicleYear INT NOT NULL,
        VehicleValue DECIMAL(18,2) NOT NULL,
        RegistrationNumber NVARCHAR(20) UNIQUE NOT NULL,
        ChassisNumber NVARCHAR(50),
        EngineNumber NVARCHAR(50),
        FOREIGN KEY (PolicyID) REFERENCES Policies(PolicyID)
    );
    PRINT 'Table MotorInsurance created successfully.';
END
GO

-- =============================================
-- Table: HomeInsurance
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'HomeInsurance')
BEGIN
    CREATE TABLE HomeInsurance (
        HomeInsuranceID INT PRIMARY KEY IDENTITY(1,1),
        PolicyID INT NOT NULL,
        PropertyType NVARCHAR(50) NOT NULL,
        PropertyValue DECIMAL(18,2) NOT NULL,
        PropertyAddress NVARCHAR(255) NOT NULL,
        ConstructionType NVARCHAR(50),
        YearBuilt INT,
        SquareFeet INT,
        SecurityFeatures NVARCHAR(255),
        FOREIGN KEY (PolicyID) REFERENCES Policies(PolicyID)
    );
    PRINT 'Table HomeInsurance created successfully.';
END
GO

-- =============================================
-- Table: Payments
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Payments')
BEGIN
    CREATE TABLE Payments (
        PaymentID INT PRIMARY KEY IDENTITY(1,1),
        PolicyID INT NOT NULL,
        UserID INT NOT NULL,
        Amount DECIMAL(18,2) NOT NULL,
        PaymentDate DATETIME DEFAULT GETDATE(),
        PaymentMethod NVARCHAR(50),
        TransactionID NVARCHAR(100) UNIQUE,
        Status NVARCHAR(20) DEFAULT 'Pending',
        PaymentType NVARCHAR(20),
        FOREIGN KEY (PolicyID) REFERENCES Policies(PolicyID),
        FOREIGN KEY (UserID) REFERENCES Users(UserID)
    );
    PRINT 'Table Payments created successfully.';
END
GO

-- =============================================
-- Table: Loans
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Loans')
BEGIN
    CREATE TABLE Loans (
        LoanID INT PRIMARY KEY IDENTITY(1,1),
        PolicyID INT NOT NULL,
        UserID INT NOT NULL,
        LoanAmount DECIMAL(18,2) NOT NULL,
        InterestRate DECIMAL(5,2),
        LoanTerm INT,
        ApplicationDate DATETIME DEFAULT GETDATE(),
        ApprovalDate DATETIME,
        Status NVARCHAR(20) DEFAULT 'Pending',
        ApprovedBy INT,
        DisbursementDate DATETIME,
        FOREIGN KEY (PolicyID) REFERENCES Policies(PolicyID),
        FOREIGN KEY (UserID) REFERENCES Users(UserID),
        FOREIGN KEY (ApprovedBy) REFERENCES Users(UserID)
    );
    PRINT 'Table Loans created successfully.';
END
GO

-- =============================================
-- Table: NewsUpdates
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'NewsUpdates')
BEGIN
    CREATE TABLE NewsUpdates (
        NewsID INT PRIMARY KEY IDENTITY(1,1),
        Title NVARCHAR(200) NOT NULL,
        Content NVARCHAR(MAX) NOT NULL,
        PublishDate DATETIME DEFAULT GETDATE(),
        IsActive BIT DEFAULT 1,
        CreatedBy INT,
        FOREIGN KEY (CreatedBy) REFERENCES Users(UserID)
    );
    PRINT 'Table NewsUpdates created successfully.';
END
GO

-- =============================================
-- Create Indexes for Performance
-- =============================================

-- Index on User Email
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Users_Email')
BEGIN
    CREATE INDEX IX_Users_Email ON Users(Email);
    PRINT 'Index IX_Users_Email created.';
END
GO

-- Index on Policy Number
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Policies_PolicyNumber')
BEGIN
    CREATE INDEX IX_Policies_PolicyNumber ON Policies(PolicyNumber);
    PRINT 'Index IX_Policies_PolicyNumber created.';
END
GO

-- Index on Policy UserID
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Policies_UserID')
BEGIN
    CREATE INDEX IX_Policies_UserID ON Policies(UserID);
    PRINT 'Index IX_Policies_UserID created.';
END
GO

-- Index on Payment PolicyID
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Payments_PolicyID')
BEGIN
    CREATE INDEX IX_Payments_PolicyID ON Payments(PolicyID);
    PRINT 'Index IX_Payments_PolicyID created.';
END
GO

-- Index on Payment TransactionID
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Payments_TransactionID')
BEGIN
    CREATE UNIQUE INDEX IX_Payments_TransactionID ON Payments(TransactionID) WHERE TransactionID IS NOT NULL;
    PRINT 'Index IX_Payments_TransactionID created.';
END
GO

-- Index on Loan PolicyID
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Loans_PolicyID')
BEGIN
    CREATE INDEX IX_Loans_PolicyID ON Loans(PolicyID);
    PRINT 'Index IX_Loans_PolicyID created.';
END
GO

-- Index on Motor Registration Number
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_MotorInsurance_RegistrationNumber')
BEGIN
    CREATE UNIQUE INDEX IX_MotorInsurance_RegistrationNumber ON MotorInsurance(RegistrationNumber);
    PRINT 'Index IX_MotorInsurance_RegistrationNumber created.';
END
GO

PRINT 'All tables and indexes created successfully!';
GO
