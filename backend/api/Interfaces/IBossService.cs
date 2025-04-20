using api.Models.DTOs.Boss;
using api.Models.Filters;

namespace api.Interfaces
{
    public interface IBossService
    {
        Task<BossDto> GetBossByIdAsync(int id);
        Task<IEnumerable<BossDto>> GetAllBossesAsync();
        Task<BossDto> CreateBossAsync(CreateBossDto createDto);
        Task<BossDto> UpdateBossAsync(int id, UpdateBossDto updateDto);
        Task<bool> DeleteBossAsync(int id);
        Task<IEnumerable<BossDto>> GetAttacksByFilterAsync(BossFilter filter);
    }
}
