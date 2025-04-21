using api.Interfaces;
using api.Models.DTOs.Boss;
using api.Models.Entities;
using api.Models.Filters;
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

        public async Task<IEnumerable<BossDto>> GetBossesByFilterAsync(BossFilter filter)
        {
            var query = _context.Bosses.AsQueryable();

            if (filter.BossName != null)
                query = query.Where(b => b.Name.Contains(filter.BossName));
   
            if (filter.Health != null)
                query = query.Where(b => b.Health == filter.Health);

            if (filter.BloodEchoes != null)
                query = query.Where(b => b.BloodEchoes == filter.BloodEchoes);

            if (filter.IsInterruptible != null)
                query = query.Where(b => b.IsInterruptible == filter.IsInterruptible);

            if (filter.IsRequired != null)
                query = query.Where(b => b.IsRequired == filter.IsRequired);

            if (filter.IsKin != null)
                query = query.Where(b => b.IsKin == filter.IsKin);

            if (filter.IsWeakToSerrated != null)
                query = query.Where(b => b.IsWeakToSerrated == filter.IsWeakToSerrated);

            if (filter.IsWeakToRighteous != null)
                query = query.Where(b => b.IsWeakToRighteous == filter.IsWeakToRighteous);

            if (filter.PhysicalDefense != null)
                query = query.Where(b => b.PhysicalDefense == filter.PhysicalDefense);

            if (filter.BluntDefense != null)
                query = query.Where(b => b.BluntDefense == filter.BluntDefense);

            if (filter.ThrustDefense != null)
                query = query.Where(b => b.ThrustDefense == filter.ThrustDefense);

            if (filter.BloodtingeDefense != null)
                query = query.Where(b => b.BloodtingeDefense == filter.BloodtingeDefense);

            if (filter.ArcaneDefense != null)
                query = query.Where(b => b.ArcaneDefense == filter.ArcaneDefense);

            if (filter.FireDefense != null)
                query = query.Where(b => b.FireDefense == filter.FireDefense);

            if (filter.BoltDefense != null)
                query = query.Where(b => b.BoltDefense == filter.BoltDefense);

            if (filter.SlowPoisonResistance != null)
                query = query.Where(b => b.SlowPoisonResistance == filter.SlowPoisonResistance);

            if (filter.RapidPoisonResistance != null)
                query = query.Where(b => b.RapidPoisonResistance == filter.RapidPoisonResistance);

            var bosses = await query.ToListAsync();
            return _mapper.Map<IEnumerable<BossDto>>(bosses);
        }
    }
}
