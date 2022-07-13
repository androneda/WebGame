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
        private readonly ISkillRepository _heroRepo;
        private readonly IMapper _mapper;
        public SkillService(ISkillRepository heroRepo, IMapper mapper)
        {
            _heroRepo = heroRepo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<SkillViewDto>> GetAll()
        {
            var temp = await _heroRepo.GetAll();

            if (temp.Any())
                return _mapper.Map<ICollection<SkillViewDto>>(temp);
            return Enumerable.Empty<SkillViewDto>();

        }
        public async Task Add(CreateSkillDto skillDto)
        {
            if (skillDto is null)
                throw new SkillNotFoundExeption("Способность с указанным идентификатором не найдена");
            var skill = _mapper.Map<Skill>(skillDto);
            await _heroRepo.AddAsync(skill);
        }

        public async Task Delete(Guid skillId)
        {
            await _heroRepo.DeleteAsync(skillId);
        }

        public async Task Update(UpdateSkillDto skillDto)
        {
            if (skillDto is null)
                throw new SkillNotFoundExeption("Способность с указанным идентификатором не найдена");

            var skill = _mapper.Map<Skill>(skillDto);
            await _heroRepo.UpdateAsync(skill);

        }
        public async Task<SkillViewDto> GetByID(Guid skillId)
        {
            var temp = await _heroRepo.GetByID(skillId);
            if (temp is null)
                throw new SkillNotFoundExeption("Способность с указанным идентификатором не найдена");
            return _mapper.Map<SkillViewDto>(temp);
        }
    }
}
