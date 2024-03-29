﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebGame.Core.Model.Skills;

namespace WebGame.Core.Services.Interfaces
{
    public interface ISkillService
    {
        Task<IEnumerable<SkillViewDto>> GetAll();
        Task<SkillViewDto> GetByID(Guid skillId);
        Task Add(CreateSkillDto skillDto);
        Task Delete(Guid skillId);
        Task Update(Guid id, UpdateSkillDto skillId);

        Task<IEnumerable<SkillViewDto>> GetBySpecId(Guid specializationId);
        Task<IEnumerable<SkillViewDto>> GetByRaceId(Guid raceId);
    }
}
