using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api.Models.Entities
{
    [Table("origins")]
    public class Origin
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
        [Column("level")]
        public int Level { get; set; }

        [Required]
        [Column("blood_echoes")]
        public int BloodEchoes { get; set; }

        [Required]
        [Column("discovery")]
        public int Discovery { get; set; }

        [Required]
        [Column("vitality")]
        public int Vitality { get; set; }

        [Required]
        [Column("endurance")]
        public int Endurance { get; set; }

        [Required]
        [Column("strength")]
        public int Strength { get; set; }

        [Required]
        [Column("skill")]
        public int Skill { get; set; }

        [Required]
        [Column("bloodtinge")]
        public int Bloodtinge { get; set; }

        [Required]
        [Column("arcane")]
        public int Arcane { get; set; }
    }
}
