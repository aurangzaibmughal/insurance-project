# GUI Standards Document

---

## 1. Introduction

This document defines the Graphical User Interface (GUI) standards for the Online Insurance Management System to ensure consistency, usability, and professional appearance across all pages.

---

## 2. Design Principles

### 2.1 Consistency
- Maintain uniform layout across all pages
- Use consistent navigation structure
- Apply same color scheme throughout

### 2.2 Simplicity
- Keep interfaces clean and uncluttered
- Use clear, concise labels
- Minimize user actions required

### 2.3 User-Friendly
- Intuitive navigation
- Clear error messages
- Helpful tooltips and hints

### 2.4 Accessibility
- Support keyboard navigation
- Provide alt text for images
- Ensure sufficient color contrast

---

## 3. Color Scheme

### Primary Colors
- **Primary Blue:** #0066CC (Headers, buttons, links)
- **Dark Blue:** #004080 (Hover states, emphasis)
- **Light Blue:** #E6F2FF (Backgrounds, highlights)

### Secondary Colors
- **Success Green:** #28A745 (Success messages, active status)
- **Warning Orange:** #FFC107 (Warnings, pending status)
- **Danger Red:** #DC3545 (Errors, cancelled status)
- **Info Cyan:** #17A2B8 (Information messages)

### Neutral Colors
- **White:** #FFFFFF (Backgrounds, cards)
- **Light Gray:** #F8F9FA (Alternate backgrounds)
- **Medium Gray:** #6C757D (Secondary text)
- **Dark Gray:** #343A40 (Primary text)
- **Border Gray:** #DEE2E6 (Borders, dividers)

---

## 4. Typography

### Font Family
- **Primary Font:** 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif
- **Monospace Font:** 'Courier New', Courier, monospace (for codes, numbers)

### Font Sizes
- **H1 (Page Title):** 32px, Bold
- **H2 (Section Header):** 24px, Semi-Bold
- **H3 (Sub-section):** 20px, Semi-Bold
- **H4 (Card Title):** 18px, Semi-Bold
- **Body Text:** 16px, Regular
- **Small Text:** 14px, Regular
- **Tiny Text:** 12px, Regular

### Font Weights
- **Regular:** 400
- **Semi-Bold:** 600
- **Bold:** 700

---

## 5. Layout Standards

### 5.1 Page Structure
```
┌─────────────────────────────────────┐
│          Header/Navigation          │
├─────────────────────────────────────┤
│                                     │
│          Breadcrumb (optional)      │
│                                     │
│          Page Title                 │
│                                     │
│          Main Content Area          │
│                                     │
│                                     │
├─────────────────────────────────────┤
│             Footer                  │
└─────────────────────────────────────┘
```

### 5.2 Container Widths
- **Maximum Width:** 1200px (centered)
- **Minimum Width:** 320px (mobile)
- **Padding:** 15px on mobile, 30px on desktop

### 5.3 Spacing
- **Section Margin:** 40px
- **Element Margin:** 20px
- **Card Padding:** 20px
- **Button Padding:** 10px 20px
- **Input Padding:** 10px 15px

---

## 6. Navigation

