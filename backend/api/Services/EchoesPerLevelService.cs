using api.Interfaces;
using api.Models.DTOs.EchoesPerLevel;
using api.Models.Entities;
using api.Persistence.Data;
using AutoMapper;
using CoreEx;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class EchoesPerLevelService : IEchoesPerLevelService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EchoesPerLevelService(AppDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<EchoesPerLevelDto> GetEchoesPerLevelByIdAsync(int id)
        {
            var echoesPerLevel = await _context.EchoesPerLevels
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);

            if (echoesPerLevel == null)
                throw new NotFoundException($"EchoesPerLevel with ID: {id} not found");

            return _mapper.Map<EchoesPerLevelDto>(echoesPerLevel);
        }

        public async Task<RequiredEchoesPerLevelDto> GetEchoesPerLevelByLevelAsync(int level)
        {
            var echoesPerLevel = await _context.EchoesPerLevels
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Level == level);

            if (echoesPerLevel == null)
                throw new NotFoundException($"EchoesPerLevel with Level: {level} not found");

            return _mapper.Map<RequiredEchoesPerLevelDto>(echoesPerLevel);
        }

        public async Task<IEnumerable<EchoesPerLevelDto>> GetAllEchoesPerLevelsAsync()
        {
            var echoesPerLevels = await _context.EchoesPerLevels
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<IEnumerable<EchoesPerLevelDto>>(echoesPerLevels);
        }

        public async Task<EchoesPerLevelDto> CreateEchoesPerLevelAsync(CreateEchoesPerLevelDto createDto)
        {
            var echoesPerLevel = _mapper.Map<EchoesPerLevel>(createDto);

            _context.EchoesPerLevels.Add(echoesPerLevel);
            await _context.SaveChangesAsync();

            return _mapper.Map<EchoesPerLevelDto>(echoesPerLevel);
        }

        public async Task<EchoesPerLevelDto> UpdateEchoesPerLevelAsync(int id, UpdateEchoesPerLevelDto echoesPerLevelDto)
        {
            var echoesPerLevel = await _context.EchoesPerLevels.FirstOrDefaultAsync(e => e.Id == id);

            if (echoesPerLevel == null) return null!;

            _mapper.Map(echoesPerLevelDto, echoesPerLevel);
            await _context.SaveChangesAsync();

            return _mapper.Map<EchoesPerLevelDto>(echoesPerLevel);
        }

        public async Task<bool> DeleteEchoesPerLevelAsync(int id)
        {
            var echoesPerLevel = await _context.EchoesPerLevels.FirstOrDefaultAsync(e => e.Id == id);

            if (echoesPerLevel == null) return false;

            _context.EchoesPerLevels.Remove(echoesPerLevel);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
