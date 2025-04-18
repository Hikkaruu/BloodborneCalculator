﻿using System.ComponentModel.DataAnnotations;

namespace api.Models.DTOs.Scaling
{
    public class ScalingDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0, 9.99)]
        public decimal StrengthScaling { get; set; }

        [Required]
        [Range(0, 9.99)]
        public decimal SkillScaling { get; set; }

        [Required]
        [Range(0, 9.99)]
        public decimal BloodtingeScaling { get; set; }

        [Required]
        [Range(0, 9.99)]
        public decimal ArcaneScaling { get; set; }

        [Required]
        [Range(0, 9.99)]
        public decimal StrengthStep { get; set; }

        [Required]
        [Range(0, 9.99)]
        public decimal SkillStep { get; set; }

        [Required]
        [Range(0, 9.99)]
        public decimal BloodtingeStep { get; set; }

        [Required]
        [Range(0, 9.999)]
        public decimal ArcaneStep { get; set; }
    }
}
