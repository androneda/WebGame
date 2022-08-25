using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGame.Common.Exeptions;
using WebGame.Core.Model.Specialization;
using WebGame.Core.Services.Interfaces;
using WebGame.Database.Model;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Core.Services
{
    public class SpecializationService : ISpecializationService
    {
        private readonly ISpecializationRepository _specializationRepo;
        private readonly ISkillService _skillService;
        private readonly IMapper _mapper;

        public SpecializationService(ISpecializationRepository specializationRepo,
                                     ISkillService skillService, 
                                     IMapper mapper)
        {
            _specializationRepo = specializationRepo;
            _skillService = skillService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SpecializationViewDto>> GetAll()
        {
            var specializations = await _specializationRepo.GetAll();

            if (!specializations.Any())
                return Enumerable.Empty<SpecializationViewDto>();

            var specializationsDto = _mapper.Map<IEnumerable<SpecializationViewDto>>(specializations);

            foreach (var spec in specializationsDto)
                spec.Skills = await _skillService.GetBySpecId(spec.Id);

            return _mapper.Map<IEnumerable<SpecializationViewDto>>(specializationsDto);
        }

        public async Task Add(CreateSpecializationDto specDto)
        {
            if (specDto is null)
                throw new ArgumentException("Введите данные");

            var spec = _mapper.Map<Specialization>(specDto);
            await _specializationRepo.AddAsync(spec);
        }

        public async Task Delete(Guid specId)
        {
            await _specializationRepo.DeleteAsync(specId);
        }

        public async Task Update(UpdateSpecializationDto specDto)
        {
            if (specDto is null)
                throw new SpecializationNotFoundExeption("Специализация с указанным идентификатором не найдена");

            var spec = _mapper.Map<Specialization>(specDto);
            await _specializationRepo.UpdateAsync(spec);
        }

        public async Task<SpecializationViewDto> GetByID(Guid specId)
        {
            var temp = await _specializationRepo.GetByID(specId);
            if (temp is null)
                throw new SpecializationNotFoundExeption("Специализация с указанным идентификатором не найдена");

            var temp2 =  _mapper.Map<SpecializationViewDto>(temp);
            temp2.Skills = await _skillService.GetBySpecId(specId);
            return temp2;
        }
    }
}
