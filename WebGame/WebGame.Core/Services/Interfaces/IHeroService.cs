using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Database.Model;

namespace WebGame.Core.Services.Interfaces
{
    public interface IHeroService
    {
        Task<ICollection<Hero>> GetAll();
        Hero GetByID(Guid heroId);
        Task Insert(Hero hero);
        Task Delete(Guid heroId);
        Task UpdateHero(Hero hero);
    }
}
