using api.Models.DTOs.Scaling;

namespace api.Interfaces
{
    public interface IScalingService
    {
        Task<ScalingDto> GetScalingByIdAsync(int id);
        Task<IEnumerable<ScalingDto>> GetAllScalingsAsync();
        Task<ScalingDto> GetScalingByWeaponNameAsync(string weaponName);
        Task<ScalingDto> CreateScalingAsync(CreateScalingDto createDto);
        Task<ScalingDto> UpdateScalingAsync(int id, UpdateScalingDto updateDto);
        Task<bool> DeleteScalingAsync(int id);
    }
}
