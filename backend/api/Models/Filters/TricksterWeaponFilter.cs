using api.Models.Enums;

namespace api.Models.Filters
{
    public record TricksterWeaponFilter(
        string? TricksterWeaponName = null,

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

        int? RapidPoison = null,
        int? RapidPoisonMin = null,
        int? RapidPoisonMax = null,

        ImprintType? ImprintsNormal = null,
        ImprintType? ImprintsUncanny = null,
        ImprintType? ImprintsLost = null,

        int? Rally = null,
        int? RallyMin = null,
        int? RallyMax = null,

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
        int? ArcaneRequirementMax = null,

        int? MaxUpgradeAttack = null,
        int? MaxUpgradeAttackMin = null,
        int? MaxUpgradeAttackMax = null
    )
    {
        public bool HasFilters =>
            !string.IsNullOrWhiteSpace(TricksterWeaponName) ||
            PhysicalAttack.HasValue || PhysicalAttackMin.HasValue || PhysicalAttackMax.HasValue ||
            BloodAttack.HasValue || BloodAttackMin.HasValue || BloodAttackMax.HasValue ||
            ArcaneAttack.HasValue || ArcaneAttackMin.HasValue || ArcaneAttackMax.HasValue ||
            FireAttack.HasValue || FireAttackMin.HasValue || FireAttackMax.HasValue ||
            BoltAttack.HasValue || BoltAttackMin.HasValue || BoltAttackMax.HasValue ||
            BulletUse.HasValue || BulletUseMin.HasValue || BulletUseMax.HasValue ||
            RapidPoison.HasValue || RapidPoisonMin.HasValue || RapidPoisonMax.HasValue ||
            ImprintsNormal.HasValue || 
            ImprintsUncanny.HasValue ||
            ImprintsLost.HasValue ||
            Rally.HasValue || RallyMin.HasValue || RallyMax.HasValue ||
            StrengthRequirement.HasValue || StrengthRequirementMin.HasValue || StrengthRequirementMax.HasValue ||
            SkillRequirement.HasValue || SkillRequirementMin.HasValue || SkillRequirementMax.HasValue ||
            BloodtingeRequirement.HasValue || BloodtingeRequirementMin.HasValue || BloodtingeRequirementMax.HasValue ||
            ArcaneRequirement.HasValue || ArcaneRequirementMin.HasValue || ArcaneRequirementMax.HasValue ||
            MaxUpgradeAttack.HasValue || MaxUpgradeAttackMin.HasValue || MaxUpgradeAttackMax.HasValue;
    }
}
