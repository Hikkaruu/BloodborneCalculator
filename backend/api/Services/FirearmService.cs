using api.Interfaces;
using api.Models.DTOs.Attack;
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

        public async Task<IEnumerable<FirearmDto>> GetAttacksByFilterAsync(FirearmFilter filter)
        {
            var query = _context.Firearms.AsQueryable();

            if (filter.HasFilters)
            {
                if (!string.IsNullOrWhiteSpace(filter.FirearmName))
                    query = query.Where(f => f.Name.Contains(filter.FirearmName));

                if (filter.PhysicalAttack.HasValue)
                    query = query.Where(f => f.PhysicalAttack == filter.PhysicalAttack.Value);

                if (filter.BloodAttack.HasValue)
                    query = query.Where(f => f.BloodAttack == filter.BloodAttack.Value);

                if (filter.ArcaneAttack.HasValue)
                    query = query.Where(f => f.ArcaneAttack == filter.ArcaneAttack.Value);

                if (filter.FireAttack.HasValue)
                    query = query.Where(f => f.FireAttack == filter.FireAttack.Value);

                if (filter.BoltAttack.HasValue)
                    query = query.Where(f => f.BoltAttack == filter.BoltAttack.Value);

                if (filter.BulletUse.HasValue)
                    query = query.Where(f => f.BulletUse == filter.BulletUse.Value);

                if (filter.Imprints.HasValue)
                    query = query.Where(f => f.Imprints == filter.Imprints.Value);

                if (filter.StrengthRequirement.HasValue)
                    query = query.Where(f => f.StrengthRequirement == filter.StrengthRequirement.Value);

                if (filter.SkillRequirement.HasValue)
                    query = query.Where(f => f.SkillRequirement == filter.SkillRequirement.Value);

                if (filter.BloodtingeRequirement.HasValue)
                    query = query.Where(f => f.BloodtingeRequirement == filter.BloodtingeRequirement.Value);

                if (filter.ArcaneRequirement.HasValue)
                    query = query.Where(f => f.ArcaneRequirement == filter.ArcaneRequirement.Value);
            }

            var firearms = await query.ToListAsync();
            return _mapper.Map<IEnumerable<FirearmDto>>(firearms);
        }
    }
}
