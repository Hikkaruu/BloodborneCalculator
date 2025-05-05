using api.Interfaces;
using api.Models.DTOs.TricksterWeapon;
using api.Models.Filters;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TricksterWeaponController : ControllerBase
    {
        private readonly ITricksterWeaponService _tricksterWeaponService;

        public TricksterWeaponController(ITricksterWeaponService tricksterWeaponService)
        {
            _tricksterWeaponService = tricksterWeaponService ?? throw new ArgumentNullException(nameof(tricksterWeaponService));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var weapon = await _tricksterWeaponService.GetTricksterWeaponByIdAsync(id);

                if (weapon == null)
                    return NotFound($"Trickster Weapon with ID: {id} not found");

                return Ok(weapon);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var weapons = await _tricksterWeaponService.GetAllTricksterWeaponsAsync();

                if (weapons == null)
                    return NotFound($"Trickster Weapons not found");

                return Ok(weapons);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateTricksterWeaponDto createDto)
        {
            try
            {
                var weapon = await _tricksterWeaponService.CreateTricksterWeaponAsync(createDto);
                return CreatedAtAction(nameof(GetByIdAsync), new { id = weapon.Id }, weapon);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateTricksterWeaponDto updateDto)
        {
            try
            {
                var weapon = await _tricksterWeaponService.UpdateTricksterWeaponAsync(id, updateDto);
                return Ok(weapon);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _tricksterWeaponService.DeleteTricksterWeaponAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetByFilterAsync([FromQuery] TricksterWeaponFilter filter)
        { 
            try
            {
                var weapons = await _tricksterWeaponService.GetTricksterWeaponsByFilterAsync(filter);
                return Ok(weapons);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("can-wield/{id}")]
        public async Task<IActionResult> CanWieldAsync(int id, [FromQuery] int strength, [FromQuery] int skill,
            [FromQuery] int bloodtinge, [FromQuery] int arcane)
        {
            try
            {
                var canWield = await _tricksterWeaponService.CanWieldTricksterWeapon(id, strength, skill, bloodtinge, arcane);

                return Ok(new { CanWield = canWield });
            }
            catch (Exception ex)
            {
                return StatusCode(422, $"Error: {ex.Message}");
            }
        }

        [HttpGet("attack-rating/{id}")]
        public async Task<IActionResult> GetAttackRatingAsync(int id, [FromQuery] int strength, [FromQuery] int skill,
            [FromQuery] int bloodtinge, [FromQuery] int arcane, [FromQuery] int weaponUpgradeLevel)
        {
            try
            {
                var attackRating = await _tricksterWeaponService.GetTricksterWeaponAttackRating(id, strength, skill, bloodtinge, arcane, weaponUpgradeLevel);

                return Ok(new 
                { 
                    PhysicalAttackRating = attackRating[0],
                    BloodAttackRating = attackRating[1],
                    ArcaneAttackRating = attackRating[2],
                    FireAttackRating = attackRating[3],
                    BoltAttackRating = attackRating[4]
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
