using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WebGame.Core.Model.Hero;
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
        }
    }
}
