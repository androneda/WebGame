using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Core.Model.Hero;
using WebGame.Database.Model;

namespace WebGame.Core.Services.Interfaces
{
    public interface IHeroService
    {
        Task<ICollection<HeroViewDto>> GetAll();
        Task<HeroViewDto> GetByID(Guid heroId);
        Task Insert(CreateHeroDto heroDto);
        Task Delete(Guid heroId);
        Task Update(UpdateHeroDto heroDto);
    }
}
