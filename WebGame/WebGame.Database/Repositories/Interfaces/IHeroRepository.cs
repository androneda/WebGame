using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebGame.Database.Model;

namespace WebGame.Database.Repositories.Interfaces
{
    public interface IHeroRepository
    {
            Task DeleteAsync(Guid heroId);
            Task InsertAsync(Hero hero);
            Task<IEnumerable<Hero>> GetAll();
            Hero GetByID(Guid heroId);
            Task UpdateAsync(Hero hero);
    }
}
