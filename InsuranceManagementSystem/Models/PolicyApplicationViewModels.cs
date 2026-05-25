using System.ComponentModel.DataAnnotations;

namespace InsuranceManagementSystem.Models
{
    public class PolicyApplicationViewModel
    {
        [Required]
        [Range(18, 70)]
        public int Age { get; set; }

        [Required]
        [Range(100000, 10000000)]
        [Display(Name = "Coverage Amount (₹)")]
        public decimal CoverageAmount { get; set; }

        [Required]
        [Range(5, 30)]
        [Display(Name = "Term Period (Years)")]
        public int TermPeriod { get; set; }

        [Required]
        [Display(Name = "Smoking Status")]
        public string? SmokingStatus { get; set; }

        [Required]
        [Display(Name = "Health Status")]
        public string? HealthStatus { get; set; }

        [StringLength(100)]
        public string? Occupation { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Beneficiary Name")]
        public string? BeneficiaryName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Beneficiary Relation")]
        public string? BeneficiaryRelation { get; set; }

        [Required]
        [Display(Name = "Annual Premium (₹)")]
        public decimal PremiumAmount { get; set; }
    }

    public class MedicalPolicyApplicationViewModel
    {
        [Required]
        [Range(18, 80)]
        public int Age { get; set; }

        [Required]
        [Range(100000, 5000000)]
        [Display(Name = "Coverage Amount (₹)")]
        public decimal CoverageAmount { get; set; }

        [Display(Name = "Pre-existing Conditions")]
        public bool HasPreExistingConditions { get; set; }

        [StringLength(500)]
        [Display(Name = "Pre-existing Condition Details")]
        public string? PreExistingConditionDetails { get; set; }

        [Required]
        [Range(1, 10)]
        [Display(Name = "Number of Family Members")]
        public int NumberOfFamilyMembers { get; set; }

        [StringLength(50)]
        [Display(Name = "Blood Group")]
        public string? BloodGroup { get; set; }

        [Required]
        [Range(50, 250)]
        [Display(Name = "Height (cm)")]
        public decimal Height { get; set; }

        [Required]
        [Range(30, 200)]
        [Display(Name = "Weight (kg)")]
        public decimal Weight { get; set; }

        [Required]
        [Display(Name = "Annual Premium (₹)")]
        public decimal PremiumAmount { get; set; }
    }
}
