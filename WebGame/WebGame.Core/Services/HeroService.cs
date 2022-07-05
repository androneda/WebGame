using System;
using System.Collections.Generic;
using WebGame.Core.Services.Interfaces;
using WebGame.Database.Model;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Core.Services
{
    public class HeroService : IHeroService
    {
        private readonly IHeroRepository _HeroRepo;

        public HeroService(IHeroRepository HeroRepo)
        {
            _HeroRepo = HeroRepo;
        }

        public List<Hero> GetHeroes() => _HeroRepo.GetHero();
        public Hero GetHeroByID(Guid id) => _HeroRepo.GetHeroByID(id);
        public void InsertHero(Hero hero)
        {
            _HeroRepo.InsertHero(hero);
            _HeroRepo.Save();
        }
        public void DeleteHero(Guid heroId)
        {
            _HeroRepo.DeleteHero(heroId);
            _HeroRepo.Save();
        }
        public void UpdateHero(Hero hero)
        {
            _HeroRepo.UpdateHero(hero);
            _HeroRepo.Save();
        }

    }
}
