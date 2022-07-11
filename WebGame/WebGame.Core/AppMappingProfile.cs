using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WebGame.Core.Model.Hero;
using WebGame.Database.Model;

namespace WebGame.Core
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<CreateHeroDto, Hero>();
            CreateMap<HeroViewDto, Hero>();
            CreateMap<ShortHeroViewDto, Hero>();
            CreateMap<UpdateHeroDto, Hero>();
        }
    }
}
