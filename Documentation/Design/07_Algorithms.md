# Algorithms

---

## 1. User Registration Algorithm

**Purpose:** Register a new user in the system

**Input:** FirstName, LastName, Email, Password, Phone, Address, DateOfBirth, Gender

**Output:** Success/Failure message with UserID

**Algorithm:**
```
BEGIN
1. Validate input fields
   - Check all required fields are not empty
   - Validate email format
   - Validate password strength (min 8 chars, uppercase, lowercase, number)
   - Validate phone number format
   - Validate date of birth (age >= 18)

2. Check if email already exists
   IF email exists in database THEN
      RETURN "Email already registered"
   END IF

3. Hash the password using secure hashing algorithm (bcrypt/SHA256)

4. Insert user record into User table
   - Set CreatedDate = Current DateTime
   - Set IsActive = True
   - Set Role = 'User'

5. Generate UserID

6. Send confirmation email to user

7. RETURN "Registration successful" with UserID
END
```

**Time Complexity:** O(1)

---

## 2. User Login Algorithm

**Purpose:** Authenticate user credentials

**Input:** Email, Password

**Output:** Success/Failure with user session

**Algorithm:**
```
BEGIN
1. Validate input
   - Check email and password are not empty
   - Validate email format

2. Query database for user with given email
   IF user not found THEN
      RETURN "Invalid credentials"
   END IF

3. Check if user account is active
   IF IsActive = False THEN
      RETURN "Account is deactivated"
   END IF

4. Verify password
   - Hash the input password
   - Compare with stored hashed password
   IF passwords don't match THEN
      RETURN "Invalid credentials"
   END IF

5. Create user session
   - Generate session token
   - Store session in server/database
   - Set session expiry (30 minutes)

6. RETURN "Login successful" with session token and user details
END
```

**Time Complexity:** O(1)

---

## 3. Premium Calculator Algorithm

**Purpose:** Calculate insurance premium based on policy type and parameters

**Input:** PolicyType, CoverageAmount, TermPeriod, Age, AdditionalParams

**Output:** Premium amount (monthly and yearly)

### 3.1 Life Insurance Premium Calculation

**Algorithm:**
```
BEGIN
1. Get input parameters:
   - CoverageAmount (C)
   - TermPeriod in years (T)
   - Age (A)
   - SmokingStatus (S)
   - HealthStatus (H)

2. Calculate base rate per 1000 of coverage
   IF Age < 30 THEN
      BaseRate = 0.5
   ELSE IF Age >= 30 AND Age < 40 THEN
      BaseRate = 0.8
   ELSE IF Age >= 40 AND Age < 50 THEN
      BaseRate = 1.2
   ELSE IF Age >= 50 AND Age < 60 THEN
      BaseRate = 1.8
   ELSE
      BaseRate = 2.5
   END IF

3. Apply smoking factor
   IF SmokingStatus = True THEN
      SmokingFactor = 1.5
   ELSE
      SmokingFactor = 1.0
   END IF

4. Apply health factor
   IF HealthStatus = "Excellent" THEN
      HealthFactor = 0.9
   ELSE IF HealthStatus = "Good" THEN
      HealthFactor = 1.0
   ELSE IF HealthStatus = "Fair" THEN
      HealthFactor = 1.2
   ELSE
      HealthFactor = 1.5
   END IF

5. Calculate yearly premium
   YearlyPremium = (C / 1000) * BaseRate * SmokingFactor * HealthFactor

6. Calculate monthly premium
   MonthlyPremium = YearlyPremium / 12

7. RETURN MonthlyPremium, YearlyPremium
END
```

### 3.2 Medical Insurance Premium Calculation

**Algorithm:**
```
BEGIN
1. Get input parameters:
   - CoverageAmount (C)
   - Age (A)
   - PreExistingConditions (P)
   - FamilyMembersCount (F)
   - CoverageType (Individual/Family)

2. Calculate base rate
   IF Age < 25 THEN
      BaseRate = 0.02
   ELSE IF Age >= 25 AND Age < 35 THEN
      BaseRate = 0.03
   ELSE IF Age >= 35 AND Age < 45 THEN
      BaseRate = 0.04
   ELSE IF Age >= 45 AND Age < 55 THEN
      BaseRate = 0.06
   ELSE
      BaseRate = 0.08
   END IF

3. Apply pre-existing condition factor
   IF P is not empty THEN
      ConditionFactor = 1.3
   ELSE
      ConditionFactor = 1.0
   END IF

4. Apply family coverage factor
   IF CoverageType = "Family" THEN
      FamilyFactor = 1 + (F * 0.3)
   ELSE
      FamilyFactor = 1.0
   END IF

5. Calculate yearly premium
   YearlyPremium = C * BaseRate * ConditionFactor * FamilyFactor

6. Calculate monthly premium
   MonthlyPremium = YearlyPremium / 12

7. RETURN MonthlyPremium, YearlyPremium
END
```

