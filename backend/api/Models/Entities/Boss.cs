using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api.Models.Entities
{
    [Table("bosses")]
    public class Boss
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
        [Column("health")]
        public int Health { get; set; }

        [Required]
        [Column("blood_echoes")]
        public int BloodEchoes { get; set; }

        [Required]
        [Column("is_interruptible")]
        public bool IsInterruptible { get; set; }

        [Required]
        [Column("is_required")]
        public bool IsRequired { get; set; }

        [Required]
        [Column("is_beast")]
        public bool IsBeast { get; set; }

        [Required]
        [Column("is_kin")]
        public bool IsKin { get; set; }

        [Required]
        [Column("is_weak_to_serrated")]
        public bool IsWeakToSerrated { get; set; }

        [Required]
        [Column("is_weak_to_righteous")]
        public bool IsWeakToRighteous { get; set; }

        [Required]
        [Column("physical_defense")]
        public int PhysicalDefense { get; set; }

        [Required]
        [Column("blunt_defense")]
        public int BluntDefense { get; set; }

        [Required]
        [Column("thrust_defense")]
        public int ThrustDefense { get; set; }

        [Required]
        [Column("bloodtinge_defense")]
        public int BloodtingeDefense { get; set; }

        [Required]
        [Column("arcane_defense")]
        public int ArcaneDefense { get; set; }

        [Required]
        [Column("fire_defense")]
        public int FireDefense { get; set; }

        [Required]
        [Column("bolt_defense")]
        public int BoltDefense { get; set; }

        [Required]
        [Column("slow_poison_resistance")]
        public int SlowPoisonResistance { get; set; }

        [Required]
        [Column("rapid_poison_resistance")]
        public int RapidPoisonResistance { get; set; }

        [Required]
        [Column("image_url")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
