using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebGame.Core.Services.Interfaces;
using WebGame.Core.Model.;
using WebGame.Database;
using WebGame.Database.Model;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Core.Services
{
    public class HeroService : IHeroService
    {
        private readonly IHeroRepository _heroRepo;
        public HeroService(IHeroRepository heroRepo, WebGameDBContext context)
        {
            _heroRepo = heroRepo;
        }
        public async Task<ICollection<Hero>> GetAll() => await _heroRepo.GetAll();
        public async Task Insert(Hero hero)
        {
            if (hero != null)
            {
                await _heroRepo.InsertAsync(hero);
            }
        }

        public async Task Delete(Guid heroId)
        {
            await _heroRepo.DeleteAsync(heroId);
        }

        public async Task UpdateHero(Hero hero)
        {
            if (hero != null)
            {
                await _heroRepo.UpdateAsync(hero);
            }
        }
        public async Task<Hero> GetByID(Guid heroId)
        {
            return await _heroRepo.GetByID(heroId);
        }
    }
}
