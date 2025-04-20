using System.ComponentModel.DataAnnotations;

namespace api.Models.DTOs.Scaling
{
    public class CreateScalingDto
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0, 9.99, ErrorMessage = "Strength scaling must be between 0 and 9.99")]
        public decimal? StrengthScaling { get; set; }

        [Required]
        [Range(0, 9.99, ErrorMessage = "Skill scaling must be between 0 and 9.99")]
        public decimal? SkillScaling { get; set; }

        [Required]
        [Range(0, 9.99, ErrorMessage = "Bloodtinge scaling must be between 0 and 9.99")]
        public decimal? BloodtingeScaling { get; set; }

        [Required]
        [Range(0, 9.99, ErrorMessage = "Arcane scaling must be between 0 and 9.99")]
        public decimal? ArcaneScaling { get; set; }

        [Required]
        [Range(0, 9.99, ErrorMessage = "Strength step must be between 0 and 9.99")]
        public decimal? StrengthStep { get; set; }

        [Required]
        [Range(0, 9.99, ErrorMessage = "Skill step must be between 0 and 9.99")]
        public decimal? SkillStep { get; set; }

        [Required]
        [Range(0, 9.99, ErrorMessage = "Bloodtinge step must be between 0 and 9.99")]
        public decimal? BloodtingeStep { get; set; }

        [Required]
        [Range(0, 9.999, ErrorMessage = "Arcane step must be between 0 and 9.999")]
        public decimal? ArcaneStep { get; set; }

        public int? TricksterWeaponId { get; set; }
        public int? FirearmId { get; set; }
    }
}
