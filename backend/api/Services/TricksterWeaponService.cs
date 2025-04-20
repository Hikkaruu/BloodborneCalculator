using api.Interfaces;
using api.Models.DTOs.Firearm;
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
            var query = _context.TricksterWeapons.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.TricksterWeaponName))
                query = query.Where(t => t.Name.Contains(filter.TricksterWeaponName));

            if (filter.PhysicalAttack.HasValue)
                query = query.Where(t => t.PhysicalAttack == filter.PhysicalAttack);

            if (filter.BloodAttack.HasValue)
                query = query.Where(t => t.BloodAttack == filter.BloodAttack);

            if (filter.ArcaneAttack.HasValue)
                query = query.Where(t => t.ArcaneAttack == filter.ArcaneAttack);

            if (filter.FireAttack.HasValue)
                query = query.Where(t => t.FireAttack == filter.FireAttack);

            if (filter.BoltAttack.HasValue)
                query = query.Where(t => t.BoltAttack == filter.BoltAttack);

            if (filter.BulletUse.HasValue)
                query = query.Where(t => t.BulletUse == filter.BulletUse);

            if (filter.RapidPoison.HasValue)
                query = query.Where(t => t.RapidPoison == filter.RapidPoison);

            if (filter.ImprintsNormal.HasValue)
                query = query.Where(t => t.ImprintsNormal == filter.ImprintsNormal);

            if (filter.ImprintsUncanny.HasValue)
                query = query.Where(t => t.ImprintsUncanny == filter.ImprintsUncanny);

            if (filter.ImprintsLost.HasValue)
                query = query.Where(t => t.ImprintsLost == filter.ImprintsLost);

            if (filter.Rally.HasValue)
                query = query.Where(t => t.Rally == filter.Rally);

            if (filter.StrengthRequirement.HasValue)
                query = query.Where(t => t.StrengthRequirement == filter.StrengthRequirement);

            if (filter.SkillRequirement.HasValue)
                query = query.Where(t => t.SkillRequirement == filter.SkillRequirement);

            if (filter.BloodtingeRequirement.HasValue)
                query = query.Where(t => t.BloodtingeRequirement == filter.BloodtingeRequirement);

            if (filter.ArcaneRequirement.HasValue)
                query = query.Where(t => t.ArcaneRequirement == filter.ArcaneRequirement);

            if (filter.MaxUpgradeAttack.HasValue)
                query = query.Where(t => t.MaxUpgradeAttack == filter.MaxUpgradeAttack);

            var tricksterWeapons = await query.ToListAsync();
            return _mapper.Map<IEnumerable<TricksterWeaponDto>>(tricksterWeapons);
        }
    }
}
