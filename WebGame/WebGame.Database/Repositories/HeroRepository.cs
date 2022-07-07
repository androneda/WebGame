using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebGame.Database.Model;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Database.Repositories
{
    public class HeroRepository : IHeroRepository
    {
        private readonly WebGameDBContext context;

        public HeroRepository(WebGameDBContext context)
        {
            this.context = context;
        }
        public async Task DeleteAsync(Guid heroId)
        {
            Hero hero = context.Heroes.Find(heroId);
            context.Heroes.Remove(hero);
            await SaveAsync();
        }
        public async Task InsertAsync(Hero hero)
        {
            await context.Heroes.AddAsync(hero);
            await SaveAsync();
        }
        public async Task UpdateAsync(Hero hero)
        {
            context.Entry(hero).State = EntityState.Modified;
            await SaveAsync();
        }

        public async Task<IEnumerable<Hero>> GetAll()
        {
            return await context.Heroes.ToListAsync();
        }

        public Hero GetByID(Guid heroId)
        {
            return context.Heroes.Find(heroId);
        }


        private async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
