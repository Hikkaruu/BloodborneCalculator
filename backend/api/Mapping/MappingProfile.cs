﻿using AutoMapper;
using api.Models.Entities;
using api.Models.DTOs.Boss;
using api.Models.DTOs.Scaling;
using api.Models.DTOs.Attack;
using api.Models.DTOs.Firearm;
using api.Models.DTOs.TricksterWeapon;
using api.Models.DTOs.Origin;
using api.Models.DTOs.EchoesPerLevel;

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
                .ForMember(dest => dest.TricksterWeaponId, opt => opt.MapFrom(src => src.TricksterWeapons.Id))
                .ForMember(dest => dest.FirearmId, opt => opt.MapFrom(src => src.Firearms.Id));

            CreateMap<Scaling, ScalingForWeaponDto>();

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
                .ForMember(dest => dest.Scaling, opt => opt.MapFrom(src => src.Scalings));

            CreateMap<CreateFirearmDto, Firearm>();

            CreateMap<UpdateFirearmDto, Firearm>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // TricksterWeapon Mapping
            CreateMap<TricksterWeapon, TricksterWeaponDto>()
                .ForMember(dest => dest.Scaling, opt => opt.MapFrom(src => src.Scaling))
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

            // Origin Mapping
            CreateMap<Origin, OriginDto>()
                .ReverseMap();

            CreateMap<CreateOriginDto, Origin>();

            CreateMap<UpdateOriginDto, Origin>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Echoes per level Mapping
            CreateMap<EchoesPerLevel, EchoesPerLevelDto>()
                .ReverseMap();

            CreateMap<EchoesPerLevel, RequiredEchoesPerLevelDto>()
                .ReverseMap();

            CreateMap<CreateEchoesPerLevelDto, EchoesPerLevel>();

            CreateMap<UpdateEchoesPerLevelDto, EchoesPerLevel>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
