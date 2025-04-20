using api.Models.Enums;
using System.Xml.Linq;

namespace api.Models.Filters
{
    public record FirearmFilter(
        string? FirearmName = null,
        int? PhysicalAttack = null,
        int? BloodAttack = null,
        int? ArcaneAttack = null,
        int? FireAttack = null,
        int? BoltAttack = null,
        int? BulletUse = null,
        ImprintType? Imprints = null,
        int? StrengthRequirement = null,
        int? SkillRequirement = null,
        int? BloodtingeRequirement = null,
        int? ArcaneRequirement = null
    )
    {
        public bool HasFilters =>
            !string.IsNullOrWhiteSpace(FirearmName) ||
            PhysicalAttack.HasValue ||
            BloodAttack.HasValue ||
            ArcaneAttack.HasValue ||
            FireAttack.HasValue ||
            BoltAttack.HasValue ||
            BulletUse.HasValue ||
            Imprints.HasValue ||
            StrengthRequirement.HasValue ||
            SkillRequirement.HasValue ||
            BloodtingeRequirement.HasValue ||
            ArcaneRequirement.HasValue;    
    }
}
