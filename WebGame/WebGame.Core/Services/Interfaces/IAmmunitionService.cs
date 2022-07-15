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
        Task<AmmunitionViewDto> GetByID(Guid AmmunitionId);
        Task Add(CreateAmmunitionDto AmmunitionDto);
        Task Delete(Guid AmmunitionId);
        Task Update(UpdateAmmunitionDto AmmunitionDto);
    }
}
