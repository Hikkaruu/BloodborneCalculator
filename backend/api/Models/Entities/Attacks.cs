using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using api.Models.Enums;

namespace api.Models.Entities
{
    [Table("attacks")]
    public class Attacks
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
        public int extra_damage_count { get; set; }

        [Required]
        [Column("attack_type1", TypeName = "nvarchar(20)")]
        public AttackType AttackType1 { get; set; }

        [Column("attack_type2", TypeName = "nvarchar(20)")]
        public AttackType AttackType2 { get; set; }

        [Required]
        [Column("attack_mode", TypeName = "nvarchar(20)")]
        public AttackMode AttackMode { get; set; }

        [Required]
        [Column("trickster_weapon_id")]
        public int TricksterWeaponId { get; set; }

        public TricksterWeapons TricksterWeapons { get; set; } = null!;
    }
}
