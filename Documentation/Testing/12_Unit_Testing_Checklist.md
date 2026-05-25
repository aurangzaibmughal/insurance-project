# Unit Testing Check List

---

## Project: Online Insurance Management System

**Tester Name:** _________________________

**Testing Date:** _________________________

**Environment:** ☐ Development  ☐ Testing  ☐ Staging

---

## 1. Testing Overview

### 1.1 Testing Objectives
- Verify individual units of code work correctly
- Identify bugs early in development
- Ensure code quality and reliability
- Validate business logic

### 1.2 Testing Approach
- **Framework:** xUnit / NUnit / MSTest
- **Mocking:** Moq
- **Code Coverage Tool:** Coverlet
- **Target Coverage:** 80%

---

## 2. Model Testing

### 2.1 User Model Tests

| Test Case ID | Test Description | Input | Expected Output | Status | Notes |
|--------------|-----------------|-------|-----------------|--------|-------|
| UT-M-001 | Validate user creation with valid data | Valid user data | User object created | ☐ Pass ☐ Fail | |
| UT-M-002 | Validate email format | Invalid email | Validation error | ☐ Pass ☐ Fail | |
| UT-M-003 | Validate password strength | Weak password | Validation error | ☐ Pass ☐ Fail | |
| UT-M-004 | Validate age requirement (18+) | Age < 18 | Validation error | ☐ Pass ☐ Fail | |
| UT-M-005 | Validate required fields | Missing fields | Validation error | ☐ Pass ☐ Fail | |

---

### 2.2 Policy Model Tests

| Test Case ID | Test Description | Input | Expected Output | Status | Notes |
|--------------|-----------------|-------|-----------------|--------|-------|
| UT-M-006 | Create policy with valid data | Valid policy data | Policy created | ☐ Pass ☐ Fail | |
| UT-M-007 | Validate coverage amount range | Invalid amount | Validation error | ☐ Pass ☐ Fail | |
| UT-M-008 | Validate term period | Invalid term | Validation error | ☐ Pass ☐ Fail | |
| UT-M-009 | Validate policy number uniqueness | Duplicate number | Error | ☐ Pass ☐ Fail | |
| UT-M-010 | Test policy status transitions | Status change | Updated status | ☐ Pass ☐ Fail | |

---

### 2.3 Insurance-Specific Model Tests

| Test Case ID | Test Description | Input | Expected Output | Status | Notes |
|--------------|-----------------|-------|-----------------|--------|-------|
| UT-M-011 | Create LifeInsurance record | Valid data | Record created | ☐ Pass ☐ Fail | |
| UT-M-012 | Create MedicalInsurance record | Valid data | Record created | ☐ Pass ☐ Fail | |
| UT-M-013 | Create MotorInsurance record | Valid data | Record created | ☐ Pass ☐ Fail | |
| UT-M-014 | Create HomeInsurance record | Valid data | Record created | ☐ Pass ☐ Fail | |
| UT-M-015 | Validate vehicle registration uniqueness | Duplicate reg | Error | ☐ Pass ☐ Fail | |

---

### 2.4 Payment Model Tests

| Test Case ID | Test Description | Input | Expected Output | Status | Notes |
|--------------|-----------------|-------|-----------------|--------|-------|
| UT-M-016 | Create payment record | Valid data | Payment created | ☐ Pass ☐ Fail | |
| UT-M-017 | Validate payment amount | Amount <= 0 | Validation error | ☐ Pass ☐ Fail | |
| UT-M-018 | Validate transaction ID uniqueness | Duplicate ID | Error | ☐ Pass ☐ Fail | |

---

### 2.5 Loan Model Tests

| Test Case ID | Test Description | Input | Expected Output | Status | Notes |
|--------------|-----------------|-------|-----------------|--------|-------|
| UT-M-019 | Create loan record | Valid data | Loan created | ☐ Pass ☐ Fail | |
| UT-M-020 | Validate loan amount | Amount <= 0 | Validation error | ☐ Pass ☐ Fail | |
| UT-M-021 | Validate interest rate | Invalid rate | Validation error | ☐ Pass ☐ Fail | |

