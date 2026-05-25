using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceManagementSystem.Models
{
    public class MotorInsurance
    {
        [Key]
        public int MotorInsuranceId { get; set; }

        [Required]
        public int PolicyId { get; set; }

        [ForeignKey("PolicyId")]
        public Policy? Policy { get; set; }

        [Required]
        [StringLength(50)]
        public string VehicleType { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string VehicleMake { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string VehicleModel { get; set; } = string.Empty;

        public int VehicleYear { get; set; }

        [Required]
        [StringLength(20)]
        public string RegistrationNumber { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal VehicleValue { get; set; }

        public int VehicleAge { get; set; }

        [StringLength(50)]
        public string? EngineNumber { get; set; }

        [StringLength(50)]
        public string? ChassisNumber { get; set; }
    }
}
