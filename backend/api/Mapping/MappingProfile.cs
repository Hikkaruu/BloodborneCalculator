using AutoMapper;
using api.Models.Entities;
using api.Models.DTOs.Boss;
using api.Models.DTOs.Scaling;
using api.Models.DTOs.Attack;
using api.Models.DTOs.Firearm;
using api.Models.DTOs.TricksterWeapon;

namespace api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Boss Mapping
            CreateMap<Boss, BossDto> ()
                .ReverseMap();

            CreateMap<CreateBossDto, Boss>();

            CreateMap<UpdateBossDto, Boss>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Scaling Mapping
            CreateMap<Scaling, ScalingDto>()
                .ForMember(dest => dest.TricksterWeaponId, opt =>
                    opt.MapFrom(src => src.TricksterWeapons != null ? src.TricksterWeapons.Id : (int?)null))
                .ForMember(dest => dest.TricksterWeaponName, opt =>
                    opt.MapFrom(src => src.TricksterWeapons != null ? src.TricksterWeapons.Name : null))
                .ForMember(dest => dest.FirearmId,
                    opt => opt.MapFrom(src => src.Firearms != null ? src.Firearms.Id : (int?)null))
                .ForMember(dest => dest.FirearmName,
                    opt => opt.MapFrom(src => src.Firearms != null ? src.Firearms.Name : null));
            
            CreateMap<CreateScalingDto, Scaling>();
            
            CreateMap<UpdateScalingDto, Scaling>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Attack Mapping
            CreateMap<Attack, AttackDto>()
                .ForMember(dest => dest.TricksterWeaponName, opt => opt.MapFrom(src => src.TricksterWeapons.Name));

            CreateMap<CreateAttackDto, Attack>();
            
            CreateMap<UpdateAttackDto, Attack>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Firearm Mapping
            CreateMap<Firearm, FirearmDto>()
                .ForMember(dest => dest.ScalingName, opt => opt.MapFrom(src => src.Scalings.Name));

            CreateMap<CreateFirearmDto, Firearm>();

            CreateMap<UpdateFirearmDto, Firearm>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // TricksterWeapon Mapping
            CreateMap<TricksterWeapon, TricksterWeaponDto>()
                .ForMember(dest => dest.ScalingName, opt => opt.MapFrom(src => src.Scalings.Name))
                .ForMember(dest => dest.Attacks, opt => opt.MapFrom(src => src.Attacks.Select(a => 
                    new AttackForTricksterWeaponDto
                    {
                        Name = a.Name,
                        Damage = a.Damage,
                        ExtraDamage = a.ExtraDamage,
                        ExtraDamageCount = a.ExtraDamageCount,
                        AttackType1 = a.AttackType1,
                        AttackType2 = a.AttackType2,
                        AttackMode = a.AttackMode
                    })));

            CreateMap<CreateTricksterWeaponDto, TricksterWeapon>();

            CreateMap<UpdateTricksterWeaponDto, TricksterWeapon>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