### 6.1 Main Navigation Bar
- **Height:** 60px
- **Background:** Primary Blue (#0066CC)
- **Text Color:** White
- **Logo:** Left-aligned, 40px height
- **Menu Items:** Right-aligned, 16px font

### 6.2 Navigation Items
- Home
- Insurance Types (Dropdown: Life, Medical, Motor, Home)
- Premium Calculator
- My Policies (for logged-in users)
- Loans (for logged-in users)
- About Us
- Contact
- Login/Register (or User Profile if logged in)

### 6.3 Breadcrumb
- **Font Size:** 14px
- **Color:** Medium Gray
- **Separator:** "/" or ">"
- **Example:** Home > Life Insurance > Apply

---

## 7. Form Standards

### 7.1 Form Layout
- **Label Position:** Above input field
- **Label Font:** 14px, Semi-Bold
- **Required Fields:** Red asterisk (*) after label
- **Field Width:** Full width on mobile, appropriate width on desktop

### 7.2 Input Fields
- **Height:** 40px
- **Border:** 1px solid Border Gray
- **Border Radius:** 4px
- **Focus State:** 2px border, Primary Blue
- **Placeholder:** Medium Gray, Italic

### 7.3 Input Types
- **Text Input:** Standard text field
- **Email Input:** With email validation
- **Password Input:** With show/hide toggle
- **Number Input:** With min/max validation
- **Date Picker:** Calendar popup
- **Dropdown:** With search for long lists
- **Radio Buttons:** For mutually exclusive options
- **Checkboxes:** For multiple selections
- **Textarea:** For long text (min 3 rows)

### 7.4 Validation
- **Inline Validation:** Show errors below field
- **Error Color:** Danger Red
- **Error Icon:** ⚠ symbol
- **Success Indicator:** Green checkmark ✓

---

## 8. Buttons

### 8.1 Button Types

#### Primary Button
- **Background:** Primary Blue
- **Text Color:** White
- **Hover:** Dark Blue
- **Use:** Main actions (Submit, Save, Apply)

#### Secondary Button
- **Background:** White
- **Border:** 1px Primary Blue
- **Text Color:** Primary Blue
- **Hover:** Light Blue background
- **Use:** Secondary actions (Cancel, Back)

#### Success Button
- **Background:** Success Green
- **Text Color:** White
- **Use:** Approve, Confirm

#### Danger Button
- **Background:** Danger Red
- **Text Color:** White
- **Use:** Delete, Reject, Cancel

### 8.2 Button Sizes
- **Large:** 48px height, 18px font
- **Medium:** 40px height, 16px font (default)
- **Small:** 32px height, 14px font

### 8.3 Button States
- **Normal:** Standard appearance
- **Hover:** Darker shade, cursor pointer
- **Active:** Slightly darker, pressed effect
- **Disabled:** 50% opacity, cursor not-allowed

---

## 9. Cards and Panels

### 9.1 Card Design
- **Background:** White
- **Border:** 1px solid Border Gray
- **Border Radius:** 8px
- **Shadow:** 0 2px 4px rgba(0,0,0,0.1)
- **Padding:** 20px
- **Margin:** 20px between cards

### 9.2 Card Header
- **Font Size:** 18px, Semi-Bold
- **Border Bottom:** 1px solid Border Gray
- **Padding Bottom:** 10px
- **Margin Bottom:** 15px

---

## 10. Tables

### 10.1 Table Design
- **Border:** 1px solid Border Gray
- **Header Background:** Light Gray
- **Header Font:** 14px, Semi-Bold
- **Row Height:** 48px
- **Alternate Rows:** Light Gray background
- **Hover:** Light Blue background

### 10.2 Table Elements
- **Cell Padding:** 12px
- **Text Alignment:** Left for text, Right for numbers
- **Action Buttons:** Small size, icon + text

---

## 11. Icons

### 11.1 Icon Library
Use **Font Awesome** or **Bootstrap Icons**

### 11.2 Common Icons
- **User:** 👤 (fa-user)
- **Policy:** 📄 (fa-file-alt)
- **Payment:** 💳 (fa-credit-card)
- **Loan:** 💰 (fa-money-bill)
- **Calculator:** 🧮 (fa-calculator)
- **Home:** 🏠 (fa-home)
- **Car:** 🚗 (fa-car)
- **Medical:** ⚕ (fa-heartbeat)
- **Life:** ❤ (fa-heart)
- **Edit:** ✏ (fa-edit)
- **Delete:** 🗑 (fa-trash)
- **View:** 👁 (fa-eye)
- **Download:** ⬇ (fa-download)

### 11.3 Icon Sizes
- **Small:** 16px
- **Medium:** 24px (default)
- **Large:** 32px

---

## 12. Messages and Alerts

### 12.1 Alert Types

#### Success Alert
- **Background:** Light green (#D4EDDA)
- **Border:** Success Green
- **Icon:** ✓ checkmark
- **Use:** Successful operations

#### Error Alert
- **Background:** Light red (#F8D7DA)
- **Border:** Danger Red
- **Icon:** ⚠ warning
- **Use:** Errors and failures

#### Warning Alert
- **Background:** Light yellow (#FFF3CD)
- **Border:** Warning Orange
- **Icon:** ⚠ caution
- **Use:** Warnings and cautions

#### Info Alert
- **Background:** Light cyan (#D1ECF1)
- **Border:** Info Cyan
- **Icon:** ℹ information
- **Use:** Information messages

### 12.2 Alert Design
- **Padding:** 15px
- **Border Radius:** 4px
- **Border:** 1px solid (color based on type)
- **Dismissible:** X button on right
- **Auto-dismiss:** 5 seconds for success, manual for errors

---

## 13. Modal Dialogs

### 13.1 Modal Design
- **Overlay:** Semi-transparent black (rgba(0,0,0,0.5))
- **Modal Background:** White
- **Max Width:** 600px
- **Border Radius:** 8px
- **Shadow:** 0 4px 8px rgba(0,0,0,0.2)

### 13.2 Modal Structure
- **Header:** Title + Close button
- **Body:** Main content
- **Footer:** Action buttons (right-aligned)

---

## 14. Loading States

### 14.1 Loading Spinner
- **Type:** Circular spinner
- **Color:** Primary Blue
- **Size:** 40px
- **Position:** Center of container

### 14.2 Skeleton Screens
- **Use:** For loading content
- **Color:** Light Gray with shimmer effect

---

## 15. Responsive Design

### 15.1 Breakpoints
- **Mobile:** < 576px
- **Tablet:** 576px - 768px
- **Desktop:** 768px - 1200px
- **Large Desktop:** > 1200px

### 15.2 Mobile Adaptations
- Stack columns vertically
- Full-width buttons
- Hamburger menu for navigation
- Larger touch targets (min 44px)

---

## 16. Accessibility Standards

### 16.1 WCAG 2.1 Compliance
- **Level:** AA minimum
- **Color Contrast:** 4.5:1 for normal text
- **Focus Indicators:** Visible on all interactive elements
- **Alt Text:** For all images
- **Keyboard Navigation:** Full support

---

**Prepared By:** _________________________

**Date:** _________________________

**Approved By:** _________________________

**Date:** _________________________
