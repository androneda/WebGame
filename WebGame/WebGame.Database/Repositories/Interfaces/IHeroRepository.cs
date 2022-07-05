using System;
using System.Collections.Generic;
using WebGame.Database.Model;

namespace WebGame.Database.Repositories.Interfaces
{
    public interface IHeroRepository: IDisposable
    {
            List<Hero> GetHero();
            Hero GetHeroByID(Guid heroId);
            void InsertHero(Hero hero);
            void DeleteHero(Guid heroId);
            void UpdateHero(Hero hero);
            void Save();
    }
}
