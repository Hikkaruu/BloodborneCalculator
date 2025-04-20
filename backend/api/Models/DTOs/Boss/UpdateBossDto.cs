using System.ComponentModel.DataAnnotations;

namespace api.Models.DTOs.Boss
{
    public class UpdateBossDto
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        public string? Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Health must be > 0")]
        public int? Health { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Blood Echoes can't be negative")]
        public int? BloodEchoes { get; set; }

        public bool? IsInterruptible { get; set; }

        public bool? IsRequired { get; set; }

        [Required]
        public bool IsBeast { get; set; }

        [Required]
        public bool IsKin { get; set; }

        [Required]
        public bool IsWeakToSerrated { get; set; }

        [Required]
        public bool IsWeakToRighteous { get; set; }

        [Required]
        [Range(0, 999, ErrorMessage = "Physical Defense must be between 0 and 999 inclusive")]
        public int PhysicalDefense { get; set; }

        [Required]
        [Range(0, 999, ErrorMessage = "Blunt Defense must be between 0 and 999 inclusive")]
        public int BluntDefense { get; set; }

        [Required]
        [Range(0, 999, ErrorMessage = "Thrust Defense must be between 0 and 999 inclusive")]
        public int ThrustDefense { get; set; }

        [Required]
        [Range(0, 999, ErrorMessage = "Bloodtinge Defense must be between 0 and 999 inclusive")]
        public int BloodtingeDefense { get; set; }

        [Required]
        [Range(0, 999, ErrorMessage = "Arcane Defense must be between 0 and 999 inclusive")]
        public int ArcaneDefense { get; set; }

        [Required]
        [Range(0, 999, ErrorMessage = "Fire Defense must be between 0 and 999 inclusive")]
        public int FireDefense { get; set; }

        [Required]
        [Range(0, 999, ErrorMessage = "Bolt Defense must be between 0 and 999 inclusive")]
        public int BoltDefense { get; set; }

        [Required]
        [Range(0, 999, ErrorMessage = "Slow Poison Resistance must be between 0 and 999 inclusive")]
        public int SlowPoisonResistance { get; set; }

        [Required]
        [Range(0, 999, ErrorMessage = "Rapid Poison Resistance must be between 0 and 999 inclusive")]
        public int RapidPoisonResistance { get; set; }

        [Required]
        [Url(ErrorMessage = "Provide valid URL")]
        [MaxLength(500, ErrorMessage = "URL can't be longer than 500 characters")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}

