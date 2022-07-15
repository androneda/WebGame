using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Core.Model.Skills;
using WebGame.Database.Model;

namespace WebGame.Core.Services.Interfaces
{
    public interface ISkillService
    {
        Task<IEnumerable<SkillViewDto>> GetAll();
        Task<SkillViewDto> GetByID(Guid skillId);
        Task Add(CreateSkillDto skillDto);
        Task Delete(Guid skillId);
        Task Update(UpdateSkillDto skillId);

        Task<IEnumerable<Skill>> GetBySpecId(Guid specializationId);
        Task<IEnumerable<Skill>> GetByRaceId(Guid raceId);
    }
}