### 3.3 Motor Insurance Premium Calculation

**Algorithm:**
```
BEGIN
1. Get input parameters:
   - VehicleValue (V)
   - VehicleType (Car/Bike/Truck)
   - VehicleAge (calculated from VehicleYear)
   - CoverageAmount (C)

2. Calculate base rate based on vehicle type
   IF VehicleType = "Bike" THEN
      BaseRate = 0.02
   ELSE IF VehicleType = "Car" THEN
      BaseRate = 0.03
   ELSE IF VehicleType = "Truck" THEN
      BaseRate = 0.04
   END IF

3. Apply vehicle age factor
   IF VehicleAge < 2 THEN
      AgeFactor = 1.0
   ELSE IF VehicleAge >= 2 AND VehicleAge < 5 THEN
      AgeFactor = 1.2
   ELSE IF VehicleAge >= 5 AND VehicleAge < 10 THEN
      AgeFactor = 1.5
   ELSE
      AgeFactor = 2.0
   END IF

4. Calculate yearly premium
   YearlyPremium = V * BaseRate * AgeFactor

5. Calculate monthly premium
   MonthlyPremium = YearlyPremium / 12

6. RETURN MonthlyPremium, YearlyPremium
END
```

### 3.4 Home Insurance Premium Calculation

**Algorithm:**
```
BEGIN
1. Get input parameters:
   - PropertyValue (P)
   - PropertyType (House/Apartment/Villa)
   - ConstructionType (Concrete/Wood/Mixed)
   - YearBuilt (Y)
   - SecurityFeatures (S)

2. Calculate base rate based on property type
   IF PropertyType = "Apartment" THEN
      BaseRate = 0.005
   ELSE IF PropertyType = "House" THEN
      BaseRate = 0.008
   ELSE IF PropertyType = "Villa" THEN
      BaseRate = 0.01
   END IF

3. Apply construction type factor
   IF ConstructionType = "Concrete" THEN
      ConstructionFactor = 1.0
   ELSE IF ConstructionType = "Mixed" THEN
      ConstructionFactor = 1.2
   ELSE IF ConstructionType = "Wood" THEN
      ConstructionFactor = 1.5
   END IF

4. Apply age factor
   PropertyAge = CurrentYear - Y
   IF PropertyAge < 5 THEN
      AgeFactor = 1.0
   ELSE IF PropertyAge >= 5 AND PropertyAge < 15 THEN
      AgeFactor = 1.1
   ELSE IF PropertyAge >= 15 AND PropertyAge < 30 THEN
      AgeFactor = 1.3
   ELSE
      AgeFactor = 1.5
   END IF

5. Apply security discount
   IF S contains "Alarm" OR "CCTV" OR "Security Guard" THEN
      SecurityDiscount = 0.9
   ELSE
      SecurityDiscount = 1.0
   END IF

6. Calculate yearly premium
   YearlyPremium = P * BaseRate * ConstructionFactor * AgeFactor * SecurityDiscount

7. Calculate monthly premium
   MonthlyPremium = YearlyPremium / 12

8. RETURN MonthlyPremium, YearlyPremium
END
```

**Time Complexity:** O(1) for all premium calculations

---

## 4. Policy Application Algorithm

**Purpose:** Process insurance policy application

**Input:** UserID, PolicyType, PolicyDetails, CoverageAmount, TermPeriod

**Output:** PolicyID and application status

**Algorithm:**
```
BEGIN
1. Validate user authentication
   IF user not logged in THEN
      RETURN "Please login first"
   END IF

2. Validate input data
   - Check all required fields
   - Validate coverage amount (min and max limits)
   - Validate term period

3. Calculate premium using Premium Calculator Algorithm
   Premium = CalculatePremium(PolicyType, CoverageAmount, TermPeriod, UserDetails)

4. Generate unique policy number
   PolicyNumber = "POL" + PolicyType[0] + CurrentYear + RandomNumber(6)

5. Insert into Policy table
   - Set Status = "Pending"
   - Set ApplicationDate = Current DateTime
   - Store calculated premium

6. Insert into specific insurance table based on PolicyType
   IF PolicyType = "Life" THEN
      Insert into LifeInsurance table
   ELSE IF PolicyType = "Medical" THEN
      Insert into MedicalInsurance table
   ELSE IF PolicyType = "Motor" THEN
      Insert into MotorInsurance table
   ELSE IF PolicyType = "Home" THEN
      Insert into HomeInsurance table
   END IF

7. Send confirmation email to user

8. RETURN PolicyID, PolicyNumber, "Application submitted successfully"
END
```

