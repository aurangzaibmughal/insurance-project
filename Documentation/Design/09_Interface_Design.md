# Interface Design Document

---

## 1. Introduction

This document describes the user interface design for all pages in the Online Insurance Management System.

---

## 2. Public Pages (Non-Authenticated)

### 2.1 Home Page

**URL:** `/` or `/Home/Index`

**Purpose:** Landing page with overview of insurance services

**Layout:**
```
┌─────────────────────────────────────────┐
│         Navigation Bar                  │
├─────────────────────────────────────────┤
│                                         │
│    Hero Section                         │
│    - Welcome message                    │
│    - Call-to-action buttons             │
│                                         │
├─────────────────────────────────────────┤
│                                         │
│    Insurance Types (4 Cards)            │
│    ┌──────┐ ┌──────┐ ┌──────┐ ┌──────┐│
│    │ Life │ │Medical│ │Motor │ │ Home ││
│    └──────┘ └──────┘ └──────┘ └──────┘│
│                                         │
├─────────────────────────────────────────┤
│    Why Choose Us Section                │
├─────────────────────────────────────────┤
│    Latest News & Updates                │
├─────────────────────────────────────────┤
│         Footer                          │
└─────────────────────────────────────────┘
```

**Components:**
- Hero banner with background image
- 4 insurance type cards with icons
- Features section (3 columns)
- News carousel
- Footer with links

**Actions:**
- Click insurance card → Navigate to insurance details
- Click "Get Started" → Navigate to registration
- Click "Calculate Premium" → Navigate to calculator

---

### 2.2 Life Insurance Page

**URL:** `/Insurance/Life`

**Purpose:** Display Life Insurance information

**Layout:**
```
┌─────────────────────────────────────────┐
│         Navigation Bar                  │
├─────────────────────────────────────────┤
│    Breadcrumb: Home > Life Insurance    │
├─────────────────────────────────────────┤
│                                         │
│    Page Title: Life Insurance           │
│    Icon: ❤                              │
│                                         │
├─────────────────────────────────────────┤
│    Overview Section                     │
│    - What is Life Insurance?            │
│    - Key Features                       │
│    - Benefits                           │
├─────────────────────────────────────────┤
│    Coverage Details                     │
│    - Coverage Amount Options            │
│    - Term Period Options                │
│    - Premium Range                      │
├─────────────────────────────────────────┤
│    Eligibility Criteria                 │
│    - Age: 18-65 years                   │
│    - Health requirements                │
│    - Documentation needed               │
├─────────────────────────────────────────┤
│    Call-to-Action Buttons               │
│    [Calculate Premium] [Apply Now]      │
├─────────────────────────────────────────┤
│         Footer                          │
└─────────────────────────────────────────┘
```

**Components:**
- Information cards
- Feature list with icons
- Eligibility checklist
- CTA buttons

**Actions:**
- Click "Calculate Premium" → Navigate to calculator with Life Insurance pre-selected
- Click "Apply Now" → Navigate to application form (requires login)

---

### 2.3 Medical Insurance Page

**URL:** `/Insurance/Medical`

**Purpose:** Display Medical Insurance information

**Similar layout to Life Insurance page with Medical-specific content:**
- Coverage for doctor fees, hospital fees, medicine costs
- Family vs Individual plans
- Pre-existing condition information
- Network hospitals list

---

### 2.4 Motor Insurance Page

**URL:** `/Insurance/Motor`

**Purpose:** Display Motor Insurance information

**Similar layout with Motor-specific content:**
- Vehicle types covered (Car, Bike, Truck)
- Comprehensive vs Third-party coverage
- Add-ons available
- Claim process

---

### 2.5 Home Insurance Page

**URL:** `/Insurance/Home`

**Purpose:** Display Home Insurance information

**Similar layout with Home-specific content:**
- Property types covered
- Coverage details (fire, theft, natural disasters)
- Exclusions
- Claim process

---

### 2.6 Premium Calculator Page

**URL:** `/Calculator/Index`

**Purpose:** Calculate insurance premium

