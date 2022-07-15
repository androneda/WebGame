using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebGame.Database.Model;

namespace WebGame.Database.Repositories.Interfaces
{
    public interface ISkillRepository : IBaseRepository<Skill>
    {
        Task<IEnumerable<Skill>> GetByRaceAsync(Guid raceId);
        Task<IEnumerable<Skill>> GetBySpecAsync(Guid specId);
    }
}
