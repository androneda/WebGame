using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Database.Model;

namespace WebGame.Core.Services.Interfaces
{
    public interface IBaseService<TEntity>
    {
        Task<ICollection<TEntity>> GetAll();
        TEntity GetByID(Guid heroId);
        Task Insert(TEntity hero);
        Task Update(TEntity hero);
        Task Delete(Guid heroId);
    }
}
