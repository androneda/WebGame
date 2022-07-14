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
        public SpecializationService(ISpecializationRepository specializationRepo, ISkillService skillService, IMapper mapper)
        {
            _specializationRepo = specializationRepo;
            _skillService = skillService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SpecializationViewDto>> GetAll()
        {
            var temp = await _specializationRepo.GetAll();

            if (temp.Any())
            {
                foreach (var item in temp)
                {
                    item.Skills = await _skillService.GetBySpecId(item.Id);
                }
                return _mapper.Map<ICollection<SpecializationViewDto>>(temp);
            }
            return Enumerable.Empty<SpecializationViewDto>();
        }

        public async Task Add(CreateSpecializationDto specDto)
        {
            if (specDto is null)
                throw new SpecializationNotFoundExeption("Специализация с указанным идентификатором не найдена");
            var hero = _mapper.Map<Specialization>(specDto);
            await _specializationRepo.AddAsync(hero);
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
            temp.Skills = await _skillService.GetBySpecId(specId);
            if (temp is null)
                throw new SpecializationNotFoundExeption("Специализация с указанным идентификатором не найдена");
            return _mapper.Map<SpecializationViewDto>(temp);
        }
    }
}
