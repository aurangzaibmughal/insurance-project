using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceManagementSystem.Models
{
    public class HomeInsurance
    {
        [Key]
        public int HomeInsuranceId { get; set; }

        [Required]
        public int PolicyId { get; set; }

        [ForeignKey("PolicyId")]
        public Policy? Policy { get; set; }

        [Required]
        [StringLength(100)]
        public string PropertyType { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string PropertyAddress { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal PropertyValue { get; set; }

        public int PropertyAge { get; set; }

        [Required]
        [StringLength(50)]
        public string ConstructionType { get; set; } = string.Empty;

        public bool HasSecuritySystem { get; set; }

        public bool HasFireAlarm { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal AreaInSqFt { get; set; }

        public int NumberOfRooms { get; set; }
    }
}
