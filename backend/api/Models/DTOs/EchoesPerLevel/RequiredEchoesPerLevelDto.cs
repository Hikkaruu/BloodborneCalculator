using System.ComponentModel.DataAnnotations;

namespace api.Models.DTOs.EchoesPerLevel
{
    public class RequiredEchoesPerLevelDto
    {
        [Required]
        public int RequiredBloodEchoes { get; set; }
    }
}
