using System;
using System.Collections.Generic;
using WebGame.Core.Services.Interfaces;
using WebGame.Database.Model;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Core.Services
{
    public class HeroService : IHeroService
    {
        private readonly IHeroRepository _heroRepo;

        public HeroService(IHeroRepository HeroRepo)
        {
            _heroRepo = HeroRepo;
        }

        public List<Hero> GetHeroes() => _heroRepo.GetHeroes();
        public Hero GetHeroByID(Guid id) => _heroRepo.GetHeroByID(id);
        public void InsertHero(Hero hero) => _heroRepo.AddHeroAsync(hero);
        public void DeleteHero(Guid heroId) => _heroRepo.DeleteHeroAsync(heroId);
        public void UpdateHero(Hero hero) => _heroRepo.UpdateHero(hero);

    }
}
