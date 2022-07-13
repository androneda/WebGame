using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Core.Model.Specialization;
using WebGame.Database.Model;

namespace WebGame.Core.Services.Interfaces
{
    public interface ISpecializationService
    {
        Task<IEnumerable<SpecializationViewDto>> GetAll();
        Task<SpecializationViewDto> GetByID(Guid heroId);
        Task Add(CreateSpecializationDto heroDto);
        Task Delete(Guid heroId);
        Task Update(UpdateSpecializationDto heroDto);
    }
}
