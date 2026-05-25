using System.ComponentModel.DataAnnotations;

namespace InsuranceManagementSystem.Models
{
    public class LoanApplicationViewModel
    {
        public int PolicyId { get; set; }

        public string PolicyNumber { get; set; } = string.Empty;

        public string PolicyType { get; set; } = string.Empty;

        public decimal PolicyValue { get; set; }

        [Required]
        [Range(1000, double.MaxValue, ErrorMessage = "Loan amount must be at least ₹1,000")]
        [Display(Name = "Loan Amount (₹)")]
        public decimal LoanAmount { get; set; }

        [Required]
        [Range(6, 120, ErrorMessage = "Tenure must be between 6 and 120 months")]
        [Display(Name = "Tenure (Months)")]
        public int TenureMonths { get; set; }

        [Display(Name = "Interest Rate (%)")]
        public decimal InterestRate { get; set; } = 10.5m;

        [Display(Name = "Monthly EMI")]
        public decimal MonthlyEMI { get; set; }
    }
}
