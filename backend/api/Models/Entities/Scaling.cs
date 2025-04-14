using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace api.Models.Entities
{
    [Table("scalings")]
    public class Scaling
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
        [Column("strength_scaling")]
        public decimal StrengthScaling { get; set; }

        [Required]
        [Precision(3, 2)]
        [Column("skill_scaling")]
        public decimal SkillScaling { get; set; }

        [Required]
        [Precision(3, 2)]
        [Column("bloodtinge_scaling")]
        public decimal BloodtingeScaling { get; set; }

        [Required]
        [Precision(3, 2)]
        [Column("arcane_scaling")]
        public decimal ArcaneScaling { get; set; }

        [Required]
        [Precision(3, 2)]
        [Column("strength_step")]
        public decimal StrengthStep { get; set; }

        [Required]
        [Precision(3, 2)]
        [Column("skill_step")]
        public decimal SkillStep { get; set; }

        [Required]
        [Precision(3, 2)]
        [Column("bloodtinge_step")]
        public decimal BloodtingeStep { get; set; }

        [Required]
        [Precision(3, 3)]
        [Column("arcane_step")]
        public decimal ArcaneStep { get; set; }

        public TricksterWeapon TricksterWeapons { get; set; } = null!;
        public Firearm Firearms { get; set; } = null!;
    }
}   