**Layout:**
```
┌─────────────────────────────────────────┐
│         Navigation Bar                  │
├─────────────────────────────────────────┤
│    Breadcrumb: Home > Premium Calculator│
├─────────────────────────────────────────┤
│                                         │
│    Page Title: Premium Calculator       │
│                                         │
├──────────────────┬──────────────────────┤
│                  │                      │
│  Input Form      │   Result Panel       │
│                  │                      │
│  1. Insurance    │   [Initially Empty]  │
│     Type         │                      │
│     [Dropdown]   │   After Calculate:   │
│                  │                      │
│  2. Coverage     │   Coverage: $X       │
│     Amount       │   Term: Y years      │
│     [Number]     │   Monthly: $Z        │
│                  │   Yearly: $W         │
│  3. Term Period  │                      │
│     [Number]     │   [Apply Now]        │
│                  │                      │
│  4. Age          │                      │
│     [Number]     │                      │
│                  │                      │
│  5. Additional   │                      │
│     Fields       │                      │
│     (Dynamic)    │                      │
│                  │                      │
│  [Calculate]     │                      │
│                  │                      │
└──────────────────┴──────────────────────┘
│         Footer                          │
└─────────────────────────────────────────┘
```

**Dynamic Fields Based on Insurance Type:**
- **Life:** Health Status, Smoking Status, Occupation
- **Medical:** Pre-existing Conditions, Family Members, Coverage Type
- **Motor:** Vehicle Type, Vehicle Value, Vehicle Year
- **Home:** Property Type, Property Value, Construction Type

**Actions:**
- Select insurance type → Show relevant fields
- Click "Calculate" → Display premium in result panel
- Click "Apply Now" → Navigate to application (requires login)

---

### 2.7 Registration Page

**URL:** `/Account/Register`

**Purpose:** New user registration

**Layout:**
```
┌─────────────────────────────────────────┐
│         Navigation Bar                  │
├─────────────────────────────────────────┤
│                                         │
│         Create Account                  │
│                                         │
│    ┌─────────────────────────────┐     │
│    │  First Name *               │     │
│    │  [____________]             │     │
│    │                             │     │
│    │  Last Name *                │     │
│    │  [____________]             │     │
│    │                             │     │
│    │  Email *                    │     │
│    │  [____________]             │     │
│    │                             │     │
│    │  Phone *                    │     │
│    │  [____________]             │     │
│    │                             │     │
│    │  Password *                 │     │
│    │  [____________] [👁]        │     │
│    │                             │     │
│    │  Confirm Password *         │     │
│    │  [____________] [👁]        │     │
│    │                             │     │
│    │  Date of Birth *            │     │
│    │  [____/____/____]           │     │
│    │                             │     │
│    │  Gender *                   │     │
│    │  ○ Male  ○ Female  ○ Other  │     │
│    │                             │     │
│    │  Address                    │     │
│    │  [____________]             │     │
│    │                             │     │
│    │  ☐ I agree to Terms         │     │
│    │                             │     │
│    │  [Register]                 │     │
│    │                             │     │
│    │  Already have account?      │     │
│    │  Login here                 │     │
│    └─────────────────────────────┘     │
│                                         │
└─────────────────────────────────────────┘
```

**Validation:**
- Real-time validation on blur
- Password strength indicator
- Email format validation
- Age validation (18+)

**Actions:**
- Click "Register" → Validate and create account
- Click "Login here" → Navigate to login page

---

### 2.8 Login Page

**URL:** `/Account/Login`

**Purpose:** User authentication

**Layout:**
```
┌─────────────────────────────────────────┐
│         Navigation Bar                  │
├─────────────────────────────────────────┤
│                                         │
│            Login                        │
│                                         │
│    ┌─────────────────────────────┐     │
│    │                             │     │
│    │  Email *                    │     │
│    │  [____________]             │     │
│    │                             │     │
│    │  Password *                 │     │
│    │  [____________] [👁]        │     │
│    │                             │     │
│    │  ☐ Remember me              │     │
│    │                             │     │
│    │  [Login]                    │     │
│    │                             │     │
│    │  Forgot Password?           │     │
│    │                             │     │
│    │  Don't have account?        │     │
│    │  Register here              │     │
│    │                             │     │
│    └─────────────────────────────┘     │
│                                         │
└─────────────────────────────────────────┘
```

**Actions:**
- Click "Login" → Authenticate and redirect to dashboard
- Click "Forgot Password" → Navigate to password reset
- Click "Register here" → Navigate to registration

---

