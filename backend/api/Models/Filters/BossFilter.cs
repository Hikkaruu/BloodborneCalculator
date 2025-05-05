namespace api.Models.Filters
{
    public record BossFilter(
        string? BossName = null,

        int? Health = null,
        int? HealthMin = null,
        int? HealthMax = null,

        int? BloodEchoes = null,
        int? BloodEchoesMin = null,
        int? BloodEchoesMax = null,

        bool? IsInterruptible = null,
        bool? IsRequired = null,
        bool? IsBeast = null,
        bool? IsKin = null,
        bool? IsWeakToSerrated = null,
        bool? IsWeakToRighteous = null,

        int? PhysicalDefense = null,
        int? PhysicalDefenseMin = null,
        int? PhysicalDefenseMax = null,

        int? BluntDefense = null,
        int? BluntDefenseMin = null,
        int? BluntDefenseMax = null,

        int? ThrustDefense = null,
        int? ThrustDefenseMin = null,
        int? ThrustDefenseMax = null,

        int? BloodtingeDefense = null,
        int? BloodtingeDefenseMin = null,
        int? BloodtingeDefenseMax = null,

        int? ArcaneDefense = null,
        int? ArcaneDefenseMin = null,
        int? ArcaneDefenseMax = null,

        int? FireDefense = null,
        int? FireDefenseMin = null,
        int? FireDefenseMax = null,

        int? BoltDefense = null,
        int? BoltDefenseMin = null,
        int? BoltDefenseMax = null,

        int? SlowPoisonResistance = null,
        int? SlowPoisonResistanceMin = null,
        int? SlowPoisonResistanceMax = null,

        int? RapidPoisonResistance = null,
        int? RapidPoisonResistanceMin = null,
        int? RapidPoisonResistanceMax = null
)
    {
        public bool HasFilters =>
            !string.IsNullOrWhiteSpace(BossName) ||
            Health.HasValue || HealthMin.HasValue || HealthMax.HasValue ||
            BloodEchoes.HasValue || BloodEchoesMin.HasValue || BloodEchoesMax.HasValue ||
            IsInterruptible.HasValue ||
            IsRequired.HasValue ||
            IsBeast.HasValue ||
            IsKin.HasValue ||
            IsWeakToSerrated.HasValue ||
            IsWeakToRighteous.HasValue ||
            PhysicalDefense.HasValue || PhysicalDefenseMin.HasValue || PhysicalDefenseMax.HasValue ||
            BluntDefense.HasValue || BluntDefenseMin.HasValue || BluntDefenseMax.HasValue ||
            ThrustDefense.HasValue || ThrustDefenseMin.HasValue || ThrustDefenseMax.HasValue ||
            BloodtingeDefense.HasValue || BloodtingeDefenseMin.HasValue || BloodtingeDefenseMax.HasValue ||
            ArcaneDefense.HasValue || ArcaneDefenseMin.HasValue || ArcaneDefenseMax.HasValue ||
            FireDefense.HasValue || FireDefenseMin.HasValue || FireDefenseMax.HasValue ||
            BoltDefense.HasValue || BoltDefenseMin.HasValue || BoltDefenseMax.HasValue ||
            SlowPoisonResistance.HasValue || SlowPoisonResistanceMin.HasValue || SlowPoisonResistanceMax.HasValue ||
            RapidPoisonResistance.HasValue || RapidPoisonResistanceMin.HasValue || RapidPoisonResistanceMax.HasValue;
    }


}
