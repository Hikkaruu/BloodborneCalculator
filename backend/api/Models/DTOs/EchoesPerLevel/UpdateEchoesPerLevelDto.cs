using System.ComponentModel.DataAnnotations;

namespace api.Models.DTOs.EchoesPerLevel
{
    public class UpdateEchoesPerLevelDto
    {
        [Required]
        public int Level { get; set; }


        [Required]
        public int RequiredBloodEchoes { get; set; }
    }
}
