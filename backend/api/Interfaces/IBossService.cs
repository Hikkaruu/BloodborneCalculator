using api.Models.DTOs.Boss;

namespace api.Interfaces
{
    public interface IBossService
    {
        Task<BossDto> GetBossByIdAsync(int id);
        Task<IEnumerable<BossDto>> GetAllBossesAsync();
        Task<BossDto> CreateBossAsync(CreateBossDto createDto);
        Task<BossDto> UpdateBossAsync(int id, UpdateBossDto updateDto);
        Task<bool> DeleteBossAsync(int id);
    }
}
