using api.Helpers;
using api.Interfaces;
using api.Models.DTOs.TricksterWeapon;
using api.Models.Entities;
using api.Models.Filters;
using api.Persistence.Data;
using AutoMapper;
using CoreEx;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class TricksterWeaponService : ITricksterWeaponService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TricksterWeaponService(AppDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<TricksterWeaponDto> GetTricksterWeaponByIdAsync(int id)
        {
            var tricksterWeapon = await _context.TricksterWeapons
                .Include(t => t.Scalings)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);

            if (tricksterWeapon == null)
                throw new NotFoundException($"Trickster Weapon with ID: {id} not found");

            return _mapper.Map<TricksterWeaponDto>(tricksterWeapon);
        }

        public async Task<IEnumerable<TricksterWeaponDto>> GetAllTricksterWeaponsAsync()
        {
            var tricksterWeapons = await _context.TricksterWeapons
                .Include(t => t.Scalings)
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<IEnumerable<TricksterWeaponDto>>(tricksterWeapons);
        }

        public async Task<TricksterWeaponDto> CreateTricksterWeaponAsync(CreateTricksterWeaponDto createDto)
        {
            var tricksterWeapon = _mapper.Map<TricksterWeapon>(createDto);

            await _context.TricksterWeapons.AddAsync(tricksterWeapon);
            await _context.SaveChangesAsync();

            return _mapper.Map<TricksterWeaponDto>(tricksterWeapon);
        }
        public async Task<TricksterWeaponDto> UpdateTricksterWeaponAsync(int id, UpdateTricksterWeaponDto updateDto)
        {
            var tricksterWeapon = await _context.TricksterWeapons.FindAsync(id);
            if (tricksterWeapon == null) return null!;

            _mapper.Map(updateDto, tricksterWeapon);
            await _context.SaveChangesAsync();

            return _mapper.Map<TricksterWeaponDto>(tricksterWeapon);
        }

        public async Task<bool> DeleteTricksterWeaponAsync(int id)
        {
            var tricksterWeapon = await _context.TricksterWeapons.FindAsync(id);
            if (tricksterWeapon == null) return false;

            _context.TricksterWeapons.Remove(tricksterWeapon);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TricksterWeaponDto>> GetTricksterWeaponsByFilterAsync(TricksterWeaponFilter filter)
        {
            if (filter == null || !filter.HasFilters)
                return Enumerable.Empty<TricksterWeaponDto>();

            var query = _context.TricksterWeapons.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.TricksterWeaponName))
                query = query.Where(t => t.Name.Contains(filter.TricksterWeaponName));

            query = query.ApplyRangeFilter(filter.PhysicalAttack, filter.PhysicalAttackMin, filter.PhysicalAttackMax, t => t.PhysicalAttack);
            query = query.ApplyRangeFilter(filter.BloodAttack, filter.BloodAttackMin, filter.BloodAttackMax, t => t.BloodAttack);
            query = query.ApplyRangeFilter(filter.ArcaneAttack, filter.ArcaneAttackMin, filter.ArcaneAttackMax, t => t.ArcaneAttack);
            query = query.ApplyRangeFilter(filter.FireAttack, filter.FireAttackMin, filter.FireAttackMax, t => t.FireAttack);
            query = query.ApplyRangeFilter(filter.BoltAttack, filter.BoltAttackMin, filter.BoltAttackMax, t => t.BoltAttack);
            query = query.ApplyRangeFilter(filter.BulletUse, filter.BulletUseMin, filter.BulletUseMax, t => t.BulletUse);
            query = query.ApplyRangeFilter(filter.RapidPoison, filter.RapidPoisonMin, filter.RapidPoisonMax, t => t.RapidPoison);

            if (filter.ImprintsNormal.HasValue)
                query = query.Where(t => t.ImprintsNormal == filter.ImprintsNormal);

            if (filter.ImprintsUncanny.HasValue)
                query = query.Where(t => t.ImprintsUncanny == filter.ImprintsUncanny);

            if (filter.ImprintsLost.HasValue)
                query = query.Where(t => t.ImprintsLost == filter.ImprintsLost);

            query = query.ApplyRangeFilter(filter.Rally, filter.RallyMin, filter.RallyMax, t => t.Rally);
            query = query.ApplyRangeFilter(filter.StrengthRequirement, filter.StrengthRequirementMin, filter.StrengthRequirementMax, t => t.StrengthRequirement);
            query = query.ApplyRangeFilter(filter.SkillRequirement, filter.SkillRequirementMin, filter.SkillRequirementMax, t => t.SkillRequirement);
            query = query.ApplyRangeFilter(filter.BloodtingeRequirement, filter.BloodtingeRequirementMin, filter.BloodtingeRequirementMax, t => t.BloodtingeRequirement);
            query = query.ApplyRangeFilter(filter.ArcaneRequirement, filter.ArcaneRequirementMin, filter.ArcaneRequirementMax, t => t.ArcaneRequirement);
            query = query.ApplyRangeFilter(filter.MaxUpgradeAttack, filter.MaxUpgradeAttackMin, filter.MaxUpgradeAttackMax, t => t.MaxUpgradeAttack);

            var tricksterWeapons = await query.ToListAsync();
            return _mapper.Map<IEnumerable<TricksterWeaponDto>>(tricksterWeapons);
        }
    }
}
