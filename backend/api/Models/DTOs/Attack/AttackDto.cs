using api.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace api.Models.DTOs.Attack
{
    public class AttackDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0, 9.99)]
        public decimal Damage { get; set; }

        [Required]
        [Range(0, 9.99)]
        public decimal ExtraDamage { get; set; }

        [Range(0, int.MaxValue)]
        public int ExtraDamageCount { get; set; }

        [Required]
        public AttackType AttackType1 { get; set; }

        public AttackType? AttackType2 { get; set; }

        [Required]
        public AttackMode AttackMode { get; set; }

        public int TricksterWeaponId { get; set; }
        public string? TricksterWeaponName { get; set; } 
    }
}
