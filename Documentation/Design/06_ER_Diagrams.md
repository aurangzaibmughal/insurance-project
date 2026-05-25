# E-R Diagrams

---

## 1. Entity-Relationship Model Overview

This document describes the database design for the Online Insurance Management System using Entity-Relationship diagrams.

---

## 2. Entities

### 2.1 User
**Description:** Stores information about registered users

**Attributes:**
- UserID (Primary Key) - INT, Auto-increment
- FirstName - VARCHAR(50), NOT NULL
- LastName - VARCHAR(50), NOT NULL
- Email - VARCHAR(100), UNIQUE, NOT NULL
- Password - VARCHAR(255), NOT NULL (Hashed)
- Phone - VARCHAR(15)
- Address - VARCHAR(255)
- DateOfBirth - DATE
- Gender - VARCHAR(10)
- CreatedDate - DATETIME, DEFAULT CURRENT_TIMESTAMP
- IsActive - BIT, DEFAULT 1
- Role - VARCHAR(20), DEFAULT 'User' (User/Admin)

---

### 2.2 Policy
**Description:** Base information for all insurance policies

**Attributes:**
- PolicyID (Primary Key) - INT, Auto-increment
- UserID (Foreign Key) - INT, References User(UserID)
- PolicyNumber - VARCHAR(50), UNIQUE, NOT NULL
- PolicyType - VARCHAR(20), NOT NULL (Life/Medical/Motor/Home)
- CoverageAmount - DECIMAL(18,2), NOT NULL
- TermPeriod - INT, NOT NULL (in years)
- PremiumAmount - DECIMAL(18,2), NOT NULL
- StartDate - DATE
- EndDate - DATE
- Status - VARCHAR(20), DEFAULT 'Pending' (Pending/Active/Expired/Cancelled)
- ApplicationDate - DATETIME, DEFAULT CURRENT_TIMESTAMP
- ApprovalDate - DATETIME
- ApprovedBy - INT (Foreign Key to User for Admin)

---

### 2.3 LifeInsurance
**Description:** Specific details for Life Insurance policies

**Attributes:**
- LifeInsuranceID (Primary Key) - INT, Auto-increment
- PolicyID (Foreign Key) - INT, References Policy(PolicyID)
- Age - INT, NOT NULL
- Height - DECIMAL(5,2) (in cm)
- Weight - DECIMAL(5,2) (in kg)
- HealthStatus - VARCHAR(50)
- SmokingStatus - BIT
- Occupation - VARCHAR(100)
- Nominee - VARCHAR(100), NOT NULL
- NomineeRelation - VARCHAR(50)

---

### 2.4 MedicalInsurance
**Description:** Specific details for Medical Insurance policies

**Attributes:**
- MedicalInsuranceID (Primary Key) - INT, Auto-increment
- PolicyID (Foreign Key) - INT, References Policy(PolicyID)
- Age - INT, NOT NULL
- PreExistingConditions - VARCHAR(500)
- BloodGroup - VARCHAR(5)
- FamilyMembersCount - INT
- CoverageType - VARCHAR(50) (Individual/Family)

---

### 2.5 MotorInsurance
**Description:** Specific details for Motor Insurance policies

**Attributes:**
- MotorInsuranceID (Primary Key) - INT, Auto-increment
- PolicyID (Foreign Key) - INT, References Policy(PolicyID)
- VehicleType - VARCHAR(50), NOT NULL (Car/Bike/Truck)
- VehicleMake - VARCHAR(50), NOT NULL
- VehicleModel - VARCHAR(50), NOT NULL
- VehicleYear - INT, NOT NULL
- VehicleValue - DECIMAL(18,2), NOT NULL
- RegistrationNumber - VARCHAR(20), UNIQUE, NOT NULL
- ChassisNumber - VARCHAR(50)
- EngineNumber - VARCHAR(50)

---

### 2.6 HomeInsurance
**Description:** Specific details for Home Insurance policies

**Attributes:**
- HomeInsuranceID (Primary Key) - INT, Auto-increment
- PolicyID (Foreign Key) - INT, References Policy(PolicyID)
- PropertyType - VARCHAR(50), NOT NULL (House/Apartment/Villa)
- PropertyValue - DECIMAL(18,2), NOT NULL
- PropertyAddress - VARCHAR(255), NOT NULL
- ConstructionType - VARCHAR(50) (Concrete/Wood/Mixed)
- YearBuilt - INT
- SquareFeet - INT
- SecurityFeatures - VARCHAR(255)

---

### 2.7 Payment
**Description:** Stores payment transactions

**Attributes:**
- PaymentID (Primary Key) - INT, Auto-increment
- PolicyID (Foreign Key) - INT, References Policy(PolicyID)
- UserID (Foreign Key) - INT, References User(UserID)
- Amount - DECIMAL(18,2), NOT NULL
- PaymentDate - DATETIME, DEFAULT CURRENT_TIMESTAMP
- PaymentMethod - VARCHAR(50) (CreditCard/DebitCard/NetBanking/UPI)
- TransactionID - VARCHAR(100), UNIQUE
- Status - VARCHAR(20), DEFAULT 'Pending' (Pending/Success/Failed)
- PaymentType - VARCHAR(20) (Premium/Loan)

---

### 2.8 Loan
**Description:** Stores loan applications against policies

