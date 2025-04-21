using api.Models.Enums;
using System.Xml.Linq;

namespace api.Models.Filters
{
    public record FirearmFilter(
        string? FirearmName = null,

        int? PhysicalAttack = null,
        int? PhysicalAttackMin = null,
        int? PhysicalAttackMax = null,

        int? BloodAttack = null,
        int? BloodAttackMin = null,
        int? BloodAttackMax = null,

        int? ArcaneAttack = null,
        int? ArcaneAttackMin = null,
        int? ArcaneAttackMax = null,

        int? FireAttack = null,
        int? FireAttackMin = null,
        int? FireAttackMax = null,

        int? BoltAttack = null,
        int? BoltAttackMin = null,
        int? BoltAttackMax = null,

        int? BulletUse = null,
        int? BulletUseMin = null,
        int? BulletUseMax = null,

        ImprintType? Imprints = null,

        int? StrengthRequirement = null,
        int? StrengthRequirementMin = null,
        int? StrengthRequirementMax = null,

        int? SkillRequirement = null,
        int? SkillRequirementMin = null,
        int? SkillRequirementMax = null,

        int? BloodtingeRequirement = null,
        int? BloodtingeRequirementMin = null,
        int? BloodtingeRequirementMax = null,

        int? ArcaneRequirement = null,
        int? ArcaneRequirementMin = null,
        int? ArcaneRequirementMax = null
    )
    {
        public bool HasFilters =>
            !string.IsNullOrWhiteSpace(FirearmName) ||
            PhysicalAttack.HasValue || PhysicalAttackMin.HasValue || PhysicalAttackMax.HasValue ||
            BloodAttack.HasValue || BloodAttackMin.HasValue || BloodAttackMax.HasValue ||
            ArcaneAttack.HasValue || ArcaneAttackMin.HasValue || ArcaneAttackMax.HasValue ||
            FireAttack.HasValue || FireAttackMin.HasValue || FireAttackMax.HasValue ||
            BoltAttack.HasValue || BoltAttackMin.HasValue || BoltAttackMax.HasValue ||
            BulletUse.HasValue || BulletUseMin.HasValue || BulletUseMax.HasValue ||
            Imprints.HasValue || 
            StrengthRequirement.HasValue || StrengthRequirementMin.HasValue || StrengthRequirementMax.HasValue ||
            SkillRequirement.HasValue || SkillRequirementMin.HasValue || SkillRequirementMax.HasValue ||
            BloodtingeRequirement.HasValue || BloodtingeRequirementMin.HasValue || BloodtingeRequirementMax.HasValue ||
            ArcaneRequirement.HasValue || ArcaneRequirementMin.HasValue || ArcaneRequirementMax.HasValue;    
    }
}
