using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceManagementSystem.Models
{
    public class MedicalInsurance
    {
        [Key]
        public int MedicalInsuranceId { get; set; }

        [Required]
        public int PolicyId { get; set; }

        [ForeignKey("PolicyId")]
        public Policy? Policy { get; set; }

        public int Age { get; set; }

        public bool HasPreExistingConditions { get; set; }

        [StringLength(500)]
        public string? PreExistingConditionDetails { get; set; }

        public int NumberOfFamilyMembers { get; set; }

        [StringLength(50)]
        public string? BloodGroup { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Height { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Weight { get; set; }
    }
}
