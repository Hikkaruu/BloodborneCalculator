using api.Interfaces;
using api.Models.DTOs.Origin;
using api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OriginController : ControllerBase
    {
        private readonly IOriginService _originService;
        public OriginController(IOriginService originService) 
        {
            _originService = originService ?? throw new ArgumentNullException(nameof(originService));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var origin = await _originService.GetOriginByIdAsync(id);

                return Ok(origin);
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
                var origins = await _originService.GetAllOriginsAsync();

                return Ok(origins);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateOriginDto createDto)
        {
            try
            {
                var origin = await _originService.CreateOriginAsync(createDto);

                return CreatedAtAction(nameof(GetByIdAsync), new { id = origin.Id }, origin);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateOriginDto updateDto)
        {
            try
            {
                var origin = await _originService.UpdateOriginAsync(id, updateDto);

                return Ok(origin);
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
                var result = await _originService.DeleteOriginAsync(id);

                if (result)
                    return NoContent();

                return NotFound($"Origin with ID: {id} not found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("optimal_origins")]
        public async Task<IActionResult> GetOptimalOriginAsync(int desiredVitality,
                    int desiredEndurance, int desiredStrength, int desiredSkill, int desiredBloodtinge, int desiredArcane)
        {
            try
            {
                var optimalOrigins = await _originService.GetOptimalOriginsByDesiredStats(desiredVitality,
                    desiredEndurance, desiredStrength, desiredSkill, desiredBloodtinge, desiredArcane);

                return Ok(optimalOrigins);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
