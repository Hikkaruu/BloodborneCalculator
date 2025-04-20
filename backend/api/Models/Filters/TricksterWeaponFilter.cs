using api.Models.Enums;

namespace api.Models.Filters
{
    public record TricksterWeaponFilter(
        string? TricksterWeaponName = null,
        int? PhysicalAttack = null,
        int? BloodAttack = null,
        int? ArcaneAttack = null,
        int? FireAttack = null,
        int? BoltAttack = null,
        int? BulletUse = null,
        int? RapidPoison = null,
        ImprintType? ImprintsNormal = null,
        ImprintType? ImprintsUncanny = null,
        ImprintType? ImprintsLost = null,
        int? Rally = null,
        int? StrengthRequirement = null,
        int? SkillRequirement = null,
        int? BloodtingeRequirement = null,
        int? ArcaneRequirement = null,
        int? MaxUpgradeAttack = null
    )
    {
        public bool HasFilters =>
            !string.IsNullOrWhiteSpace(TricksterWeaponName) ||
            PhysicalAttack.HasValue ||
            BloodAttack.HasValue ||
            ArcaneAttack.HasValue ||
            FireAttack.HasValue ||
            BoltAttack.HasValue ||
            BulletUse.HasValue ||
            RapidPoison.HasValue ||
            ImprintsNormal.HasValue ||
            ImprintsUncanny.HasValue ||
            ImprintsLost.HasValue ||
            Rally.HasValue ||
            StrengthRequirement.HasValue ||
            SkillRequirement.HasValue ||
            BloodtingeRequirement.HasValue ||
            ArcaneRequirement.HasValue ||
            MaxUpgradeAttack.HasValue;
    }
}
