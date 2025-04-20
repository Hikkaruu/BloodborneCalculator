using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        public bool IsBeast { get; set; }

        [Required]
        public bool IsKin { get; set; }

        [Required]
        public bool IsWeakToSerrated { get; set; }

        [Required]
        public bool IsWeakToRighteous { get; set; }

        [Required]
        [Range(0, 999)]
        public int PhysicalDefense { get; set; }

        [Required]
        [Range(0, 999)]
        public int BluntDefense { get; set; }

        [Required]
        [Range(0, 999)]
        public int ThrustDefense { get; set; }

        [Required]
        [Range(0, 999)]
        public int BloodtingeDefense { get; set; }

        [Required]
        [Range(0, 999)]
        public int ArcaneDefense { get; set; }

        [Required]
        [Range(0, 999)]
        public int FireDefense { get; set; }

        [Required]
        [Range(0, 999)]
        public int BoltDefense { get; set; }

        [Required]
        [Range(0, 999)]
        public int SlowPoisonResistance { get; set; }

        [Required]
        [Range(0, 999)]

        public int RapidPoisonResistance { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