**Time Complexity:** O(1)

---

## 5. Loan Eligibility Check Algorithm

**Purpose:** Check if policyholder is eligible for loan

**Input:** PolicyID, RequestedLoanAmount

**Output:** Eligible/Not Eligible with maximum loan amount

**Algorithm:**
```
BEGIN
1. Get policy details from database
   IF policy not found THEN
      RETURN "Invalid policy"
   END IF

2. Check policy status
   IF Status != "Active" THEN
      RETURN "Policy must be active"
   END IF

3. Check policy age (minimum 3 years)
   PolicyAge = CurrentDate - StartDate
   IF PolicyAge < 3 years THEN
      RETURN "Policy must be at least 3 years old"
   END IF

4. Calculate surrender value
   TotalPremiumPaid = PremiumAmount * (PolicyAge in months)
   SurrenderValue = TotalPremiumPaid * 0.7  // 70% of premiums paid

5. Calculate maximum loan amount (90% of surrender value)
   MaxLoanAmount = SurrenderValue * 0.9

6. Check if requested amount is within limit
   IF RequestedLoanAmount > MaxLoanAmount THEN
      RETURN "Not eligible", MaxLoanAmount
   END IF

7. Check for existing active loans
   ActiveLoans = Count loans where PolicyID = input AND Status = "Approved"
   IF ActiveLoans > 0 THEN
      RETURN "Existing loan must be closed first"
   END IF

8. RETURN "Eligible", MaxLoanAmount
END
```

**Time Complexity:** O(1)

---

## 6. Payment Processing Algorithm

**Purpose:** Process premium or loan payment

**Input:** PolicyID, Amount, PaymentMethod, PaymentType

**Output:** Transaction status

**Algorithm:**
```
BEGIN
1. Validate input
   - Check PolicyID exists
   - Validate amount > 0
   - Validate payment method

2. Get policy details
   Policy = GetPolicyByID(PolicyID)

3. Verify payment amount
   IF PaymentType = "Premium" THEN
      IF Amount != Policy.PremiumAmount THEN
         RETURN "Invalid premium amount"
      END IF
   END IF

4. Generate transaction ID
   TransactionID = "TXN" + CurrentTimestamp + RandomNumber(4)

5. Call payment gateway API
   Response = PaymentGateway.ProcessPayment(Amount, PaymentMethod, TransactionID)

6. IF Response.Status = "Success" THEN
      - Insert payment record with Status = "Success"
      - Update policy status if needed
      - Generate receipt
      - Send confirmation email
      RETURN "Payment successful", TransactionID
   ELSE
      - Insert payment record with Status = "Failed"
      - Log error details
      RETURN "Payment failed", Response.ErrorMessage
   END IF
END
```

**Time Complexity:** O(1)

---

## 7. Search Policy Algorithm

**Purpose:** Search policies by various criteria

**Input:** SearchCriteria (PolicyNumber, UserID, PolicyType, Status)

**Output:** List of matching policies

**Algorithm:**
```
BEGIN
1. Initialize query
   Query = "SELECT * FROM Policy WHERE 1=1"

2. Add filters based on search criteria
   IF PolicyNumber is provided THEN
      Query += " AND PolicyNumber = @PolicyNumber"
   END IF

   IF UserID is provided THEN
      Query += " AND UserID = @UserID"
   END IF

   IF PolicyType is provided THEN
      Query += " AND PolicyType = @PolicyType"
   END IF

   IF Status is provided THEN
      Query += " AND Status = @Status"
   END IF

3. Add sorting
   Query += " ORDER BY ApplicationDate DESC"

4. Execute query and get results
   Results = ExecuteQuery(Query)

5. RETURN Results
END
```

**Time Complexity:** O(n) where n is number of matching records

---

**Prepared By:** _________________________

**Date:** _________________________

**Reviewed By:** _________________________

**Date:** _________________________
