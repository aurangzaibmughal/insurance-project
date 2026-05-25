using System.ComponentModel.DataAnnotations;

namespace InsuranceManagementSystem.Models
{
    public class PaymentViewModel
    {
        public int PolicyId { get; set; }

        public string PolicyNumber { get; set; } = string.Empty;

        public string PolicyType { get; set; } = string.Empty;

        public decimal PremiumAmount { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        [Display(Name = "Payment Amount (₹)")]
        public decimal Amount { get; set; }

        [Required]
        [Display(Name = "Payment Method")]
        public string? PaymentMethod { get; set; }

        [StringLength(500)]
        public string? Remarks { get; set; }
    }
}
