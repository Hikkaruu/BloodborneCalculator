using api.Models.DTOs.Attack;
using api.Models.Filters;

namespace api.Interfaces
{
    public interface IAttackService
    {
        Task<AttackDto> GetAttackByIdAsync(int id);
        Task<IEnumerable<AttackDto>> GetAllAttacksAsync();
        Task<AttackDto> CreateAttackAsync(CreateAttackDto createDto);
        Task<AttackDto> UpdateAttackAsync(int id, UpdateAttackDto updateDto);
        Task<bool> DeleteAttackAsync(int id);
        Task<IEnumerable<AttackDto>> GetAttacksByFilterAsync(AttackFilter filter);
    }
}
