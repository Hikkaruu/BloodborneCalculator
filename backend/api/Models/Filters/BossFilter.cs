namespace api.Models.Filters
{
    public record BossFilter(
        string? BossName = null,
        int? Health = null,
        int? BloodEchoes = null,
        bool? IsInterruptible = null,
        bool? IsRequired = null,
        bool? IsKin = null,
        bool? IsWeakToSerrated = null,
        bool? IsWeakToRighteous = null,
        int? PhysicalDefense = null,
        int? BluntDefense = null,
        int? ThrustDefense = null,
        int? BloodtingeDefense = null,
        int? ArcaneDefense = null,
        int? FireDefense = null,
        int? BoltDefense = null,
        int? SlowPoisonResistance = null,
        int? RapidPoisonResistance = null
    )
    {
        public bool HasFilters =>
            !string.IsNullOrWhiteSpace(BossName) ||
            Health.HasValue ||
            BloodEchoes.HasValue ||
            IsInterruptible.HasValue ||
            IsRequired.HasValue ||
            IsKin.HasValue ||
            IsWeakToSerrated.HasValue ||
            IsWeakToRighteous.HasValue ||
            PhysicalDefense.HasValue ||
            BluntDefense.HasValue ||
            ThrustDefense.HasValue ||
            BloodtingeDefense.HasValue ||
            ArcaneDefense.HasValue ||
            FireDefense.HasValue ||
            BoltDefense.HasValue ||
            SlowPoisonResistance.HasValue ||
            RapidPoisonResistance.HasValue;
    }
}
