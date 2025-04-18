using System.ComponentModel.DataAnnotations;

namespace api.Models.DTOs.Boss
{
    public class BossDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int Health { get; set; }

        [Required]
        public int BloodEchoes { get; set; }

        [Required]
        public bool IsInterruptible { get; set; }

        [Required]
        public bool IsRequired { get; set; }
    }
}
