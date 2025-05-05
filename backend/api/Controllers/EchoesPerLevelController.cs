using api.Interfaces;
using api.Models.DTOs.EchoesPerLevel;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EchoesPerLevelController : ControllerBase
    {
        private readonly IEchoesPerLevelService _echoesPerLevelService;

        public EchoesPerLevelController(IEchoesPerLevelService echoesPerLevelService)
        {
            _echoesPerLevelService = echoesPerLevelService ?? throw new ArgumentNullException(nameof(echoesPerLevelService));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var echoesPerLevel = await _echoesPerLevelService.GetEchoesPerLevelByIdAsync(id);

                return Ok(echoesPerLevel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("level/{level}")]
        public async Task<IActionResult> GetByLevelAsync(int level)
        {
            try
            {
                var echoesPerLevel = await _echoesPerLevelService.GetEchoesPerLevelByLevelAsync(level);

                return Ok(echoesPerLevel);
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
                var echoesPerLevel = await _echoesPerLevelService.GetAllEchoesPerLevelsAsync();

                return Ok(echoesPerLevel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateEchoesPerLevelDto createDto)
        {
            try
            {
                var echoesPerLevel = await _echoesPerLevelService.CreateEchoesPerLevelAsync(createDto);

                return CreatedAtAction(nameof(GetByIdAsync), new { id = echoesPerLevel.Id }, echoesPerLevel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateEchoesPerLevelDto updateDto)
        {
            try
            {
                var echoesPerLevel = await _echoesPerLevelService.UpdateEchoesPerLevelAsync(id, updateDto);

                return Ok(echoesPerLevel);
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
                var result = await _echoesPerLevelService.DeleteEchoesPerLevelAsync(id);

                if (result)
                    return NoContent();

                return NotFound($"EchoesPerLevel with ID: {id} not found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
