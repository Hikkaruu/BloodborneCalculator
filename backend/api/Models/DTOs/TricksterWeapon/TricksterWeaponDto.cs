using api.Models.DTOs.Scaling;
using api.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace api.Models.DTOs.TricksterWeapon
{
    public class TricksterWeaponDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0, 1000)]
        public int PhysicalAttack { get; set; }

        [Required]
        [Range(0, 1000)]
        public int BloodAttack { get; set; }

        [Required]
        [Range(0, 1000)]
        public int ArcaneAttack { get; set; }

        [Required]
        [Range(0, 1000)]
        public int FireAttack { get; set; }

        [Required]
        [Range(0, 1000)]
        public int BoltAttack { get; set; }

        [Required]
        [Range(0, 20)]
        public int BulletUse { get; set; }

        [Required]
        [Range(0, 100)]
        public int RapidPoison { get; set; }

        [Required]
        public ImprintType ImprintsNormal { get; set; }

        [Required]
        public ImprintType ImprintsUncanny { get; set; }

        [Required]
        public ImprintType ImprintsLost { get; set; }

        [Required]
        [Range(0, 1000)]
        public int Rally { get; set; }

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
        [Range(0, 1000)]
        public int MaxUpgradeAttack { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; } = string.Empty;

        public ScalingForWeaponDto? Scaling { get; set; }
        public List<AttackForTricksterWeaponDto>? Attacks { get; set; }
    }
}
