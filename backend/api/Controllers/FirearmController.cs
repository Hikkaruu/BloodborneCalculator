using api.Interfaces;
using api.Models.DTOs.Firearm;
using api.Models.Filters;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FirearmController : ControllerBase
    {
        private readonly IFirearmService _firearmService;
        public FirearmController(IFirearmService firearmService)
        {
            _firearmService = firearmService ?? throw new ArgumentNullException(nameof(firearmService));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var firearm = await _firearmService.GetFirearmByIdAsync(id);

                return Ok(firearm);
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
                var firearms = await _firearmService.GetAllFirearmsAsync();

                return Ok(firearms);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateFirearmDto createDto)
        {
            try
            {
                var firearm = await _firearmService.CreateFirearmAsync(createDto);

                return CreatedAtAction(nameof(GetByIdAsync), new { id = firearm.Id }, firearm);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateFirearmDto updateDto)
        {
            try
            {
                var firearm = await _firearmService.UpdateFirearmAsync(id, updateDto);

                if (firearm == null)
                    return NotFound($"Firearm with ID: {id} not found");

                return Ok(firearm);
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
                var result = await _firearmService.DeleteFirearmAsync(id);

                if (!result)
                    return NotFound($"Firearm with ID: {id} not found");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetByFilterAsync([FromQuery] FirearmFilter filter)
        {
            try
            {
                var firearms = await _firearmService.GetFirearmsByFilterAsync(filter);

                return Ok(firearms);
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
                var canWield = await _firearmService.CanWieldFirearm(id, strength, skill, bloodtinge, arcane);

                return Ok(new { CanWield = canWield });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("attack-rating/{id}")]
        public async Task<IActionResult> GetAttackRatingAsync(int id, [FromQuery] int strength, [FromQuery] int skill,
            [FromQuery] int bloodtinge, [FromQuery] int arcane, [FromQuery] int weaponUpgradeLevel)
        {
            try
            {
                var attackRating = await _firearmService.GetFirearmAttackRating(id, strength, skill, bloodtinge, arcane, weaponUpgradeLevel);

                return Ok(new { AttackRating = attackRating });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
