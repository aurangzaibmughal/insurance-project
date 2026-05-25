using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceManagementSystem.Models
{
    public class LifeInsurance
    {
        [Key]
        public int LifeInsuranceId { get; set; }

        [Required]
        public int PolicyId { get; set; }

        [ForeignKey("PolicyId")]
        public Policy? Policy { get; set; }

        public int Age { get; set; }

        public int TermPeriod { get; set; }

        [Required]
        [StringLength(20)]
        public string SmokingStatus { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string HealthStatus { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Occupation { get; set; }

        [StringLength(200)]
        public string? BeneficiaryName { get; set; }

        [StringLength(50)]
        public string? BeneficiaryRelation { get; set; }
    }
}
