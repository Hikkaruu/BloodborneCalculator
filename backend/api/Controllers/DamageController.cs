using api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DamageController : ControllerBase
    {
        private readonly IDamageService _damageService;

        public DamageController(IDamageService damageService)
        {
            _damageService = damageService ?? throw new ArgumentNullException(nameof(damageService));
        }

        [HttpGet("Firearm/{firearmId}/Boss/{bossId}")]
        public async Task<IActionResult> GetFirearmDamage(int firearmId, int bossId, [FromQuery] int strength, [FromQuery] int skill,
            [FromQuery] int bloodtinge, [FromQuery] int arcane, [FromQuery] int weaponUpgradeLevel)
        {
            try
            {
                var damage = await _damageService.GetFirearmDamage(firearmId, bossId, strength, skill,
                    bloodtinge, arcane, weaponUpgradeLevel);

                return Ok(new { Damage = damage });
            }
            catch (Exception ex)
            {
                return StatusCode(422, $"Error: {ex.Message}");
            }
        }

        [HttpGet("TricksterWeapon/{tricksterWeaponId}/Boss/{bossId}")]
        public async Task<IActionResult> GetTricksterWeaponAttacksDamage(int tricksterWeaponId, int bossId, [FromQuery] int strength, [FromQuery] int skill,
            [FromQuery] int bloodtinge, [FromQuery] int arcane, [FromQuery] int weaponUpgradeLevel)
        {
            try
            {
                var attacksDamageList = await _damageService.GetTricksterWeaponAttacksDamage(tricksterWeaponId, bossId, strength, skill,
                    bloodtinge, arcane, weaponUpgradeLevel);

                return Ok(attacksDamageList);
            }
            catch (Exception ex)
            {
                return StatusCode(422, $"Error: {ex.Message}");
            }
        }
    }
}
