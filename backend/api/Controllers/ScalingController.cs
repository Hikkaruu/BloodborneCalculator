using api.Interfaces;
using api.Models.DTOs.Scaling;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScalingController : ControllerBase
    {
        private readonly IScalingService _scalingService;

        public ScalingController(IScalingService scalingService)
        {
            _scalingService = scalingService ?? throw new ArgumentNullException(nameof(scalingService));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var scaling = await _scalingService.GetScalingByIdAsync(id);
                return Ok(scaling);
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
                var scalings = await _scalingService.GetAllScalingsAsync();
                return Ok(scalings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateScalingDto createDto)
        {
            try
            {
                var scaling = await _scalingService.CreateScalingAsync(createDto);
                return CreatedAtAction(nameof(GetByIdAsync), new { id = scaling.Id }, scaling);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateScalingDto updateDto)
        {
            try
            {
                var scaling = await _scalingService.UpdateScalingAsync(id, updateDto);
                if (scaling == null) return NotFound($"Scaling with ID: {id} not found");
                
                return Ok(scaling);
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
                var result = await _scalingService.DeleteScalingAsync(id);
                if (!result) return NotFound($"Scaling with ID: {id} not found");
                
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
