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
    }
}
