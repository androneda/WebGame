using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Database.Repositories.Interfaces
{
    internal interface IBaseRepository<TEntity>
    {
        public Task DeleteAsync(Guid Id);
        public Task InsertAsync(TEntity hero);
        public Task UpdateAsync(TEntity hero);
        public Task<IEnumerable<TEntity>> GetAll();

    }
}
