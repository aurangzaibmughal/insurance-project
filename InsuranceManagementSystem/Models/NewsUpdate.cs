using System.ComponentModel.DataAnnotations;

namespace InsuranceManagementSystem.Models
{
    public class NewsUpdate
    {
        [Key]
        public int NewsId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        public DateTime PublishDate { get; set; } = DateTime.Now;

        [Required]
        [StringLength(50)]
        public string Category { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        [StringLength(200)]
        public string? ImageUrl { get; set; }

        [Required]
        public string CreatedBy { get; set; } = string.Empty;
    }
}
