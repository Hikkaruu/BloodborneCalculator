using api.Models.DTOs.Scaling;
using api.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace api.Models.DTOs.Firearm
{
    public class FirearmDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0, int.MaxValue)]
        public int PhysicalAttack { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int BloodAttack { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int ArcaneAttack { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int FireAttack { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int BoltAttack { get; set; }

        [Required]
        [Range(0, 20)]
        public int BulletUse { get; set; }

        [Required]
        public ImprintType Imprints { get; set; }

        [Required]
        [Range(0, 99)]
        public int StrengthRequirement { get; set; }

        [Required]
        [Range(0, 99)]
        public int SkillRequirement { get; set; }

        [Required]
        [Range(0, 99)]
        public int BloodtingeRequirement { get; set; }

        [Required]
        [Range(0, 99)]
        public int ArcaneRequirement { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; } = string.Empty;

        public ScalingForWeaponDto? Scaling { get; set; }
    }
}