---

## 3. Business Logic Testing

### 3.1 Premium Calculator Tests

| Test Case ID | Test Description | Input | Expected Output | Status | Notes |
|--------------|-----------------|-------|-----------------|--------|-------|
| UT-BL-001 | Calculate Life Insurance premium (Age < 30) | Age=25, Coverage=50000, Term=20 | Correct premium | ☐ Pass ☐ Fail | |
| UT-BL-002 | Calculate Life Insurance premium (Age 30-40) | Age=35, Coverage=50000, Term=20 | Correct premium | ☐ Pass ☐ Fail | |
| UT-BL-003 | Calculate Life Insurance premium (Smoker) | Smoker=true | Higher premium | ☐ Pass ☐ Fail | |
| UT-BL-004 | Calculate Medical Insurance premium | Age=30, Coverage=100000 | Correct premium | ☐ Pass ☐ Fail | |
| UT-BL-005 | Calculate Medical Insurance (Family) | Family=4 members | Correct premium | ☐ Pass ☐ Fail | |
| UT-BL-006 | Calculate Motor Insurance premium | Vehicle value=20000 | Correct premium | ☐ Pass ☐ Fail | |
| UT-BL-007 | Calculate Motor Insurance (Old vehicle) | Vehicle age=8 years | Higher premium | ☐ Pass ☐ Fail | |
| UT-BL-008 | Calculate Home Insurance premium | Property value=200000 | Correct premium | ☐ Pass ☐ Fail | |
| UT-BL-009 | Calculate Home Insurance (Security discount) | Has security | Lower premium | ☐ Pass ☐ Fail | |
| UT-BL-010 | Test premium calculation with zero coverage | Coverage=0 | Error | ☐ Pass ☐ Fail | |

---

### 3.2 Loan Eligibility Tests

| Test Case ID | Test Description | Input | Expected Output | Status | Notes |
|--------------|-----------------|-------|-----------------|--------|-------|
| UT-BL-011 | Check eligibility (Valid policy) | Active policy, 3+ years | Eligible | ☐ Pass ☐ Fail | |
| UT-BL-012 | Check eligibility (New policy) | Policy < 3 years | Not eligible | ☐ Pass ☐ Fail | |
| UT-BL-013 | Check eligibility (Inactive policy) | Inactive policy | Not eligible | ☐ Pass ☐ Fail | |
| UT-BL-014 | Calculate maximum loan amount | Surrender value=10000 | Max loan=9000 | ☐ Pass ☐ Fail | |
| UT-BL-015 | Check existing loan | Active loan exists | Not eligible | ☐ Pass ☐ Fail | |

---

### 3.3 Authentication Tests

| Test Case ID | Test Description | Input | Expected Output | Status | Notes |
|--------------|-----------------|-------|-----------------|--------|-------|
| UT-BL-016 | User registration with valid data | Valid user data | Success | ☐ Pass ☐ Fail | |
| UT-BL-017 | User registration with duplicate email | Existing email | Error | ☐ Pass ☐ Fail | |
| UT-BL-018 | User login with valid credentials | Correct email/password | Success | ☐ Pass ☐ Fail | |
| UT-BL-019 | User login with invalid credentials | Wrong password | Failure | ☐ Pass ☐ Fail | |
| UT-BL-020 | Password hashing | Plain password | Hashed password | ☐ Pass ☐ Fail | |
| UT-BL-021 | Password verification | Correct password | True | ☐ Pass ☐ Fail | |
| UT-BL-022 | Password verification | Wrong password | False | ☐ Pass ☐ Fail | |

---

## 4. Controller Testing

### 4.1 Account Controller Tests