## 3. Authenticated User Pages

### 3.1 User Dashboard

**URL:** `/Dashboard/Index`

**Purpose:** User's main dashboard after login

**Layout:**
```
┌─────────────────────────────────────────┐
│    Navigation Bar (with User Menu)     │
├─────────────────────────────────────────┤
│                                         │
│    Welcome, [User Name]!                │
│                                         │
├─────────────────────────────────────────┤
│    Quick Stats (4 Cards)                │
│    ┌──────┐ ┌──────┐ ┌──────┐ ┌──────┐│
│    │Active│ │Total │ │Loans │ │Due   ││
│    │Policy│ │Paid  │ │      │ │Pay   ││
│    │  3   │ │$5000 │ │  1   │ │$200  ││
│    └──────┘ └──────┘ └──────┘ └──────┘│
├─────────────────────────────────────────┤
│    My Policies                          │
│    ┌─────────────────────────────────┐ │
│    │ Policy Table                    │ │
│    │ - Policy Number                 │ │
│    │ - Type                          │ │
│    │ - Coverage                      │ │
│    │ - Status                        │ │
│    │ - Actions [View] [Pay]          │ │
│    └─────────────────────────────────┘ │
├─────────────────────────────────────────┤
│    Recent Payments                      │
│    [Payment history table]              │
├─────────────────────────────────────────┤
│    Quick Actions                        │
│    [Apply New Policy] [Apply for Loan]  │
│    [Calculate Premium] [Make Payment]   │
└─────────────────────────────────────────┘
```

**Components:**
- Summary cards with icons
- Policies table with pagination
- Recent payments list
- Quick action buttons

---

### 3.2 My Policies Page

**URL:** `/Policy/MyPolicies`

**Purpose:** View all user's policies

**Layout:**
```
┌─────────────────────────────────────────┐
│    Navigation Bar                       │
├─────────────────────────────────────────┤
│    My Policies                          │
│                                         │
│    Filters:                             │
│    [All] [Active] [Pending] [Expired]   │
│                                         │
├─────────────────────────────────────────┤
│    Policy Cards (Grid View)             │
│    ┌─────────────┐  ┌─────────────┐    │
│    │ Life Ins    │  │ Medical Ins │    │
│    │ POL123456   │  │ POL789012   │    │
│    │ $50,000     │  │ $100,000    │    │
│    │ Active      │  │ Active      │    │
│    │ [View] [Pay]│  │ [View] [Pay]│    │
│    └─────────────┘  └─────────────┘    │
│                                         │
└─────────────────────────────────────────┘
```

**Actions:**
- Click filter → Show filtered policies
- Click "View" → Navigate to policy details
- Click "Pay" → Navigate to payment page

---

### 3.3 Policy Details Page

**URL:** `/Policy/Details/{id}`

**Purpose:** View detailed policy information

**Layout:**
```
┌─────────────────────────────────────────┐
│    Navigation Bar                       │
├─────────────────────────────────────────┤
│    Breadcrumb: Dashboard > My Policies  │
│                > Policy Details         │
├─────────────────────────────────────────┤
│    Policy Information                   │
│    ┌─────────────────────────────────┐ │
│    │ Policy Number: POL123456        │ │
│    │ Type: Life Insurance            │ │
│    │ Status: Active                  │ │
│    │ Coverage: $50,000               │ │
│    │ Premium: $200/month             │ │
│    │ Start Date: 01/01/2024          │ │
│    │ End Date: 01/01/2044            │ │
│    └─────────────────────────────────┘ │
├─────────────────────────────────────────┤
│    Insured Details                      │
│    [Personal information]               │
├─────────────────────────────────────────┤
│    Payment History                      │
│    [Table with all payments]            │
├─────────────────────────────────────────┤
│    Actions                              │
│    [Make Payment] [Apply for Loan]      │
│    [Download Policy] [Print]            │
└─────────────────────────────────────────┘
```

---

### 3.4 Apply for Policy Page

**URL:** `/Policy/Apply`

**Purpose:** Apply for new insurance policy

**Multi-step form:**

**Step 1: Select Insurance Type**
```
Select Insurance Type:
○ Life Insurance
○ Medical Insurance
○ Motor Insurance
○ Home Insurance

[Next]
```

