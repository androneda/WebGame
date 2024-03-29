﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebGame.Database.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        Task DeleteAsync(Guid entityId);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<ICollection<TEntity>> GetAll();
        Task<TEntity> GetByID(Guid entityId);
    }
}
