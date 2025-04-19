using api.Interfaces;
using api.Models.DTOs.Attack;
using api.Models.DTOs.Scaling;
using api.Models.Entities;
using api.Models.Enums;
using api.Models.Filters;
using api.Persistence.Data;
using AutoMapper;
using CoreEx;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class AttackService : IAttackService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public AttackService(AppDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<AttackDto> GetAttackByIdAsync(int id)
        {
            var attack = await _context.Attacks
                .Include(a => a.TricksterWeapons)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);

            if (attack == null)
                throw new NotFoundException($"Attack with ID: {id} not found");

            return _mapper.Map<AttackDto>(attack);
        }

        public async Task<IEnumerable<AttackDto>> GetAllAttacksAsync()
        {
            var attacks = await _context.Attacks
                .Include(a => a.TricksterWeapons)
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<IEnumerable<AttackDto>>(attacks);
        }

        public async Task<AttackDto> CreateAttackAsync(CreateAttackDto createDto)
        {
            var attack = _mapper.Map<Attack>(createDto);

            await _context.Attacks.AddAsync(attack);
            await _context.SaveChangesAsync();

            return _mapper.Map<AttackDto>(attack);
        }

        public async Task<AttackDto> UpdateAttackAsync(int id, UpdateAttackDto updateDto)
        {
            var attack = await _context.Attacks.FindAsync(id);
            if (attack == null) return null!;

            _mapper.Map(updateDto, attack);
            await _context.SaveChangesAsync();

            return _mapper.Map<AttackDto>(attack);
        }

        public async Task<bool> DeleteAttackAsync(int id)
        {
            var attack = await _context.Attacks.FindAsync(id);
            if (attack == null) return false;

            _context.Attacks.Remove(attack);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<AttackDto>> GetAttacksByFilterAsync(AttackFilter filter)
        {
            var query = _context.Attacks.AsQueryable();

            if (filter.HasFilters)
            {
                if (!string.IsNullOrWhiteSpace(filter.WeaponName))
                    query = query.Where(a => a.TricksterWeapons.Name.Contains(filter.WeaponName));

                if (filter.Damage.HasValue)
                    query = query.Where(a => a.Damage == filter.Damage.Value);

                if (filter.ExtraDamage.HasValue)
                    query = query.Where(a => a.ExtraDamage == filter.ExtraDamage.Value);

                if (filter.ExtraDamageCount.HasValue)
                    query = query.Where(a => a.ExtraDamageCount == filter.ExtraDamageCount.Value);

                if (filter.AttackType1.HasValue)
                    query = query.Where(a => a.AttackType1 == filter.AttackType1.Value);

                if (filter.AttackType2.HasValue)
                    query = query.Where(a => a.AttackType2 == filter.AttackType2.Value);

                if (filter.AttackMode.HasValue)
                    query = query.Where(a => a.AttackMode == filter.AttackMode.Value);

                if (filter.WeaponId.HasValue)
                    query = query.Where(a => a.TricksterWeaponId == filter.WeaponId.Value);
            }

            var attacks = await query.ToListAsync();
            return _mapper.Map<IEnumerable<AttackDto>>(attacks);
        }
    }
}
