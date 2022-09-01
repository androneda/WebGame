using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebGame.Core.Model.Ammunition;

namespace WebGame.Core.Services.Interfaces
{
    public interface IAmmunitionService
    {
        Task<IEnumerable<AmmunitionViewDto>> GetAll();
        Task<AmmunitionViewDto> GetByID(Guid ammunitionId);
        Task Add(CreateAmmunitionDto ammunitionDto);
        Task Delete(Guid ammunitionId);
        Task Update(Guid id, UpdateAmmunitionDto ammunitionDto);
    }
}