| Test Case ID | Test Description | Input | Expected Output | Status | Notes |
|--------------|-----------------|-------|-----------------|--------|-------|
| UT-C-001 | GET Register page | - | View returned | ☐ Pass ☐ Fail | |
| UT-C-002 | POST Register with valid data | Valid model | Redirect to login | ☐ Pass ☐ Fail | |
| UT-C-003 | POST Register with invalid data | Invalid model | Return view with errors | ☐ Pass ☐ Fail | |
| UT-C-004 | GET Login page | - | View returned | ☐ Pass ☐ Fail | |
| UT-C-005 | POST Login with valid credentials | Valid credentials | Redirect to dashboard | ☐ Pass ☐ Fail | |
| UT-C-006 | POST Login with invalid credentials | Invalid credentials | Return view with error | ☐ Pass ☐ Fail | |
| UT-C-007 | Logout | - | Redirect to home | ☐ Pass ☐ Fail | |

---

### 4.2 Policy Controller Tests

| Test Case ID | Test Description | Input | Expected Output | Status | Notes |
|--------------|-----------------|-------|-----------------|--------|-------|
| UT-C-008 | GET Life Insurance page | - | View returned | ☐ Pass ☐ Fail | |
| UT-C-009 | GET Medical Insurance page | - | View returned | ☐ Pass ☐ Fail | |
| UT-C-010 | GET Motor Insurance page | - | View returned | ☐ Pass ☐ Fail | |
| UT-C-011 | GET Home Insurance page | - | View returned | ☐ Pass ☐ Fail | |
| UT-C-012 | GET My Policies (authenticated) | User ID | List of policies | ☐ Pass ☐ Fail | |
| UT-C-013 | GET My Policies (not authenticated) | - | Redirect to login | ☐ Pass ☐ Fail | |
| UT-C-014 | GET Policy Details | Policy ID | Policy details | ☐ Pass ☐ Fail | |
| UT-C-015 | POST Apply Policy with valid data | Valid model | Success | ☐ Pass ☐ Fail | |
| UT-C-016 | POST Apply Policy with invalid data | Invalid model | Return view with errors | ☐ Pass ☐ Fail | |

---

### 4.3 Calculator Controller Tests

| Test Case ID | Test Description | Input | Expected Output | Status | Notes |
|--------------|-----------------|-------|-----------------|--------|-------|
| UT-C-017 | GET Calculator page | - | View returned | ☐ Pass ☐ Fail | |
| UT-C-018 | POST Calculate with valid data | Valid input | Premium amount | ☐ Pass ☐ Fail | |
| UT-C-019 | POST Calculate with invalid data | Invalid input | Error message | ☐ Pass ☐ Fail | |

---

### 4.4 Loan Controller Tests

| Test Case ID | Test Description | Input | Expected Output | Status | Notes |
|--------------|-----------------|-------|-----------------|--------|-------|
| UT-C-020 | GET Loan Application page | - | View returned | ☐ Pass ☐ Fail | |
| UT-C-021 | POST Apply Loan (eligible) | Valid data | Success | ☐ Pass ☐ Fail | |
| UT-C-022 | POST Apply Loan (not eligible) | Invalid policy | Error message | ☐ Pass ☐ Fail | |
| UT-C-023 | GET Loan Status | User ID | Loan list | ☐ Pass ☐ Fail | |

---

### 4.5 Payment Controller Tests

| Test Case ID | Test Description | Input | Expected Output | Status | Notes |
|--------------|-----------------|-------|-----------------|--------|-------|
| UT-C-024 | GET Payment page | Policy ID | View returned | ☐ Pass ☐ Fail | |
| UT-C-025 | POST Process Payment (success) | Valid payment | Success message | ☐ Pass ☐ Fail | |
| UT-C-026 | POST Process Payment (failure) | Invalid payment | Error message | ☐ Pass ☐ Fail | |
| UT-C-027 | GET Payment History | User ID | Payment list | ☐ Pass ☐ Fail | |

---

### 4.6 Admin Controller Tests

