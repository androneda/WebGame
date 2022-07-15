using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebGame.Database.Model;

namespace WebGame.Database.Repositories.Interfaces
{
    public interface ISkillRepository : IBaseRepository<Skill>
    {
        Task<ICollection<Skill>> GetByRaceAsync(Guid raceId);
        Task<ICollection<Skill>> GetBySpecAsync(Guid specId);
    }
}
