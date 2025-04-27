using System.ComponentModel.DataAnnotations;

namespace api.Models.DTOs.Origin
{
    public class OptimalOriginDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int Level { get; set; }
    }
}
