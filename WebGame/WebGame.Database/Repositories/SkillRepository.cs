using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public async Task<IEnumerable<Skill>> GetByRaceAsync(Guid raceId)
        {
            return await _dbSet.Where(x=>x.RaceId==raceId).ToListAsync();
        }

        public async Task<IEnumerable<Skill>> GetBySpecAsync(Guid specId)
        {
            return await _dbSet.Where(x => x.SpecializationId == specId).ToListAsync();
        }
    }
}
