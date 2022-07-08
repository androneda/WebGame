using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebGame.Core.Services.Interfaces;
using WebGame.Database;
using WebGame.Database.Model;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Core.Services
{
    public class HeroService : IHeroService
    {
        private readonly IHeroRepository _heroRepo;

        private readonly WebGameDBContext _context;
        public HeroService(IHeroRepository heroRepo, WebGameDBContext context)
        {
            _heroRepo = heroRepo;
            _context = context;
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

            if (_context.Heroes.Find(heroId) != null)
            {
                await _heroRepo.DeleteAsync(heroId);
            }
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
            if (_context.Heroes.Find(heroId) != null)
            {
               return await _heroRepo.GetByID(heroId);
            }
            return new Hero();
        }

    }
}
