using api.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace api.Models.DTOs.TricksterWeapon
{
    public class AttackForTricksterWeaponDto
    {
        public string Name { get; set; } = string.Empty;

        public decimal Damage { get; set; }

        public decimal ExtraDamage { get; set; }

        public int ExtraDamageCount { get; set; }

        public AttackType AttackType1 { get; set; }

        public AttackType? AttackType2 { get; set; }

        public AttackMode AttackMode { get; set; }
    }
}