**Attributes:**
- LoanID (Primary Key) - INT, Auto-increment
- PolicyID (Foreign Key) - INT, References Policy(PolicyID)
- UserID (Foreign Key) - INT, References User(UserID)
- LoanAmount - DECIMAL(18,2), NOT NULL
- InterestRate - DECIMAL(5,2)
- LoanTerm - INT (in months)
- ApplicationDate - DATETIME, DEFAULT CURRENT_TIMESTAMP
- ApprovalDate - DATETIME
- Status - VARCHAR(20), DEFAULT 'Pending' (Pending/Approved/Rejected/Closed)
- ApprovedBy - INT (Foreign Key to User for Admin)
- DisbursementDate - DATETIME

---

### 2.9 NewsUpdate
**Description:** Stores company news and updates

**Attributes:**
- NewsID (Primary Key) - INT, Auto-increment
- Title - VARCHAR(200), NOT NULL
- Content - TEXT, NOT NULL
- PublishDate - DATETIME, DEFAULT CURRENT_TIMESTAMP
- IsActive - BIT, DEFAULT 1
- CreatedBy - INT (Foreign Key to User for Admin)

---

## 3. Relationships

### 3.1 User - Policy (One-to-Many)
- One User can have multiple Policies
- Each Policy belongs to one User
- **Relationship:** User (1) ----< (M) Policy

### 3.2 Policy - LifeInsurance (One-to-One)
- One Policy can have one LifeInsurance detail
- Each LifeInsurance belongs to one Policy
- **Relationship:** Policy (1) ---- (1) LifeInsurance

### 3.3 Policy - MedicalInsurance (One-to-One)
- One Policy can have one MedicalInsurance detail
- Each MedicalInsurance belongs to one Policy
- **Relationship:** Policy (1) ---- (1) MedicalInsurance

### 3.4 Policy - MotorInsurance (One-to-One)
- One Policy can have one MotorInsurance detail
- Each MotorInsurance belongs to one Policy
- **Relationship:** Policy (1) ---- (1) MotorInsurance

### 3.5 Policy - HomeInsurance (One-to-One)
- One Policy can have one HomeInsurance detail
- Each HomeInsurance belongs to one Policy
- **Relationship:** Policy (1) ---- (1) HomeInsurance

### 3.6 Policy - Payment (One-to-Many)
- One Policy can have multiple Payments
- Each Payment belongs to one Policy
- **Relationship:** Policy (1) ----< (M) Payment

### 3.7 User - Payment (One-to-Many)
- One User can make multiple Payments
- Each Payment is made by one User
- **Relationship:** User (1) ----< (M) Payment

### 3.8 Policy - Loan (One-to-Many)
- One Policy can have multiple Loans
- Each Loan is against one Policy
- **Relationship:** Policy (1) ----< (M) Loan

### 3.9 User - Loan (One-to-Many)
- One User can apply for multiple Loans
- Each Loan is applied by one User
- **Relationship:** User (1) ----< (M) Loan

---

## 4. E-R Diagram (Text Representation)

```
┌─────────────┐
│    USER     │
├─────────────┤
│ UserID (PK) │
│ FirstName   │
│ LastName    │
│ Email       │
│ Password    │
│ Phone       │
│ Address     │
│ Role        │
└──────┬──────┘
       │ 1
       │
       │ M
┌──────┴──────────┐
│     POLICY      │
├─────────────────┤
│ PolicyID (PK)   │
│ UserID (FK)     │
│ PolicyNumber    │
│ PolicyType      │
│ CoverageAmount  │
│ PremiumAmount   │
│ Status          │
└────┬─┬─┬─┬─────┘
     │ │ │ │
  ┌──┘ │ │ └──┐
  │ 1  │ │  1 │
  │ 1  │ │  1 │
  ▼    ▼ ▼    ▼
┌────┐ ┌────┐ ┌────┐ ┌────┐
│Life│ │Med │ │Mtr │ │Home│
│Ins │ │Ins │ │Ins │ │Ins │
└────┘ └────┘ └────┘ └────┘

     POLICY
       │ 1
       │
       │ M
    ┌──┴────┐
    │       │
    ▼       ▼
┌────────┐ ┌──────┐
│PAYMENT │ │ LOAN │
└────────┘ └──────┘
```

---

## 5. Database Normalization

The database design follows **Third Normal Form (3NF)**:

### First Normal Form (1NF)
- All tables have primary keys
- All attributes contain atomic values
- No repeating groups

### Second Normal Form (2NF)
- Meets 1NF requirements
- All non-key attributes are fully dependent on primary key
- No partial dependencies

### Third Normal Form (3NF)
- Meets 2NF requirements
- No transitive dependencies
- All non-key attributes depend only on primary key

---

## 6. Indexes

**Recommended Indexes for Performance:**

- User.Email (UNIQUE INDEX)
- Policy.PolicyNumber (UNIQUE INDEX)
- Policy.UserID (INDEX)
- Payment.PolicyID (INDEX)
- Payment.TransactionID (UNIQUE INDEX)
- Loan.PolicyID (INDEX)
- MotorInsurance.RegistrationNumber (UNIQUE INDEX)

---

**Prepared By:** _________________________

**Date:** _________________________

**Reviewed By:** _________________________

**Date:** _________________________
