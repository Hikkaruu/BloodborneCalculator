using System.ComponentModel.DataAnnotations;

namespace api.Models.DTOs.Boss
{
    public class UpdateBossDto
    {
        [MaxLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        public string? Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Health must be > 0")]
        public int? Health { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Blood Echoes can't be negative")]
        public int? BloodEchoes { get; set; }

        public bool? IsInterruptible { get; set; }

        public bool? IsRequired { get; set; }
    }
}

