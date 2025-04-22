using api.Interfaces;
using api.Models.DTOs.Boss;
using api.Models.Filters;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BossController : ControllerBase
    {
        private readonly IBossService _bossService;
        public BossController(IBossService bossService)
        {
            _bossService = bossService ?? throw new ArgumentNullException(nameof(bossService));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var boss = await _bossService.GetBossByIdAsync(id);

                return Ok(boss);
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
                var bosses = await _bossService.GetAllBossesAsync();

                return Ok(bosses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateBossDto createDto)
        {
            try
            {
                var boss = await _bossService.CreateBossAsync(createDto);

                return CreatedAtAction(nameof(GetByIdAsync), new { id = boss.Id }, boss);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateBossDto updateDto)
        {
            try
            {
                var boss = await _bossService.UpdateBossAsync(id, updateDto);

                if (boss == null)
                    return NotFound($"Boss with ID: {id} not found");

                return Ok(boss);
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
                var result = await _bossService.DeleteBossAsync(id);

                if (!result)
                    return NotFound($"Boss with ID: {id} not found");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetByFilterAsync([FromQuery] BossFilter filter)
        {
            try
            {
                var boss = await _bossService.GetBossesByFilterAsync(filter);

                return Ok(boss);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
