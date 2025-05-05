using api.Models.DTOs.EchoesPerLevel;

namespace api.Interfaces
{
    public interface IEchoesPerLevelService
    {
        Task<EchoesPerLevelDto> GetEchoesPerLevelByIdAsync(int id);
        Task<RequiredEchoesPerLevelDto> GetEchoesPerLevelByLevelAsync(int level);
        Task<IEnumerable<EchoesPerLevelDto>> GetAllEchoesPerLevelsAsync();
        Task<EchoesPerLevelDto> CreateEchoesPerLevelAsync(CreateEchoesPerLevelDto createDto);
        Task<EchoesPerLevelDto> UpdateEchoesPerLevelAsync(int id, UpdateEchoesPerLevelDto echoesPerLevelDto);
        Task<bool> DeleteEchoesPerLevelAsync(int id);
    }
}
