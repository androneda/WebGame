using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGame.Database.Model;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Database.Repositories
{
    public class SkillRepository : BaseRepository<Skill>, ISkillRepository
    {

        public SkillRepository(WebGameDBContext context) : base (context)  
        {
        }

        public async Task<ICollection<Skill>> GetByRaceAsync(Guid raceId)
        {
            return await _dbSet.Where(x=>x.RaceId==raceId).ToListAsync();
        }

        public async Task<ICollection<Skill>> GetBySpecAsync(Guid specId)
        {
            return await _dbSet.Where(x => x.SpecializationId == specId).ToListAsync();
        }
    }
}
