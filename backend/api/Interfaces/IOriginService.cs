using api.Models.DTOs.Origin;

namespace api.Interfaces
{
    public interface IOriginService
    {
        Task<OriginDto> GetOriginByIdAsync(int id);
        Task<IEnumerable<OriginDto>> GetAllOriginsAsync();
        Task<OriginDto> CreateOriginAsync(CreateOriginDto createDto);
        Task<OriginDto> UpdateOriginAsync(int id, UpdateOriginDto originDto);
        Task<bool> DeleteOriginAsync(int id);
        Task<List<OptimalOriginDto>> GetOptimalOriginsByDesiredStats(int desiredVitality,
            int desiredEndurance, int desiredStrength, int desiredSkill, int desiredBloodtinge, int desiredArcane);
    }
}
