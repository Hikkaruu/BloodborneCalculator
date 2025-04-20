using api.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace api.Models.DTOs.Attack
{
    public class CreateAttackDto
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0.01, 9.99, ErrorMessage = "Damage must be between 0.01 and 9.99")]
        public decimal Damage { get; set; }

        [Required]
        [Range(0, 9.99, ErrorMessage = "Extra Damage must be between 0.01 and 9.99")]
        public decimal ExtraDamage { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Extra Damage Count can't be negative")]
        public int ExtraDamageCount { get; set; } = 0;

        [Required]
        [EnumDataType(typeof(AttackType), ErrorMessage = "Invalid Attack Type. Valid values are: \n" +
            "None, Physical, Blunt, Thrust, Blood, Arcane, Fire, Bolt")]
        public AttackType AttackType1 { get; set; }

        [EnumDataType(typeof(AttackType), ErrorMessage = "Invalid Attack Type. Valid values are: \n" +
            "None, Physical, Blunt, Thrust, Blood, Arcane, Fire, Bolt")]
        public AttackType? AttackType2 { get; set; }

        [Required]
        [EnumDataType(typeof(AttackMode), ErrorMessage = "Invalid Attack Mode. Valid values are: \n" +
            "Normal, Transformed")]
        public AttackMode AttackMode { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "TricksterWeapon ID is required")]
        public int TricksterWeaponId { get; set; }
    }
}
