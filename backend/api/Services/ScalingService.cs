using api.Interfaces;
using api.Models.DTOs.Scaling;
using api.Models.Entities;
using api.Persistence.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class ScalingService : IScalingService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ScalingService(AppDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ScalingDto> GetScalingByIdAsync(int id)
        {
            var scaling = await _context.Scalings
                .Include(s => s.TricksterWeapons)
                .Include(s => s.Firearms)
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);

            if (scaling == null) return null!;

            return _mapper.Map<ScalingDto>(scaling);
        }

        public async Task<IEnumerable<ScalingDto>> GetAllScalingsAsync()
        {
            var scalings = await _context.Scalings
                .Include(s => s.TricksterWeapons)
                .Include(s => s.Firearms)
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<List<ScalingDto>>(scalings);
        }

        public async Task<ScalingDto> CreateScalingAsync(CreateScalingDto createDto)
        {
            var scaling = _mapper.Map<Scaling>(createDto);

            await _context.Scalings.AddAsync(scaling);
            await _context.SaveChangesAsync();

            return _mapper.Map<ScalingDto>(scaling);
        }

        public async Task<ScalingDto> UpdateScalingAsync(int id, UpdateScalingDto updateDto)
        {
            var scaling = await _context.Scalings.FindAsync(id);
            if (scaling == null) return null!;

            _mapper.Map(updateDto, scaling);
            await _context.SaveChangesAsync();

            return _mapper.Map<ScalingDto>(scaling);
        }

        public async Task<bool> DeleteScalingAsync(int id)
        {
            var scaling = await _context.Scalings.FindAsync(id);
            if (scaling == null) return false;

            _context.Scalings.Remove(scaling);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ScalingDto> GetScalingByWeaponNameAsync(string weaponName)
        {
            var scaling = await _context.Scalings
                .Include(s => s.TricksterWeapons)
                .Include(s => s.Firearms)
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.TricksterWeapons.Name == weaponName || s.Firearms.Name == weaponName);

            if (scaling == null) return null!;

            return _mapper.Map<ScalingDto>(scaling);
        }
    }
}
