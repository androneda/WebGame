using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGame.Common.Exeptions;
using WebGame.Core.Model.Skills;
using WebGame.Core.Services.Interfaces;
using WebGame.Database.Model;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Core.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepo;
        private readonly IMapper _mapper;

        public SkillService(ISkillRepository skillRepo,
                            IMapper mapper)
        {
            _skillRepo = skillRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SkillViewDto>> GetAll()
        {
            var temp = await _skillRepo.GetAll();

            if (temp.Any())
                return _mapper.Map<IEnumerable<SkillViewDto>>(temp);

            return Enumerable.Empty<SkillViewDto>();
        }

        public async Task Add(CreateSkillDto skillDto)
        {
            if (skillDto is null)
                throw new ArgumentException("Введите данные");

            var skill = _mapper.Map<Skill>(skillDto);
            await _skillRepo.AddAsync(skill);
        }

        public async Task Delete(Guid skillId)
        {
            await _skillRepo.DeleteAsync(skillId);
        }

        public async Task Update(UpdateSkillDto skillDto)
        {
            if (skillDto is null)
                throw new SkillNotFoundExeption("Способность с указанным идентификатором не найдена");

            var skill = _mapper.Map<Skill>(skillDto);
            await _skillRepo.UpdateAsync(skill);
        }

        public async Task<SkillViewDto> GetByID(Guid skillId)
        {
            var temp = await _skillRepo.GetByID(skillId);
            if (temp is null)
                throw new SkillNotFoundExeption("Способность с указанным идентификатором не найдена");

            return _mapper.Map<SkillViewDto>(temp);
        }

        public async Task<IEnumerable<SkillViewDto>> GetBySpecId(Guid specializationId)
        {
            var temp = await _skillRepo.GetBySpecAsync(specializationId);

            if (!temp.Any())
                return Enumerable.Empty<SkillViewDto>();

            return _mapper.Map<IEnumerable<SkillViewDto>>(temp);
        }

        public async Task<IEnumerable<SkillViewDto>> GetByRaceId(Guid raceId)
        {
            var temp = await _skillRepo.GetByRaceAsync(raceId);

            if (!temp.Any())
                return Enumerable.Empty<SkillViewDto>();

            return _mapper.Map<IEnumerable<SkillViewDto>>(temp);
        }


    }
}
