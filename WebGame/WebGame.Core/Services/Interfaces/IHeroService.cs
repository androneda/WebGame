using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Database.Model;

namespace WebGame.Core.Services.Interfaces
{
    public interface IHeroService
    {
        public Task<IEnumerable<Hero>> GetHeroes();
        public Hero GetHeroByID(Guid heroId);
        Task InsertHero(Hero hero);
        Task DeleteHero(Guid heroId);
        Task UpdateHero(Hero hero);
    }
}
