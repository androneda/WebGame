using AutoMapper;
using WebGame.Core.Model.Ammunition;
using WebGame.Core.Model.Hero;
using WebGame.Core.Model.Races;
using WebGame.Core.Model.Role;
using WebGame.Core.Model.Session;
using WebGame.Core.Model.Skills;
using WebGame.Core.Model.Specialization;
using WebGame.Core.Model.User;
using WebGame.Database.Model;

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

            CreateMap<Session, SessionViewDto>();

            CreateMap<Role, RoleViewDto>().ReverseMap();
        }
    }
}
