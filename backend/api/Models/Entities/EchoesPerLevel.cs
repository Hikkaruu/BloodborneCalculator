using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api.Models.Entities
{
    [Table("echoes_per_level")]
    public class EchoesPerLevel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("level")]
        public int Level { get; set; }


        [Required]
        [Column("required_blood_echoes")]
        public int RequiredBloodEchoes { get; set; }
    }
}
