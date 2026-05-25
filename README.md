# Online Insurance Management System

## Project Overview

A comprehensive web-based insurance management system built with ASP.NET Core that provides online insurance services for Life, Medical, Motor, and Home insurance.

---

## Features

### For Users
- User registration and authentication
- View insurance policy information (Life, Medical, Motor, Home)
- Premium calculator with dynamic calculations
- Apply for insurance policies
- View and manage personal policies
- Apply for loans against policies
- Online premium payments
- Payment history tracking

### For Administrators
- Dashboard with statistics
- User management (activate/deactivate accounts)
- Policy application approval/rejection
- Loan application approval/rejection
- Generate reports (policies, revenue, users)
- Manage news and updates

---

## Technology Stack

- **Framework:** ASP.NET Core 8.0
- **Language:** C#
- **Database:** SQL Server
- **ORM:** Entity Framework Core
- **Web Server:** IIS
- **Frontend:** Razor Pages, Bootstrap, JavaScript
- **Authentication:** ASP.NET Core Identity

---

## System Requirements

### Development Environment
- Visual Studio 2022 or later
- .NET 8.0 SDK
- SQL Server 2019 or later
- Windows 10/11 or Windows Server

### Minimum Hardware
- Processor: Pentium 166 or better
- RAM: 128 MB or better (4GB recommended)
- Disk Space: 500 MB

---

## Project Structure

```
InsuranceManagementSystem/
├── Controllers/
│   ├── HomeController.cs
│   ├── AccountController.cs
│   ├── InsuranceController.cs
│   ├── PolicyController.cs
│   ├── CalculatorController.cs
│   ├── LoanController.cs
│   ├── PaymentController.cs
│   └── AdminController.cs
├── Models/
│   ├── User.cs
│   ├── Policy.cs
│   ├── LifeInsurance.cs
│   ├── MedicalInsurance.cs
│   ├── MotorInsurance.cs
│   ├── HomeInsurance.cs
│   ├── Payment.cs
│   ├── Loan.cs
│   └── NewsUpdate.cs
├── Data/
│   └── ApplicationDbContext.cs
├── Views/
│   ├── Home/
│   ├── Account/
│   ├── Insurance/
│   ├── Policy/
│   ├── Calculator/
│   ├── Loan/
│   ├── Payment/
│   ├── Admin/
│   └── Shared/
├── wwwroot/
│   ├── css/
│   ├── js/
│   └── images/
├── Services/
│   ├── PremiumCalculatorService.cs
│   ├── LoanEligibilityService.cs
│   └── EmailService.cs
├── appsettings.json
└── Program.cs
```

---

## Installation Guide

### 1. Install Prerequisites
```bash
# Install .NET 8.0 SDK
# Download from: https://dotnet.microsoft.com/download

# Verify installation
dotnet --version
```

### 2. Clone/Download Project
```bash
# Navigate to project directory
cd C:\Users\HAJI LAPTOP KARACHI\Desktop\insurance
```

### 3. Create Database
```sql
-- Run the database creation script
-- Located in: Database/Scripts/CreateDatabase.sql
```

### 4. Update Connection String
```json
// In appsettings.json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=InsuranceDB;Trusted_Connection=True;"
}
```

### 5. Run Migrations
```bash
dotnet ef database update
```

### 6. Run Application
```bash
dotnet run
```

---

## Database Schema

### Main Tables
- **User** - User accounts and profiles
- **Policy** - Insurance policies (base table)
- **LifeInsurance** - Life insurance specific details
- **MedicalInsurance** - Medical insurance specific details
- **MotorInsurance** - Motor insurance specific details
- **HomeInsurance** - Home insurance specific details
- **Payment** - Payment transactions
- **Loan** - Loan applications and details
- **NewsUpdate** - Company news and updates

See `Documentation/Design/06_ER_Diagrams.md` for detailed schema.

---

## Premium Calculation Logic

### Life Insurance
- Based on: Age, Coverage Amount, Term Period, Smoking Status, Health Status
- Formula: (Coverage/1000) × BaseRate × SmokingFactor × HealthFactor

### Medical Insurance
- Based on: Age, Coverage Amount, Pre-existing Conditions, Family Members
- Formula: Coverage × BaseRate × ConditionFactor × FamilyFactor

### Motor Insurance
- Based on: Vehicle Value, Vehicle Type, Vehicle Age
- Formula: VehicleValue × BaseRate × AgeFactor

### Home Insurance
- Based on: Property Value, Property Type, Construction Type, Age, Security
- Formula: PropertyValue × BaseRate × ConstructionFactor × AgeFactor × SecurityDiscount

See `Documentation/Design/07_Algorithms.md` for detailed algorithms.

---

## Testing

### Unit Tests
```bash
# Run all tests
dotnet test

# Run with coverage
dotnet test /p:CollectCoverage=true
```

### Test Coverage Target
- Minimum: 80%
- Models: 90%+
- Controllers: 80%+
- Services: 85%+

---

## Deployment to IIS

### 1. Publish Application
```bash
dotnet publish -c Release -o ./publish
```

### 2. Configure IIS
- Create new website in IIS
- Point to publish folder
- Set application pool to .NET Core
- Configure SSL certificate

### 3. Update Connection String
- Use production database connection string
- Enable connection string encryption

---

## Security Features

- Password hashing using bcrypt
- SQL injection prevention via parameterized queries
- XSS protection
- CSRF tokens
- SSL/TLS encryption
- Role-based access control
- Session timeout (30 minutes)

---

## Default Admin Account

**Email:** admin@insurance.com  
**Password:** Admin@123  
*(Change immediately after first login)*

---

## API Endpoints (if applicable)

### Authentication
- POST `/api/account/register` - Register new user
- POST `/api/account/login` - User login
- POST `/api/account/logout` - User logout

### Premium Calculator
- POST `/api/calculator/calculate` - Calculate premium

### Policies
- GET `/api/policy/user/{userId}` - Get user policies
- POST `/api/policy/apply` - Apply for policy

---

## Documentation

Complete project documentation is available in the `Documentation/` folder:

1. Certificate of Completion
2. Table of Contents
3. Problem Definition
4. Customer Requirement Specification
5. Project Plan
6. E-R Diagrams
7. Algorithms
8. GUI Standards Document
9. Interface Design Document
10. Task Sheet
11. Project Review and Monitoring Report
12. Unit Testing Check List
13. Final Check List

---

## Status Mails

### First Status Mail (Day 10)
- Subject: STATUS: Insurance Management System - Progress Update 1
- Include: Completed tasks, current progress, challenges, next steps

### Second Status Mail (Day 27)
- Subject: STATUS: Insurance Management System - Progress Update 2
- Include: Overall progress, testing status, deployment readiness

### Final Submission
- Subject: SUBMISSION: Insurance Management System - Final Project
- Include: All documentation, source code, database scripts

---

## Support and Contact

For doubts or clarifications during development:
- Subject: DOUBT: Insurance Management System - [Your Question]
- Contact: eProjects Team

---

## License

This is an educational project developed as part of Aptech eProject curriculum.

---

## Contributors

**Developer:** [Your Name]  
**Student ID:** [Your ID]  
**Course:** [Your Course]  
**Center:** [Your Center]  

---

## Project Timeline

- **Start Date:** [Date]
- **Expected Completion:** 30 days
- **Submission Date:** [Date]

---

## Acknowledgments

- Aptech eProjects Team
- Faculty Mentor: [Name]
- Project Guide: [Name]

---

**Last Updated:** [Date]
