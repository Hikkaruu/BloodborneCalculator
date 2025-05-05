using api.Helpers;
using api.Interfaces;
using api.Models.DTOs.Origin;
using api.Models.Entities;
using api.Persistence.Data;
using AutoMapper;
using CoreEx;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class OriginService : IOriginService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly OriginCalculationHelper _originCalculationHelper = new();

        public OriginService(AppDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<OriginDto> GetOriginByIdAsync(int id)
        {
            var origin = await _context.Origins
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == id);

            if (origin == null)
                throw new NotFoundException($"Origin with ID: {id} not found");

            return _mapper.Map<OriginDto>(origin);
        }

        public async Task<IEnumerable<OriginDto>> GetAllOriginsAsync()
        {
            var origins = await _context.Origins
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<IEnumerable<OriginDto>>(origins);
        }

        public async Task<OriginDto> CreateOriginAsync(CreateOriginDto createDto)
        {
            var origin = _mapper.Map<Origin>(createDto);

            _context.Origins.Add(origin);
            await _context.SaveChangesAsync();

            return _mapper.Map<OriginDto>(origin);
        }

        public async Task<OriginDto> UpdateOriginAsync(int id, UpdateOriginDto originDto)
        {
            var origin = await _context.Origins.FirstOrDefaultAsync(o => o.Id == id);

            if (origin == null) return null!;

            _mapper.Map(originDto, origin);

            _context.Origins.Update(origin);
            await _context.SaveChangesAsync();

            return _mapper.Map<OriginDto>(origin);
        }

        public async Task<bool> DeleteOriginAsync(int id)
        {
            var origin = await _context.Origins.FirstOrDefaultAsync(o => o.Id == id);

            if (origin == null) return false;

            _context.Origins.Remove(origin);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<OptimalOriginDto>> GetOptimalOriginsByDesiredStats(int desiredVitality, 
            int desiredEndurance, int desiredStrength, int desiredSkill, int desiredBloodtinge, int desiredArcane)
        {
            var origins = await _context.Origins
                .AsNoTracking()
                .ToListAsync();

            if (origins == null || !origins.Any())
                throw new NotFoundException("No origins found");

            List<OptimalOriginDto> originsList= new();

            foreach (var origin in origins)
            {
                originsList.Add(new OptimalOriginDto
                {
                    Name = origin.Name,
                    Level = _originCalculationHelper.CalculateLevelForOrigin(origin, desiredVitality, desiredEndurance,
                        desiredStrength, desiredSkill, desiredBloodtinge, desiredArcane)
                });
            }

            return originsList
                .OrderBy(o => o.Level)
                .ToList();
        }
    }
}
