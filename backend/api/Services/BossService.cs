using api.Interfaces;
using api.Models.DTOs.Boss;
using api.Models.Entities;
using api.Persistence.Data;
using AutoMapper;
using CoreEx;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class BossService : IBossService
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BossService(AppDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
                                                            
        public async Task<BossDto> GetBossByIdAsync(int id)
        {
            var boss = await _context.Bosses
                .AsNoTracking()
                .FirstOrDefaultAsync(b =>b.Id == id); 
            
            if (boss == null)
                throw new NotFoundException($"Boss with ID: {id} not found");

            return _mapper.Map<BossDto>(boss);
        }

        public async Task<IEnumerable<BossDto>> GetAllBossesAsync()
        {
            var bosses = await _context.Bosses
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<IEnumerable<BossDto>>(bosses);
        }

        public async Task<BossDto> CreateBossAsync(CreateBossDto createDto)
        {
            var boss = _mapper.Map<Boss>(createDto);

            _context.Bosses.Add(boss);
            await _context.SaveChangesAsync();

            return _mapper.Map<BossDto>(boss);
        }

        public async Task<BossDto> UpdateBossAsync(int id, UpdateBossDto bossDto)
        {
            var boss = await _context.Bosses.FirstOrDefaultAsync(b => b.Id == id);

            if (boss == null) return null!;

            _mapper.Map(bossDto, boss);

            _context.Bosses.Update(boss);
            await _context.SaveChangesAsync();

            return _mapper.Map<BossDto>(boss);
        }

        public async Task<bool> DeleteBossAsync(int id)
        {
            var boss = await _context.Bosses.FirstOrDefaultAsync(b => b.Id == id);

            if (boss == null) return false;

            _context.Bosses.Remove(boss);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
