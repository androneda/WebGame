using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebGame.Database.Model;

namespace WebGame.Database.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        Task DeleteAsync(Guid entityId);
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<ICollection<TEntity>> GetAll();
        Task<TEntity> GetByID(Guid entityId);

    }
}
