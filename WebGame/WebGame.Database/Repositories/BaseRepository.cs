using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGame.Database.Model;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Database.Repositories
{
    public class BaseRepository<TEntity>: IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly WebGameDBContext _context;
        DbSet<TEntity> _dbSet;

        public BaseRepository(WebGameDBContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public async Task DeleteAsync(Guid entityId)
        {
            TEntity entity = _dbSet.Find(entityId);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await SaveAsync();
            }
        }
        public async Task InsertAsync(TEntity entity)
        {
            if (entity != null)
            {
            await _dbSet.AddAsync(entity);
            await SaveAsync();
            }
        }
        public async Task UpdateAsync(TEntity entity)
        {
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Modified;
                await SaveAsync();
            }
        }

        public async Task<ICollection<TEntity>> GetAll()
        {
            try
            {
                return await _dbSet.AsNoTracking().ToListAsync();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public TEntity GetByID(Guid entityId)
        {
            return _dbSet.Find(entityId);
        }


        private async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
