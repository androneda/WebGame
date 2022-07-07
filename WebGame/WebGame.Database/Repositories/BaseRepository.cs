using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebGame.Database.Model;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Database.Repositories
{
    public class BaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly WebGameDBContext _context;
        DbSet<TEntity> _dbSet;

        public BaseRepository(WebGameDBContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public async Task DeleteAsync(Guid Id)
        {
            TEntity entity = _dbSet.Find(Id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await SaveAsync();
            }
        }
        public async Task InsertAsync(TEntity hero)
        {
            if (hero != null)
            {
            await _dbSet.AddAsync(hero);
            await SaveAsync();
            }
        }
        public async Task UpdateAsync(TEntity hero)
        {
            if (hero != null)
            {
                _context.Entry(hero).State = EntityState.Modified;
                await SaveAsync();
            }
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public TEntity GetByID(Guid heroId)
        {
            return _dbSet.Find(heroId); //Тут что нибудь еще надо?
        }


        private async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
