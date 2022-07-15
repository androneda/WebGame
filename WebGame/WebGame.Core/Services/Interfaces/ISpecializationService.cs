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
        Task<SpecializationViewDto> GetByID(Guid specializationId);
        Task Add(CreateSpecializationDto specializationDto);
        Task Delete(Guid specializationId);
        Task Update(UpdateSpecializationDto specializationDto);
    }
}
