using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebGame.Database.Model;

namespace WebGame.Database.Repositories.Interfaces
{
    public interface IHeroRepository
    {
            List<Hero> GetHeroes();
            Hero GetHeroByID(Guid heroId);
            Task AddHeroAsync(Hero hero);
            Task DeleteHeroAsync(Guid heroId);
            void UpdateHero(Hero hero);
    }
}
