using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WebGame.Core.Model.Hero;
using WebGame.Core.Model.Ammunition;
using WebGame.Database.Model;
using WebGame.Core.Model.Skills;
using WebGame.Core.Model.Specialization;
using WebGame.Core.Model.Races;
using WebGame.Core.Model.User;

namespace WebGame.Api.Data
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<CreateHeroDto, Hero>();
            CreateMap<UpdateHeroDto, Hero>();
            CreateMap<Hero, HeroViewDto>();

            CreateMap<CreateAmmunitionDto, Ammunition>();
            CreateMap<UpdateAmmunitionDto, Ammunition>();
            CreateMap<Ammunition, AmmunitionViewDto>();

            CreateMap<CreateSkillDto, Skill>();
            CreateMap<UpdateSkillDto, Skill>();
            CreateMap<Skill, SkillViewDto>();

            CreateMap<CreateSpecializationDto, Specialization>();
            CreateMap<UpdateSpecializationDto, Specialization>();
            CreateMap<Specialization, SpecializationViewDto>();

            CreateMap<CreateRaceDto, Race>();
            CreateMap<UpdateRaceDto, Race>();
            CreateMap<Race, RaceViewDto>();

            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();
            CreateMap<User, UserViewDto>();
        }
    }
}
