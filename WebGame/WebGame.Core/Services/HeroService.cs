using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebGame.Core.Services.Interfaces;
using WebGame.Database.Model;
using WebGame.Database.Repositories;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Core.Services
{
    public class HeroService : BaseService<Hero>, IHeroService
    {
        public HeroService(IHeroRepository heroRepo) : base (heroRepo)
        {
        }

    }
}
