using System.ComponentModel.DataAnnotations;

namespace InsuranceManagementSystem.Models
{
    public class LifeInsuranceCalculatorViewModel
    {
        [Required]
        [Range(18, 70, ErrorMessage = "Age must be between 18 and 70")]
        public int Age { get; set; }

        [Required]
        [Range(100000, 10000000, ErrorMessage = "Coverage amount must be between ₹1,00,000 and ₹1,00,00,000")]
        [Display(Name = "Coverage Amount (₹)")]
        public decimal CoverageAmount { get; set; }

        [Required]
        [Range(5, 30, ErrorMessage = "Term period must be between 5 and 30 years")]
        [Display(Name = "Term Period (Years)")]
        public int TermPeriod { get; set; }

        [Required]
        [Display(Name = "Smoking Status")]
        public string SmokingStatus { get; set; } = "Non-Smoker";

        [Required]
        [Display(Name = "Health Status")]
        public string HealthStatus { get; set; } = "Good";
    }

    public class MedicalInsuranceCalculatorViewModel
    {
        [Required]
        [Range(18, 80, ErrorMessage = "Age must be between 18 and 80")]
        public int Age { get; set; }

        [Required]
        [Range(100000, 5000000, ErrorMessage = "Coverage amount must be between ₹1,00,000 and ₹50,00,000")]
        [Display(Name = "Coverage Amount (₹)")]
        public decimal CoverageAmount { get; set; }

        [Display(Name = "Pre-existing Conditions")]
        public bool HasPreExistingConditions { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Number of family members must be between 1 and 10")]
        [Display(Name = "Number of Family Members")]
        public int NumberOfFamilyMembers { get; set; } = 1;
    }

    public class MotorInsuranceCalculatorViewModel
    {
        [Required]
        [Range(50000, 10000000, ErrorMessage = "Vehicle value must be between ₹50,000 and ₹1,00,00,000")]
        [Display(Name = "Vehicle Value (₹)")]
        public decimal VehicleValue { get; set; }

        [Required]
        [Display(Name = "Vehicle Type")]
        public string VehicleType { get; set; } = "Car";

        [Required]
        [Range(0, 20, ErrorMessage = "Vehicle age must be between 0 and 20 years")]
        [Display(Name = "Vehicle Age (Years)")]
        public int VehicleAge { get; set; }
    }

    public class HomeInsuranceCalculatorViewModel
    {
        [Required]
        [Range(500000, 50000000, ErrorMessage = "Property value must be between ₹5,00,000 and ₹5,00,00,000")]
        [Display(Name = "Property Value (₹)")]
        public decimal PropertyValue { get; set; }

        [Required]
        [Display(Name = "Property Type")]
        public string PropertyType { get; set; } = "Apartment";

        [Required]
        [Display(Name = "Construction Type")]
        public string ConstructionType { get; set; } = "RCC";

        [Required]
        [Range(0, 50, ErrorMessage = "Property age must be between 0 and 50 years")]
        [Display(Name = "Property Age (Years)")]
        public int PropertyAge { get; set; }

        [Display(Name = "Has Security System")]
        public bool HasSecuritySystem { get; set; }
    }
}
