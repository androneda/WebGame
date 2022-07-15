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
        Task<AmmunitionViewDto> GetByID(Guid ammunitionId);
        Task Add(CreateAmmunitionDto ammunitionDto);
        Task Delete(Guid ammunitionId);
        Task Update(UpdateAmmunitionDto ammunitionDto);
    }
}
