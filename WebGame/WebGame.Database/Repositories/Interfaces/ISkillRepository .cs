using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebGame.Database.Model;

namespace WebGame.Database.Repositories.Interfaces
{
    public interface ISkillRepository : IBaseRepository<Skill>
    {
        public Task<ICollection<Skill>> GetByRaceAsync(Guid raceId);
        public Task<ICollection<Skill>> GetBySpecAsync(Guid specId);
    }
}
