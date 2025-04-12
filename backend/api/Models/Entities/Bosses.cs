using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api.Models.Entities
{
    public class Bosses
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
    }
}
