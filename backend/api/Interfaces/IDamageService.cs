using api.Models.DTOs.Damage;

namespace api.Interfaces
{
    public interface IDamageService
    {
        double CalculateDamage(double attackRating, double defense);
        Task<int> GetFirearmDamage(int firearmId, int bossId, int strength, int skill,
            int bloodtinge, int arcane, int weaponUpgradeLevel);

        Task<List<DamageDto>> GetTricksterWeaponAttacksDamage(int firearmId, int bossId, int strength, int skill,
            int bloodtinge, int arcane, int weaponUpgradeLevel);
    }
}
