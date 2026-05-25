# Customer Requirement Specification

---

## 1. Introduction

### 1.1 Purpose
This document specifies the functional and non-functional requirements for the Online Insurance Management System.

### 1.2 Scope
The system will provide online insurance services for Life, Medical, Motor, and Home insurance with features for user management, policy viewing, premium calculation, loan facility, and online payments.

### 1.3 Definitions and Acronyms
- **IMS:** Insurance Management System
- **UI:** User Interface
- **DB:** Database
- **API:** Application Programming Interface

---

## 2. Functional Requirements

### 2.1 User Management

#### FR-1: User Registration
- **Description:** New users must be able to register on the system
- **Input:** Name, Email, Phone, Password, Address
- **Process:** Validate input, check for duplicate email, create user account
- **Output:** Registration confirmation and user ID
- **Priority:** High

#### FR-2: User Login
- **Description:** Registered users must be able to login
- **Input:** Email and Password
- **Process:** Authenticate credentials
- **Output:** Access to user dashboard
- **Priority:** High

#### FR-3: User Profile Management
- **Description:** Users can view and update their profile
- **Input:** Updated user information
- **Process:** Validate and update database
- **Output:** Confirmation message
- **Priority:** Medium

---

### 2.2 Insurance Policy Management

#### FR-4: View Life Insurance Details
- **Description:** Users can view Life Insurance policy details
- **Output:** Policy features, benefits, terms, and conditions
- **Priority:** High

#### FR-5: View Medical Insurance Details
- **Description:** Users can view Medical Insurance policy details
- **Output:** Coverage details (doctor fees, hospital fees, medicine costs)
- **Priority:** High

#### FR-6: View Motor Insurance Details
- **Description:** Users can view Motor Insurance policy details
- **Output:** Vehicle protection coverage details
- **Priority:** High

#### FR-7: View Home Insurance Details
- **Description:** Users can view Home Insurance policy details
- **Output:** Home protection coverage details
- **Priority:** High

#### FR-8: Apply for Insurance Policy
- **Description:** Registered users can apply for insurance policies
- **Input:** Policy type, personal details, coverage amount, term period
- **Process:** Validate input, calculate premium, create policy application
- **Output:** Application confirmation and policy number
- **Priority:** High

---

### 2.3 Premium Calculator

#### FR-9: Calculate Premium
- **Description:** System calculates premium based on term plan
- **Input:** 
  - Insurance type
  - Coverage amount
  - Term period (years)
  - Age of applicant
  - Additional factors (health status for medical, vehicle value for motor, etc.)
- **Process:** Apply premium calculation formula based on insurance type
- **Output:** Premium amount (monthly/yearly)
- **Priority:** High

**Premium Calculation Logic:**
- **Life Insurance:** Based on age, coverage amount, term period, health status
- **Medical Insurance:** Based on age, coverage amount, pre-existing conditions
- **Motor Insurance:** Based on vehicle value, age, model, usage type
- **Home Insurance:** Based on property value, location, construction type

---

### 2.4 Policy Management for Policyholders

#### FR-10: View My Policies
- **Description:** Policyholders can view their active policies
- **Output:** List of policies with details (policy number, type, coverage, premium, status)
- **Priority:** High

#### FR-11: View Policy Details
- **Description:** View detailed information of a specific policy
- **Output:** Complete policy information including payment history
- **Priority:** High

---

### 2.5 Loan Facility

#### FR-12: Apply for Loan
- **Description:** Policyholders can apply for loans against their policies
- **Input:** Policy number, loan amount requested
- **Process:** Validate policy eligibility, check loan limit (typically 80-90% of surrender value)
- **Output:** Loan approval/rejection with details
- **Priority:** Medium

#### FR-13: View Loan Status
- **Description:** View status of loan applications
- **Output:** Loan details (amount, interest rate, repayment schedule, status)
- **Priority:** Medium

---

### 2.6 Payment Management

#### FR-14: Make Premium Payment
- **Description:** Users can pay premiums online
- **Input:** Policy number, payment amount, payment method
- **Process:** Process payment through payment gateway
- **Output:** Payment confirmation and receipt
- **Priority:** High

#### FR-15: View Payment History
- **Description:** View history of all payments made
- **Output:** List of payments with date, amount, status
- **Priority:** Medium

---

### 2.7 Information and Updates

#### FR-16: View Company News and Updates
- **Description:** Display new strategies and subsidiary schemes
- **Output:** Latest news, schemes, and updates from the company
- **Priority:** Low

---

### 2.8 Admin Functions

#### FR-17: Manage Users
- **Description:** Admin can view, activate, deactivate user accounts
- **Priority:** High

#### FR-18: Manage Policies
- **Description:** Admin can approve/reject policy applications
- **Priority:** High

#### FR-19: Manage Loans
- **Description:** Admin can approve/reject loan applications
- **Priority:** Medium

#### FR-20: Generate Reports
- **Description:** Admin can generate various reports (policies sold, revenue, etc.)
- **Priority:** Medium

---

## 3. Non-Functional Requirements

### 3.1 Performance Requirements
- **NFR-1:** System should load pages within 3 seconds
- **NFR-2:** Support at least 100 concurrent users
- **NFR-3:** Database queries should execute within 2 seconds

### 3.2 Security Requirements
- **NFR-4:** Passwords must be encrypted using strong hashing algorithms
- **NFR-5:** Implement SSL/TLS for secure data transmission
- **NFR-6:** Session timeout after 30 minutes of inactivity
- **NFR-7:** Implement role-based access control

### 3.3 Usability Requirements
- **NFR-8:** User interface should be intuitive and easy to navigate
- **NFR-9:** System should provide clear error messages
- **NFR-10:** Support for common web browsers (Chrome, Firefox, Edge)

### 3.4 Reliability Requirements
- **NFR-11:** System uptime of 99.5%
- **NFR-12:** Automatic database backup daily
- **NFR-13:** Error logging and monitoring

### 3.5 Maintainability Requirements
- **NFR-14:** Code should be well-documented with comments
- **NFR-15:** Follow coding standards and best practices
- **NFR-16:** Modular architecture for easy updates

### 3.6 Compatibility Requirements
- **NFR-17:** Compatible with Windows Server and IIS
- **NFR-18:** Support SQL Server database
- **NFR-19:** Responsive design for different screen sizes

---

## 4. System Interfaces

### 4.1 User Interfaces
- Web-based interface accessible through browsers
- Responsive design for desktop and tablet devices

### 4.2 Hardware Interfaces
- Standard web server hardware
- Database server

### 4.3 Software Interfaces
- IIS Web Server
- SQL Server Database
- Payment Gateway API
- Email Service for notifications

### 4.4 Communication Interfaces
- HTTPS protocol for secure communication
- RESTful APIs for internal communication

---

## 5. Assumptions and Dependencies

### 5.1 Assumptions
- Users have basic computer and internet knowledge
- Users have valid email addresses
- Payment gateway services are available

### 5.2 Dependencies
- .NET Framework/Core availability
- SQL Server installation
- IIS Server configuration
- Third-party payment gateway integration
- Email service provider

---

## 6. Approval

**Prepared By:** _________________________

**Date:** _________________________

**Reviewed By:** _________________________

**Date:** _________________________

**Approved By:** _________________________

**Date:** _________________________
