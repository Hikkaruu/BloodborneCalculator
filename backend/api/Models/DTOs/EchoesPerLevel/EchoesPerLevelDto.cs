using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api.Models.DTOs.EchoesPerLevel
{
    public class EchoesPerLevelDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Level { get; set; }


        [Required]
        public int RequiredBloodEchoes { get; set; }
    }
}
