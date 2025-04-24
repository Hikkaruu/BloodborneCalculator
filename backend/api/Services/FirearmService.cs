using api.Helpers;
using api.Interfaces;
using api.Models.DTOs.Firearm;
using api.Models.Entities;
using api.Models.Filters;
using api.Persistence.Data;
using AutoMapper;
using CoreEx;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class FirearmService : IFirearmService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private WeaponCalculationHelper _weaponCalculationHelper = new();

        public FirearmService(AppDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<FirearmDto> GetFirearmByIdAsync(int id)
        {
            var firearm = await _context.Firearms
                .Include(f => f.Scalings)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);

            if (firearm == null)
                throw new NotFoundException($"Firearm with ID: {id} not found");

            return _mapper.Map<FirearmDto>(firearm);
        }

        public async Task<IEnumerable<FirearmDto>> GetAllFirearmsAsync()
        {
            var firearms = await _context.Firearms
                .Include(a => a.Scalings)
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<IEnumerable<FirearmDto>>(firearms);
        }

        public async Task<FirearmDto> CreateFirearmAsync(CreateFirearmDto createDto)
        {
            var firearm = _mapper.Map<Firearm>(createDto);

            await _context.Firearms.AddAsync(firearm);
            await _context.SaveChangesAsync();

            return _mapper.Map<FirearmDto>(firearm);
        }

        public async Task<FirearmDto> UpdateFirearmAsync(int id, UpdateFirearmDto updateDto)
        {
            var firearm = await _context.Firearms.FindAsync(id);
            if (firearm == null) return null!;

            _mapper.Map(updateDto, firearm);
            await _context.SaveChangesAsync();

            return _mapper.Map<FirearmDto>(firearm);
        }

        public async Task<bool> DeleteFirearmAsync(int id)
        {
            var firearm = await _context.Firearms.FindAsync(id);
            if (firearm == null) return false;

            _context.Firearms.Remove(firearm);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<FirearmDto>> GetFirearmsByFilterAsync(FirearmFilter filter)
        {
            if (filter == null || !filter.HasFilters)
                return Enumerable.Empty<FirearmDto>();

            var query = _context.Firearms.AsQueryable();

            if (filter.HasFilters)
            {
                if (!string.IsNullOrWhiteSpace(filter.FirearmName))
                    query = query.Where(f => f.Name.Contains(filter.FirearmName));

                query = query.ApplyRangeFilter(filter.PhysicalAttack, filter.PhysicalAttackMin, filter.PhysicalAttackMax, f => f.PhysicalAttack);
                query = query.ApplyRangeFilter(filter.BloodAttack, filter.BloodAttackMin, filter.BloodAttackMax, f => f.BloodAttack);
                query = query.ApplyRangeFilter(filter.ArcaneAttack, filter.ArcaneAttackMin, filter.ArcaneAttackMax, f => f.ArcaneAttack);
                query = query.ApplyRangeFilter(filter.FireAttack, filter.FireAttackMin, filter.FireAttackMax, f => f.FireAttack);
                query = query.ApplyRangeFilter(filter.BoltAttack, filter.BoltAttackMin, filter.BoltAttackMax, f => f.BoltAttack);
                query = query.ApplyRangeFilter(filter.BulletUse, filter.BulletUseMin, filter.BulletUseMax, f => f.BulletUse);

                if (filter.Imprints.HasValue)
                    query = query.Where(f => f.Imprints == filter.Imprints.Value);

                query =query.ApplyRangeFilter(filter.StrengthRequirement, filter.StrengthRequirementMin, filter.StrengthRequirementMax, f => f.StrengthRequirement);
                query = query.ApplyRangeFilter(filter.SkillRequirement, filter.SkillRequirementMin, filter.SkillRequirementMax, f => f.SkillRequirement);
                query = query.ApplyRangeFilter(filter.BloodtingeRequirement, filter.BloodtingeRequirementMin, filter.BloodtingeRequirementMax, f => f.BloodtingeRequirement);
                query = query.ApplyRangeFilter(filter.ArcaneRequirement, filter.ArcaneRequirementMin, filter.ArcaneRequirementMax, f => f.ArcaneRequirement);
            }

            var firearms = await query.ToListAsync();
            return _mapper.Map<IEnumerable<FirearmDto>>(firearms);
        }

        public async Task<bool> CanWieldFirearm(int id, int strength, int skill, int bloodtinge, int arcane)
        {
            var firearm = await GetFirearmByIdAsync(id);

            if (firearm == null)
                throw new NotFoundException($"Firearm with ID: {id} not found");
            
            return (strength >= firearm.StrengthRequirement && skill >= firearm.SkillRequirement &&
                bloodtinge >= firearm.BloodtingeRequirement && arcane >= firearm.ArcaneRequirement);
        }

        public async Task<int> GetFirearmAttackRating(int id, int strength, int skill, int bloodtinge, int arcane, int weaponUpgradeLevel)
        {
            var firearm = await GetFirearmByIdAsync(id);

            if (!CanWieldFirearm(id, strength, skill, bloodtinge, arcane).Result)
                throw new NotFoundException($"Firearm with ID: {id} cannot be wielded by the character");

            if (firearm.Scaling == null)
                throw new NotFoundException($"Scaling related to this firearm not found");

            var scaling = firearm.Scaling;

            int physicalAttackRating = 0;
            int bloodAttackRating = 0;
            int arcaneAttackRating = 0;
            int fireAttackRating = 0;
            int boltAttackRating = 0;

            if (firearm.PhysicalAttack > 0)
            {
                double strengthScaling = _weaponCalculationHelper.getScaling(scaling.StrengthScaling, scaling.StrengthStep, weaponUpgradeLevel);
                double skillScaling = _weaponCalculationHelper.getScaling(scaling.SkillScaling, scaling.SkillStep, weaponUpgradeLevel);
                double firearmAttack = firearm.PhysicalAttack + (firearm.PhysicalAttack / 10) * weaponUpgradeLevel;

                physicalAttackRating = (int)(
                    firearmAttack
                    + (firearmAttack * _weaponCalculationHelper.getSaturation(strength) * strengthScaling)
                    + (firearmAttack * _weaponCalculationHelper.getSaturation(skill) * skillScaling));
            }

            if (firearm.BloodAttack > 0)
            {
                double bloodtingeScaling = _weaponCalculationHelper.getScaling(scaling.BloodtingeScaling, scaling.BloodtingeStep, weaponUpgradeLevel);
                double firearmAttack = firearm.BloodAttack + (firearm.BloodAttack / 10) * weaponUpgradeLevel;

                bloodAttackRating = (int)(
                    firearmAttack
                    + (firearmAttack * _weaponCalculationHelper.getSaturation(bloodtinge) * bloodtingeScaling));
            }

            if (firearm.ArcaneAttack > 0)
            {
                double arcaneScaling = _weaponCalculationHelper.getScaling(scaling.ArcaneScaling, scaling.ArcaneStep, weaponUpgradeLevel);
                double firearmAttack = firearm.ArcaneAttack + (firearm.ArcaneAttack / 10) * weaponUpgradeLevel;

                arcaneAttackRating = (int)(
                    firearmAttack
                    + (firearmAttack * _weaponCalculationHelper.getSaturation(arcane) * arcaneScaling));
            }

            if (firearm.FireAttack > 0)
            {
                double arcaneScaling = _weaponCalculationHelper.getScaling(scaling.ArcaneScaling, scaling.ArcaneStep, weaponUpgradeLevel);
                double firearmAttack = firearm.FireAttack + (firearm.FireAttack / 10) * weaponUpgradeLevel;

                fireAttackRating = (int)(
                    firearmAttack
                    + (firearmAttack * _weaponCalculationHelper.getSaturation(arcane) * arcaneScaling));
            }
               
            if (firearm.BoltAttack > 0)
            {
                double arcaneScaling = _weaponCalculationHelper.getScaling(scaling.ArcaneScaling, scaling.ArcaneStep, weaponUpgradeLevel);
                double firearmAttack = firearm.BoltAttack + (firearm.BoltAttack / 10) * weaponUpgradeLevel;

                boltAttackRating = (int)(
                    firearmAttack
                    + (firearmAttack * _weaponCalculationHelper.getSaturation(arcane) * arcaneScaling));
            }
            
            int attackRating = physicalAttackRating + bloodAttackRating + arcaneAttackRating + fireAttackRating + boltAttackRating;
            return attackRating;
        }
    }
}
