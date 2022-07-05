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
        public List<Hero> GetHeroes();
        public Hero GetHeroByID(Guid heroId);
        void InsertHero(Hero hero);
        void DeleteHero(Guid heroId);
        void UpdateHero(Hero hero);
    }
}
