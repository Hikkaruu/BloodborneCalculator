using api.Interfaces;
using api.Models.DTOs.Boss;
using api.Models.Entities;
using api.Models.Filters;
using api.Persistence.Data;
using AutoMapper;
using CoreEx;
using Microsoft.EntityFrameworkCore;
using api.Models.Filters.Helpers;

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

        public async Task<IEnumerable<BossDto>> GetBossesByFilterAsync(BossFilter filter)
        {
            if (filter == null || !filter.HasFilters)
                return Enumerable.Empty<BossDto>();

            var query = _context.Bosses.AsQueryable();

            if (!string.IsNullOrEmpty(filter.BossName))
                query = query.Where(b => b.Name.Contains(filter.BossName));

            query = query.ApplyRangeFilter(filter.Health, filter.HealthMin, filter.HealthMax, b => b.Health);
            query = query.ApplyRangeFilter(filter.BloodEchoes, filter.BloodEchoesMin, filter.BloodEchoesMax, b => b.BloodEchoes);

            if (filter.IsInterruptible.HasValue)
                query = query.Where(b => b.IsInterruptible == filter.IsInterruptible);

            if (filter.IsRequired.HasValue)
                query = query.Where(b => b.IsRequired == filter.IsRequired);

            if (filter.IsKin.HasValue)
                query = query.Where(b => b.IsKin == filter.IsKin);

            if (filter.IsWeakToSerrated.HasValue)
                query = query.Where(b => b.IsWeakToSerrated == filter.IsWeakToSerrated);

            if (filter.IsWeakToRighteous.HasValue)
                query = query.Where(b => b.IsWeakToRighteous == filter.IsWeakToRighteous);

            query = query.ApplyRangeFilter(filter.PhysicalDefense, filter.PhysicalDefenseMin, filter.PhysicalDefenseMax, b => b.PhysicalDefense);
            query = query.ApplyRangeFilter(filter.BluntDefense, filter.BluntDefenseMin, filter.BluntDefenseMax, b => b.BluntDefense);
            query = query.ApplyRangeFilter(filter.ThrustDefense, filter.ThrustDefenseMin, filter.ThrustDefenseMax, b => b.ThrustDefense);
            query = query.ApplyRangeFilter(filter.BloodtingeDefense, filter.BloodtingeDefenseMin, filter.BloodtingeDefenseMax, b => b.BloodtingeDefense);
            query = query.ApplyRangeFilter(filter.ArcaneDefense, filter.ArcaneDefenseMin, filter.ArcaneDefenseMax, b => b.ArcaneDefense);
            query = query.ApplyRangeFilter(filter.FireDefense, filter.FireDefenseMin, filter.FireDefenseMax, b => b.FireDefense);
            query = query.ApplyRangeFilter(filter.BoltDefense, filter.BoltDefenseMin, filter.BoltDefenseMax, b => b.BoltDefense);
            query = query.ApplyRangeFilter(filter.SlowPoisonResistance, filter.SlowPoisonResistanceMin, filter.SlowPoisonResistanceMax, b => b.SlowPoisonResistance);
            query = query.ApplyRangeFilter(filter.RapidPoisonResistance, filter.RapidPoisonResistanceMin, filter.RapidPoisonResistanceMax, b => b.RapidPoisonResistance);

            var bosses = await query.ToListAsync();
            return _mapper.Map<IEnumerable<BossDto>>(bosses);
        }
    }
}
