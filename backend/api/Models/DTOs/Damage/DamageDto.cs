using api.Models.Enums;

namespace api.Models.DTOs.Damage
{
    public class DamageDto
    {
        public string? Name { get; set; }
        public int Damage { get; set; }
        public int ExtraDamage { get; set; }
        public int ExtraDamageCount { get; set; }
        public AttackMode AttackMode { get; set; }
    }
}