| Test Case ID | Test Description | Input | Expected Output | Status | Notes |
|--------------|-----------------|-------|-----------------|--------|-------|
| UT-C-028 | GET Admin Dashboard (admin) | - | View returned | ☐ Pass ☐ Fail | |
| UT-C-029 | GET Admin Dashboard (non-admin) | - | Unauthorized | ☐ Pass ☐ Fail | |
| UT-C-030 | GET Manage Users | - | User list | ☐ Pass ☐ Fail | |
| UT-C-031 | POST Approve Policy | Policy ID | Success | ☐ Pass ☐ Fail | |
| UT-C-032 | POST Reject Policy | Policy ID | Success | ☐ Pass ☐ Fail | |
| UT-C-033 | POST Approve Loan | Loan ID | Success | ☐ Pass ☐ Fail | |
| UT-C-034 | POST Reject Loan | Loan ID | Success | ☐ Pass ☐ Fail | |

---

## 5. Repository/Data Access Tests

| Test Case ID | Test Description | Input | Expected Output | Status | Notes |
|--------------|-----------------|-------|-----------------|--------|-------|
| UT-R-001 | Add user to database | User object | User added | ☐ Pass ☐ Fail | |
| UT-R-002 | Get user by ID | User ID | User object | ☐ Pass ☐ Fail | |
| UT-R-003 | Get user by email | Email | User object | ☐ Pass ☐ Fail | |
| UT-R-004 | Update user | Updated user | Success | ☐ Pass ☐ Fail | |
| UT-R-005 | Delete user | User ID | Success | ☐ Pass ☐ Fail | |
| UT-R-006 | Add policy to database | Policy object | Policy added | ☐ Pass ☐ Fail | |
| UT-R-007 | Get policies by user ID | User ID | Policy list | ☐ Pass ☐ Fail | |
| UT-R-008 | Get policy by policy number | Policy number | Policy object | ☐ Pass ☐ Fail | |
| UT-R-009 | Update policy status | Policy ID, Status | Success | ☐ Pass ☐ Fail | |
| UT-R-010 | Add payment to database | Payment object | Payment added | ☐ Pass ☐ Fail | |

---

## 6. Validation Tests

| Test Case ID | Test Description | Input | Expected Output | Status | Notes |
|--------------|-----------------|-------|-----------------|--------|-------|
| UT-V-001 | Email validation (valid) | valid@email.com | Valid | ☐ Pass ☐ Fail | |
| UT-V-002 | Email validation (invalid) | invalid-email | Invalid | ☐ Pass ☐ Fail | |
| UT-V-003 | Phone validation (valid) | 1234567890 | Valid | ☐ Pass ☐ Fail | |
| UT-V-004 | Phone validation (invalid) | 123 | Invalid | ☐ Pass ☐ Fail | |
| UT-V-005 | Date validation (future date) | Future date | Invalid | ☐ Pass ☐ Fail | |
| UT-V-006 | Number range validation | Out of range | Invalid | ☐ Pass ☐ Fail | |

---

## 7. Test Summary

### 7.1 Overall Statistics

**Total Test Cases:** _____

**Passed:** _____

**Failed:** _____

**Blocked:** _____

**Not Executed:** _____

**Pass Rate:** _____%

---

### 7.2 Code Coverage

**Overall Coverage:** _____%

**Models Coverage:** _____%

**Controllers Coverage:** _____%

**Services Coverage:** _____%

**Repositories Coverage:** _____%

---

### 7.3 Failed Test Cases

| Test Case ID | Failure Reason | Priority | Assigned To | Status |
|--------------|----------------|----------|-------------|--------|
| | | | | |
| | | | | |

---

### 7.4 Blocked Test Cases

| Test Case ID | Blocking Reason | Expected Resolution Date |
|--------------|-----------------|--------------------------|
| | | |
| | | |

---

## 8. Recommendations

### 8.1 Areas Needing Improvement
- 
- 
- 

### 8.2 Additional Tests Required
- 
- 
- 

---

## 9. Sign-off

**Tested By:** _________________________

**Signature:** _________________________

**Date:** _________________________

---

**Reviewed By:** _________________________

**Signature:** _________________________

**Date:** _________________________
