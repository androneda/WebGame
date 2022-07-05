using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebGame.Database.Model;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Database.Repositories
{
    public class HeroRepository : IHeroRepository, IDisposable
    {
        private readonly WebGameDBContext context;

        public HeroRepository(WebGameDBContext context)
        {
            this.context = context;
        }
        public void DeleteHero(Guid heroId)
        {
            Hero hero = context.Heroes.Find(heroId);
            context.Heroes.Remove(hero);
        }

        public List<Hero> GetHero()
        {
            var result = context.Heroes.ToList();
            return result;
        }

        public Hero GetHeroByID(Guid heroId)
        {
            return context.Heroes.Find(heroId);
        }

        public void InsertHero(Hero hero)
        {
            context.Heroes.Add(hero);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateHero(Hero hero)
        {
            context.Entry(hero).State = EntityState.Modified;
        }


        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
