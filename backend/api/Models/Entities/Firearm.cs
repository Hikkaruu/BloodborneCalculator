﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using api.Models.Enums;

namespace api.Models.Entities
{
    [Table("firearms")]
    public class Firearm
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
        [Column("physical_attack")]
        public int PhysicalAttack { get; set; }

        [Required]
        [Column("blood_attack")]
        public int BloodAttack { get; set; }

        [Required]
        [Column("arcane_attack")]
        public int ArcaneAttack { get; set; }

        [Required]
        [Column("fire_attack")]
        public int FireAttack { get; set; }

        [Required]
        [Column("bolt_attack")]
        public int BoltAttack { get; set; }

        [Required]
        [Column("bullet_use")]
        public int BulletUse { get; set; }

        [Required]
        [Column("imprints", TypeName = "varchar(20)")]
        public ImprintType Imprints { get; set; }

        [Required]
        [Column("strength_requirement")]
        public int StrengthRequirement { get; set; }

        [Required]
        [Column("skill_requirement")]
        public int SkillRequirement { get; set; }

        [Required]
        [Column("bloodtinge_requirement")]
        public int BloodtingeRequirement { get; set; }

        [Required]
        [Column("arcane_requirement")]
        public int ArcaneRequirement { get; set; }

        [Required]
        [Column("image_url")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Column("scaling_id")]
        public int ScalingId { get; set; }

        public Scaling Scalings { get; set; } = null!;
    }
}
