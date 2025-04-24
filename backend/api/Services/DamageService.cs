using api.Interfaces;
using api.Models.DTOs.Boss;
using api.Models.DTOs.Damage;
using api.Models.DTOs.Firearm;
using api.Models.DTOs.TricksterWeapon;
using api.Models.Entities;
using api.Models.Enums;
using System.Collections;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

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
            if (attackRating <= 0 || defense <= 0) return 0;

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

        public async Task<int> GetFirearmDamage(int firearmId, int bossId, int strength, int skill, 
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

        public int GetBossDefenseByAttackType(AttackType? attackType, BossDto boss) => attackType switch
        {
            AttackType.None => 0,
            AttackType.Physical => boss.PhysicalDefense, 
            AttackType.Blunt => boss.BluntDefense,
            AttackType.Thrust => boss.ThrustDefense,
            AttackType.Blood => boss.BloodtingeDefense,
            AttackType.Arcane => boss.ArcaneDefense,
            AttackType.Fire => boss.FireDefense,
            AttackType.Bolt => boss.BoltDefense,
            _ => throw new ArgumentException("Wrong argument")
        };

        public int GetAttackRatingByAttackType(AttackType? attackType, int[] attackRating) => attackType switch
        {
            AttackType.None => 0,
            AttackType.Physical => attackRating[0],
            AttackType.Blunt => attackRating[0],
            AttackType.Thrust => attackRating[0],
            AttackType.Blood => attackRating[1],
            AttackType.Arcane => attackRating[2],
            AttackType.Fire => attackRating[3],
            AttackType.Bolt => attackRating[4],
            _ => throw new ArgumentException("Wrong argument")
        };

        public int GetFinalDamage(AttackType? attackType, decimal attackDamage, BossDto boss, int[] attackRating)
        {
            return (int)Math.Round(
                CalculateDamage(GetAttackRatingByAttackType(attackType, attackRating) * (double)attackDamage,
                            GetBossDefenseByAttackType(attackType, boss)));
        }

        public async Task<List<DamageDto>> GetTricksterWeaponAttacksDamage(int tricksterWeaponId, int bossId, int strength, int skill,
            int bloodtinge, int arcane, int weaponUpgradeLevel)
        {
            var boss = await _bossService.GetBossByIdAsync(bossId);
            var tricksterWeapon = await _tricksterWeaponService.GetTricksterWeaponByIdAsync(tricksterWeaponId);
            var attackRating = await _tricksterWeaponService.GetTricksterWeaponAttackRating(tricksterWeaponId, strength, skill, bloodtinge, arcane, weaponUpgradeLevel);
            var attacks = tricksterWeapon.Attacks;

            if (attacks == null || attackRating == null)
                throw new Exception("No attacks found for this Trickster Weapon");

            List<DamageDto> damageList = new();         

            foreach (var attack in attacks)
            {
                damageList.Add(new DamageDto {
                        Name = attack.Name,
                        Damage = GetFinalDamage(attack.AttackType1, attack.Damage, boss, attackRating)               
                            + GetFinalDamage(attack.AttackType2, attack.Damage, boss, attackRating), 
                        ExtraDamage = GetFinalDamage(attack.AttackType1, attack.ExtraDamage, boss, attackRating)       
                            + GetFinalDamage(attack.AttackType2, attack.ExtraDamage, boss, attackRating), 
                        ExtraDamageCount = attack.ExtraDamageCount,
                        AttackMode = attack.AttackMode
                    }
                );             
            }

            return damageList;
        }
    }
}
