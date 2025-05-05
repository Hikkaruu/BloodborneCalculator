using api.Models.Enums;

namespace api.Models.Filters
{
    public record AttackFilter(
        string? AttackName = null,
        decimal? Damage = null,
        decimal? DamageMin = null,
        decimal? DamageMax = null,
        decimal? ExtraDamage = null,
        decimal? ExtraDamageMin = null,
        decimal? ExtraDamageMax = null,
        int? ExtraDamageCount = null,
        int? ExtraDamageCountMin = null,
        int? ExtraDamageCountMax = null,
        AttackType? AttackType1 = null,
        AttackType? AttackType2 = null,
        AttackMode? AttackMode = null,
        int? WeaponId = null
    )
    {
        public bool HasFilters =>
            !string.IsNullOrWhiteSpace(AttackName) ||
            Damage.HasValue || DamageMin.HasValue || DamageMax.HasValue ||
            ExtraDamage.HasValue || ExtraDamageMin.HasValue || ExtraDamageMax.HasValue ||
            ExtraDamageCount.HasValue || ExtraDamageCountMin.HasValue || ExtraDamageCountMax.HasValue ||
            AttackType1.HasValue ||
            AttackType2.HasValue ||
            AttackMode.HasValue ||
            WeaponId.HasValue;
    }
}
