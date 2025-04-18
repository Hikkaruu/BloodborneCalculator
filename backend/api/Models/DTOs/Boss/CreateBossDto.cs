using System.ComponentModel.DataAnnotations;

namespace api.Models.DTOs.Boss
{
    public class CreateBossDto
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Health must be > 0")]
        public int Health { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Blood Echoes can't be negative")]
        public int BloodEchoes { get; set; }

        [Required]
        public bool IsInterruptible { get; set; }

        [Required]
        public bool IsRequired { get; set; }

    }
}
