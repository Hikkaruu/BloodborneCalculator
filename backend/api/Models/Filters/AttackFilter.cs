using api.Models.Enums;

namespace api.Models.Filters
{
    public record AttackFilter(
        string? WeaponName = null,
        decimal? Damage = null,
        decimal? ExtraDamage = null,
        int? ExtraDamageCount = null,
        AttackType? AttackType1 = null,
        AttackType? AttackType2 = null,
        AttackMode? AttackMode = null,
        int? WeaponId = null
    )
    {
        public bool HasFilters =>
            !string.IsNullOrWhiteSpace(WeaponName) ||
            Damage.HasValue ||
            ExtraDamage.HasValue ||
            ExtraDamageCount.HasValue ||
            AttackType1.HasValue ||
            AttackType2.HasValue ||
            AttackMode.HasValue ||
            WeaponId.HasValue;
    }
}
