using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebGame.Core.Services.Interfaces;
using WebGame.Database.Model;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Core.Services
{
    public class HeroService : IHeroService
    {
        private readonly IHeroRepository _heroRepo;

        public HeroService(IHeroRepository heroRepo)
        {
            _heroRepo = heroRepo;
        }

        public Task<IEnumerable<Hero>> GetHeroes() => _heroRepo.GetAll();
        public Hero GetHeroByID(Guid id) => _heroRepo.GetByID(id);
        public Task InsertHero(Hero hero) => _heroRepo.InsertAsync(hero);
        public Task DeleteHero(Guid heroId) => _heroRepo.DeleteAsync(heroId);
        public Task UpdateHero(Hero hero) => _heroRepo.UpdateAsync(hero);

    }
}
