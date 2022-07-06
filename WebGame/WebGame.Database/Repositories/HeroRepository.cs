using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        public async Task DeleteHeroAsync(Guid heroId)
        {
            Hero hero = context.Heroes.Find(heroId);
            await Task.Run(() => context.Heroes.Remove(hero));
            SaveAsync();
        }
        public async Task AddHeroAsync(Hero hero)
        {
            await  context.Heroes.AddAsync(hero);
            SaveAsync();
        }
        public void UpdateHero(Hero hero)
        {
            context.Entry(hero).State = EntityState.Modified;
            SaveAsync();
        }

        public List<Hero> GetHeroes()
        {
            var result = context.Heroes.ToList();
            return result;
        }

        public Hero GetHeroByID(Guid heroId)
        {
            return context.Heroes.Find(heroId);
        }


        private void SaveAsync()
        {
            context.SaveChangesAsync();
        }
    }
}