**Step 2: Personal Information**
```
[Pre-filled from user profile]
[Next] [Back]
```

**Step 3: Policy Details**
```
[Insurance-specific fields]
Coverage Amount: [_____]
Term Period: [_____]
[Additional fields based on type]

[Next] [Back]
```

**Step 4: Premium Calculation**
```
Your Premium:
Monthly: $200
Yearly: $2,400

[Confirm & Submit] [Back]
```

---

### 3.5 Loan Application Page

**URL:** `/Loan/Apply`

**Purpose:** Apply for loan against policy

**Layout:**
```
┌─────────────────────────────────────────┐
│    Apply for Loan                       │
├─────────────────────────────────────────┤
│    Select Policy                        │
│    [Dropdown of active policies]        │
│                                         │
│    Policy Details:                      │
│    - Surrender Value: $10,000           │
│    - Maximum Loan: $9,000               │
│                                         │
│    Loan Amount *                        │
│    [_________]                          │
│                                         │
│    Loan Term (months) *                 │
│    [_________]                          │
│                                         │
│    Interest Rate: 8% per annum          │
│                                         │
│    EMI: $XXX/month                      │
│                                         │
│    [Submit Application]                 │
└─────────────────────────────────────────┘
```

---

### 3.6 Payment Page

**URL:** `/Payment/MakePayment`

**Purpose:** Make premium or loan payment

**Layout:**
```
┌─────────────────────────────────────────┐
│    Make Payment                         │
├─────────────────────────────────────────┤
│    Policy Number: POL123456             │
│    Amount: $200                         │
│    Payment Type: Premium                │
│                                         │
│    Payment Method:                      │
│    ○ Credit Card                        │
│    ○ Debit Card                         │
│    ○ Net Banking                        │
│    ○ UPI                                │
│                                         │
│    [Payment method specific fields]     │
│                                         │
│    [Pay Now]                            │
└─────────────────────────────────────────┘
```

---

## 4. Admin Pages

### 4.1 Admin Dashboard

**URL:** `/Admin/Dashboard`

**Purpose:** Admin overview

**Layout:**
```
┌─────────────────────────────────────────┐
│    Admin Navigation                     │
├─────────────────────────────────────────┤
│    Statistics (6 Cards)                 │
│    [Total Users] [Active Policies]      │
│    [Pending Applications] [Total Revenue]│
│    [Active Loans] [Pending Loans]       │
├─────────────────────────────────────────┤
│    Recent Applications                  │
│    [Table with approve/reject actions]  │
├─────────────────────────────────────────┤
│    Charts                               │
│    [Revenue Chart] [Policy Distribution]│
└─────────────────────────────────────────┘
```

---

### 4.2 Manage Users Page

**URL:** `/Admin/Users`

**Purpose:** View and manage users

**Features:**
- User list with search and filter
- Activate/Deactivate users
- View user details
- Reset password

---

### 4.3 Manage Policies Page

**URL:** `/Admin/Policies`

**Purpose:** Approve/reject policy applications

**Features:**
- Policy applications list
- Filter by status
- Approve/Reject actions
- View application details

---

### 4.4 Manage Loans Page

**URL:** `/Admin/Loans`

**Purpose:** Approve/reject loan applications

**Features:**
- Loan applications list
- Eligibility verification
- Approve/Reject actions
- Set interest rate and terms

---

### 4.5 Reports Page

**URL:** `/Admin/Reports`

**Purpose:** Generate various reports

**Report Types:**
- Policies sold (by type, by period)
- Revenue report
- User registration report
- Payment report
- Loan report

---

## 5. Common UI Components

### 5.1 Navigation Bar
- Logo (left)
- Menu items (center)
- User menu/Login button (right)

### 5.2 Footer
- Company information
- Quick links
- Contact information
- Social media links
- Copyright notice

### 5.3 Breadcrumb
- Shows current page hierarchy
- Clickable navigation

### 5.4 Alert Messages
- Success (green)
- Error (red)
- Warning (yellow)
- Info (blue)

### 5.5 Loading Spinner
- Shown during async operations

### 5.6 Confirmation Dialog
- For destructive actions
- "Are you sure?" message
- Confirm/Cancel buttons

---

**Prepared By:** _________________________

**Date:** _________________________

**Approved By:** _________________________

**Date:** _________________________
