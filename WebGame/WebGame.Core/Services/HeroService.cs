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

        public async Task<ICollection<Hero>> GetAll() => await _heroRepo.GetAll();
        public async Task Insert(Hero hero) => await _heroRepo.InsertAsync(hero);
        public async Task Delete(Guid heroId) => await _heroRepo.DeleteAsync(heroId);
        public async Task UpdateHero(Hero hero) => await _heroRepo.UpdateAsync(hero);
        public  Hero GetByID(Guid id) =>  _heroRepo.GetByID(id);

    }
}
