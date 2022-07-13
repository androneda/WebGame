using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebGame.Database.Model;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Database.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly WebGameDBContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(WebGameDBContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public async Task DeleteAsync(Guid entityId)
        {
            TEntity entity = _dbSet.Find(entityId);
            if (entity is not null)
            {
                _dbSet.Remove(entity);
                await SaveAsync();
            }
        }
        public async Task AddAsync(TEntity entity)
        {

            await _dbSet.AddAsync(entity);
            await SaveAsync();

        }
        public async Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await SaveAsync();
        }

        public async Task<ICollection<TEntity>> GetAll()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByID(Guid entityId)
        {
            return await _dbSet.FindAsync(entityId);
        }


        private async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
