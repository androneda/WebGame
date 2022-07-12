using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Core.Model.Ammunition;
using WebGame.Core.Model.Hero;
using WebGame.Database.Model;

namespace WebGame.Core.Services.Interfaces
{
    public interface IAmmunitionService
    {
        Task<IEnumerable<AmmunitionViewDto>> GetAll();
        Task<AmmunitionViewDto> GetByID(Guid heroId);
        Task Add(CreateAmmunitionDto heroDto);
        Task Delete(Guid heroId);
        Task Update(UpdateAmmunitionDto heroDto);
    }
}
