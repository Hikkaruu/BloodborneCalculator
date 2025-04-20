using api.Models.DTOs.TricksterWeapon;
using api.Models.Filters;

namespace api.Interfaces
{
    public interface ITricksterWeaponService
    {
        Task<TricksterWeaponDto> GetTricksterWeaponByIdAsync(int id);
        Task<IEnumerable<TricksterWeaponDto>> GetAllTricksterWeaponsAsync();
        Task<TricksterWeaponDto> CreateTricksterWeaponAsync(CreateTricksterWeaponDto createDto);
        Task<TricksterWeaponDto> UpdateTricksterWeaponAsync(int id, UpdateTricksterWeaponDto updateDto);
        Task<bool> DeleteTricksterWeaponAsync(int id);
        Task<IEnumerable<TricksterWeaponDto>> GetTricksterWeaponsByFilterAsync(TricksterWeaponFilter filter);
    }
}
