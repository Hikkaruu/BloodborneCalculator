using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using api.Models.Enums;

namespace api.Models.Entities
{
    [Table("attacks")]
    public class Attack
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Precision(3, 2)]
        [Column("damage")]
        public decimal Damage { get; set; }

        [Required]
        [Precision(3, 2)]
        [Column("extra_damage")]
        public decimal ExtraDamage { get; set; }

        [Column("extra_damage_count")]
        public int ExtraDamageCount { get; set; }

        [Required]
        [Column("attack_type1", TypeName = "varchar(20)")]
        public AttackType AttackType1 { get; set; }

        [Column("attack_type2", TypeName = "varchar(20)")]
        public AttackType AttackType2 { get; set; }

        [Required]
        [Column("attack_mode", TypeName = "varchar(20)")]
        public AttackMode AttackMode { get; set; }

        [Required]
        [Column("trickster_weapon_id")]
        public int TricksterWeaponId { get; set; }

        public TricksterWeapon TricksterWeapons { get; set; } = null!;
    }
}
