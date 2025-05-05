using api.Interfaces;
using api.Models.DTOs.Attack;
using api.Models.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttackController : ControllerBase
    {
        private readonly IAttackService _attackService;
        public AttackController(IAttackService attackService)
        {
            _attackService = attackService ?? throw new ArgumentNullException(nameof(attackService));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var attack = await _attackService.GetAttackByIdAsync(id);

                return Ok(attack);
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
                var attacks = await _attackService.GetAllAttacksAsync();

                return Ok(attacks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateAttackDto createDto)
        {
            try
            {
                var attack = await _attackService.CreateAttackAsync(createDto);

                return CreatedAtAction(nameof(GetByIdAsync), new { id = attack.Id }, attack);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateAttackDto updateDto)
        {
            try
            {
                var updatedAttack = await _attackService.UpdateAttackAsync(id, updateDto);

                return Ok(updatedAttack);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _attackService.DeleteAttackAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetByFilterAsync([FromQuery] AttackFilter filter)
        {
            try
            {
                var attacks = await _attackService.GetAttacksByFilterAsync(filter);

                return Ok(attacks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
