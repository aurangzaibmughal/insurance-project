-- =============================================
-- Insurance Management System Database
-- Create Database Script
-- =============================================

-- Create Database
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'InsuranceDB')
BEGIN
    CREATE DATABASE InsuranceDB;
    PRINT 'Database InsuranceDB created successfully.';
END
ELSE
BEGIN
    PRINT 'Database InsuranceDB already exists.';
END
GO

USE InsuranceDB;
GO

PRINT 'Switched to InsuranceDB database.';
GO
