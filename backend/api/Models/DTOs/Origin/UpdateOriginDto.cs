using System.ComponentModel.DataAnnotations;

namespace api.Models.DTOs.Origin
{
    public class UpdateOriginDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0, 544)]
        public int Level { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int BloodEchoes { get; set; }

        [Required]
        [Range(0, 500)]
        public int Discovery { get; set; }

        [Required]
        [Range(0, 99)]
        public int Vitality { get; set; }

        [Required]
        [Range(0, 99)]
        public int Endurance { get; set; }

        [Required]
        [Range(0, 99)]
        public int Strength { get; set; }

        [Required]
        [Range(0, 99)]
        public int Skill { get; set; }

        [Required]
        [Range(0, 99)]
        public int Bloodtinge { get; set; }

        [Required]
        [Range(0, 99)]
        public int Arcane { get; set; }
    }
}
