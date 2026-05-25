-- =============================================
-- Insert Sample Data Script
-- =============================================

USE InsuranceDB;
GO

-- =============================================
-- Insert Admin User
-- =============================================
-- Password: Admin@123 (hashed - you'll need to hash this in your application)
INSERT INTO Users (FirstName, LastName, Email, Password, Phone, DateOfBirth, Gender, Role, IsActive)
VALUES
('Admin', 'User', 'admin@insurance.com', 'HASHED_PASSWORD_HERE', '1234567890', '1990-01-01', 'Male', 'Admin', 1);

PRINT 'Admin user inserted.';
GO

-- =============================================
-- Insert Sample Users
-- =============================================
INSERT INTO Users (FirstName, LastName, Email, Password, Phone, Address, DateOfBirth, Gender, Role, IsActive)
VALUES
('John', 'Doe', 'john.doe@email.com', 'HASHED_PASSWORD', '9876543210', '123 Main St, City', '1985-05-15', 'Male', 'User', 1),
('Jane', 'Smith', 'jane.smith@email.com', 'HASHED_PASSWORD', '9876543211', '456 Oak Ave, City', '1990-08-20', 'Female', 'User', 1),
('Robert', 'Johnson', 'robert.j@email.com', 'HASHED_PASSWORD', '9876543212', '789 Pine Rd, City', '1982-03-10', 'Male', 'User', 1);

PRINT 'Sample users inserted.';
GO

-- =============================================
-- Insert Sample News Updates
-- =============================================
INSERT INTO NewsUpdates (Title, Content, CreatedBy, IsActive)
VALUES
('Welcome to Our Insurance Portal', 'We are pleased to announce the launch of our new online insurance management system. Now you can manage all your insurance needs from the comfort of your home.', 1, 1),
('New Life Insurance Plans', 'Introducing our new comprehensive life insurance plans with enhanced coverage and competitive premiums. Contact us to learn more.', 1, 1),
('Medical Insurance Updates', 'We have expanded our network of hospitals. Check out the updated list of network hospitals on our website.', 1, 1);

PRINT 'Sample news updates inserted.';
GO

-- =============================================
-- Insert Sample Policies (Optional)
-- =============================================
-- Note: You may want to add sample policies for testing
-- Uncomment and modify as needed

/*
INSERT INTO Policies (UserID, PolicyNumber, PolicyType, CoverageAmount, TermPeriod, PremiumAmount, StartDate, EndDate, Status, ApprovalDate, ApprovedBy)
VALUES
(2, 'POLL2024000001', 'Life', 50000.00, 20, 200.00, '2024-01-01', '2044-01-01', 'Active', '2024-01-01', 1);

INSERT INTO LifeInsurance (PolicyID, Age, Height, Weight, HealthStatus, SmokingStatus, Occupation, Nominee, NomineeRelation)
VALUES
(1, 39, 175.00, 75.00, 'Good', 0, 'Software Engineer', 'Jane Doe', 'Spouse');
*/

PRINT 'Sample data insertion completed!';
GO

-- =============================================
-- Verify Data
-- =============================================
SELECT 'Users' AS TableName, COUNT(*) AS RecordCount FROM Users
UNION ALL
SELECT 'Policies', COUNT(*) FROM Policies
UNION ALL
SELECT 'LifeInsurance', COUNT(*) FROM LifeInsurance
UNION ALL
SELECT 'MedicalInsurance', COUNT(*) FROM MedicalInsurance
UNION ALL
SELECT 'MotorInsurance', COUNT(*) FROM MotorInsurance
UNION ALL
SELECT 'HomeInsurance', COUNT(*) FROM HomeInsurance
UNION ALL
SELECT 'Payments', COUNT(*) FROM Payments
UNION ALL
SELECT 'Loans', COUNT(*) FROM Loans
UNION ALL
SELECT 'NewsUpdates', COUNT(*) FROM NewsUpdates;
GO
