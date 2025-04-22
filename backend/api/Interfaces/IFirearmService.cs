using api.Models.DTOs.Firearm;
using api.Models.Filters;

namespace api.Interfaces
{
    public interface IFirearmService
    {
        Task<FirearmDto> GetFirearmByIdAsync(int id);
        Task<IEnumerable<FirearmDto>> GetAllFirearmsAsync();
        Task<FirearmDto> CreateFirearmAsync(CreateFirearmDto createDto);
        Task<FirearmDto> UpdateFirearmAsync(int id, UpdateFirearmDto updateDto);
        Task<bool> DeleteFirearmAsync(int id);
        Task<IEnumerable<FirearmDto>> GetFirearmsByFilterAsync(FirearmFilter filter);
        Task<bool> CanWieldFirearm(int id, int strength, int skill, int bloodtinge, int arcane);
        Task<int> GetFirearmAttackRating(int id, int strength, int skill, int bloodtinge, int arcane, int weaponUpgradeLevel);
    }
}
