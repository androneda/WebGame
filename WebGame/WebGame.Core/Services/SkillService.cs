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
            var skills = await _skillRepo.GetAll();

            if (skills.Any())
                return _mapper.Map<IEnumerable<SkillViewDto>>(skills);

            return Enumerable.Empty<SkillViewDto>();
        }

        public async Task Add(CreateSkillDto skillDto)
        {
            if (skillDto is null)
                throw new CustomArgumentException("Введите данные");

            var skill = _mapper.Map<Skill>(skillDto);
            await _skillRepo.AddAsync(skill);
        }

        public async Task Delete(Guid skillId)
        {
            await _skillRepo.DeleteAsync(skillId);
        }

        public async Task Update(Guid id, UpdateSkillDto skillDto)
        {
            if (skillDto is null)
                throw new CustomArgumentException("Введите данные");

            var skill = await _skillRepo.GetByID(id);

            skill.Status = skillDto.Status;
            skill.RaceId = skillDto.RaceId;
            skill.Name = skillDto.Name;
            skill.IsOnAlly = skillDto.IsOnAlly;
            skill.Range = skillDto.Range;
            skill.RechargeTime = skillDto.RechargeTime;
            skill.SpecializationId = skillDto.SpecializationId;
            skill.BaseStat = skillDto.BaseStat;
            skill.BonusActionPoints = skillDto.BonusActionPoints;
            skill.CostActionPoints = skillDto.CostActionPoints;
            skill.DamageRadius = skillDto.DamageRadius;

            await _skillRepo.UpdateAsync(skill);
        }

        public async Task<SkillViewDto> GetByID(Guid skillId)
        {
            var skill = await _skillRepo.GetByID(skillId);
            if (skill is null)
                throw new SkillNotFoundExeption("Способность с указанным идентификатором не найдена");

            return _mapper.Map<SkillViewDto>(skill);
        }

        public async Task<IEnumerable<SkillViewDto>> GetBySpecId(Guid specializationId)
        {
            var skills = await _skillRepo.GetBySpecAsync(specializationId);

            if (!skills.Any())
                return Enumerable.Empty<SkillViewDto>();

            return _mapper.Map<IEnumerable<SkillViewDto>>(skills);
        }

        public async Task<IEnumerable<SkillViewDto>> GetByRaceId(Guid raceId)
        {
            var skills = await _skillRepo.GetByRaceAsync(raceId);

            if (!skills.Any())
                return Enumerable.Empty<SkillViewDto>();

            return _mapper.Map<IEnumerable<SkillViewDto>>(skills);
        }


    }
}
