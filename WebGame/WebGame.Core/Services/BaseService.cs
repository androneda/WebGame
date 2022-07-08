using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Core.Services.Interfaces;
using WebGame.Database.Model;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Core.Services
{
    public class BaseService<TEntity>:IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _baseRepo;

        public BaseService(IBaseRepository<TEntity> baseRepo)
        {
            _baseRepo = baseRepo;
        }

        public async Task Delete(Guid entityId) => await _baseRepo.DeleteAsync(entityId);
        public async Task Insert(TEntity entity) => await _baseRepo.InsertAsync(entity);
        public async Task Update(TEntity entity) => await _baseRepo.UpdateAsync(entity);
        public async Task<ICollection<TEntity>> GetAll() => await _baseRepo.GetAll();
        public TEntity GetByID(Guid entityId) => _baseRepo.GetByID(entityId);
    }
}
