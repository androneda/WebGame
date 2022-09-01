using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebGame.Core.Model.Specialization;

namespace WebGame.Core.Services.Interfaces
{
    public interface ISpecializationService
    {
        Task<IEnumerable<SpecializationViewDto>> GetAll();
        Task<SpecializationViewDto> GetByID(Guid specializationId);
        Task Add(CreateSpecializationDto specializationDto);
        Task Delete(Guid specializationId);
        Task Update(Guid id, UpdateSpecializationDto specializationDto);
    }
}
