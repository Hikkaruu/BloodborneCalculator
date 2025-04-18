﻿using api.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models.DTOs.TricksterWeapon
{
    public class CreateTricksterWeaponDto
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0, 1000, ErrorMessage = "Physical Attack must be between 0 and 1000")]
        public int PhysicalAttack { get; set; }

        [Required]
        [Range(0, 1000, ErrorMessage = "Blood Attack must be between 0 and 1000")]
        public int BloodAttack { get; set; }

        [Required]
        [Range(0, 1000, ErrorMessage = "Arcane Attack must be between 0 and 1000")]
        public int ArcaneAttack { get; set; }

        [Required]
        [Range(0, 1000, ErrorMessage = "Fire Attack must be between 0 and 1000")]
        public int FireAttack { get; set; }

        [Required]
        [Range(0, 1000, ErrorMessage = "Bolt Attack must be between 0 and 1000")]
        public int BoltAttack { get; set; }

        [Required]
        [Range(0, 20, ErrorMessage = "Bullet Use must be between 0 and 20")]
        public int BulletUse { get; set; }

        [Required]
        [Range(0, 1000, ErrorMessage = "Rapid poison must be between 0 and 1000")]
        public int RapidPoison { get; set; }

        [Required]
        [EnumDataType(typeof(ImprintType), ErrorMessage = "Invalid imprint type. Valid values are: \n" +
            "Imprint0, Imprint1, Imprint221, Imprint223, Imprint224, Imprint234")]
        public ImprintType ImprintsNormal { get; set; }

        [Required]
        [EnumDataType(typeof(ImprintType), ErrorMessage = "Invalid imprint type. Valid values are: \n" +
            "Imprint0, Imprint1, Imprint221, Imprint223, Imprint224, Imprint234")]
        public ImprintType ImprintsUncanny { get; set; }

        [Required]
        [EnumDataType(typeof(ImprintType), ErrorMessage = "Invalid imprint type. Valid values are: \n" +
            "Imprint0, Imprint1, Imprint221, Imprint223, Imprint224, Imprint234")]
        public ImprintType ImprintsLost { get; set; }

        [Required]
        [Range(0, 1000, ErrorMessage = "Rally must be between 0 and 1000")]
        public int Rally { get; set; }

        [Required]
        [Range(0, 99, ErrorMessage = "Strength Requirement must be between 0 and 99")]
        public int StrengthRequirement { get; set; }

        [Required]
        [Range(0, 99, ErrorMessage = "Skill Requirement must be between 0 and 99")]
        public int SkillRequirement { get; set; }

        [Required]
        [Range(0, 99, ErrorMessage = "Bloodtinge Requirement must be between 0 and 99")]
        public int BloodtingeRequirement { get; set; }

        [Required]
        [Range(0, 99, ErrorMessage = "Arcane Requirement must be between 0 and 99")]
        public int ArcaneRequirement { get; set; }

        [Required]
        [Range(0, 2000, ErrorMessage = "Max Upgrade Attack must be between 0 and 2000")]
        public int MaxUpgradeAttack { get; set; }

        [Required]
        [Url(ErrorMessage = "Provide valid URL")]
        [Range(0, 500, ErrorMessage = "URL can't be longer than 500 characters")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Scaling Id can't be negative")]
        public int ScalingId { get; set; }
    }
}
