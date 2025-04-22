namespace api.Interfaces
{
    public interface IDamageService
    {
        double CalculateDamage(double attackRating, double defense);
        Task<int> GetDamage(int firearmId, int bossId, int strength, int skill,
            int bloodtinge, int arcane, int weaponUpgradeLevel);
    }
}
