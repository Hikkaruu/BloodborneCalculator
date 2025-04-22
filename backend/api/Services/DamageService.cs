using api.Interfaces;
using api.Models.DTOs.Boss;
using api.Models.DTOs.Firearm;

namespace api.Services
{
    public class DamageService : IDamageService
    {
        private readonly IBossService _bossService;
        private readonly IFirearmService _firearmService;
        private readonly ITricksterWeaponService _tricksterWeaponService;
        private readonly IAttackService _attackService;

        public DamageService(IBossService bossService, IFirearmService firearmService, 
            ITricksterWeaponService tricksterWeaponService, IAttackService attackService)
        {
            _bossService = bossService;
            _firearmService = firearmService;
            _tricksterWeaponService = tricksterWeaponService;
            _attackService = attackService;
        }

        public double CalculateDamage(double attackRating, double defense)
        {
            double ratio = attackRating / defense;

            if (defense > 8 * attackRating)
            {
                return 0.1 * attackRating;
            }
            else if (defense > attackRating && defense <= 8 * attackRating)
            {
                return (19.2 / 49 * Math.Pow((ratio - 0.125), 2) + 0.1) * attackRating;
            }
            else if (defense > 0.4 * attackRating && defense <= attackRating)
            {
                return (-0.4 / 3 * Math.Pow((ratio - 2.5), 2) + 0.7) * attackRating;
            }
            else if (defense > 0.125 * attackRating && defense <= 0.4 * attackRating)
            {
                return (-0.8 / 121 * Math.Pow((ratio - 8), 2) + 0.9) * attackRating;
            }
            else
            {
                return 0.9 * attackRating;
            }
        }

        public async Task<int> GetDamage(int firearmId, int bossId, int strength, int skill, 
            int bloodtinge, int arcane, int weaponUpgradeLevel)
        {
            var boss = await _bossService.GetBossByIdAsync(bossId);
            var firearm = await _firearmService.GetFirearmByIdAsync(firearmId);
            var attackRating = await _firearmService.GetFirearmAttackRating(firearmId, strength, skill, bloodtinge, arcane, weaponUpgradeLevel);
            double damage = 0;

            if (firearm.PhysicalAttack > 0)
                damage += CalculateDamage(attackRating, boss.PhysicalDefense);

            if (firearm.BloodAttack > 0)
                damage += CalculateDamage(attackRating, boss.BloodtingeDefense);

            if (firearm.ArcaneAttack > 0)
                damage += CalculateDamage(attackRating, boss.ArcaneDefense);

            if (firearm.FireAttack > 0)
                damage += CalculateDamage(attackRating, boss.FireDefense);

            if (firearm.BoltAttack > 0)
                damage += CalculateDamage(attackRating, boss.BoltDefense);

            return (int)Math.Round(damage);
        }
    }
}
