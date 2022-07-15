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
            var temp = await _dbSet.Where(x=>x.RaceId==raceId).ToListAsync();
            if (!temp.Any())
                return  Enumerable.Empty<Skill>();
            return temp;
        }

        public async Task<IEnumerable<Skill>> GetBySpecAsync(Guid specId)
        {
            var temp = await _dbSet.Where(x => x.SpecializationId == specId).ToListAsync();
            if (!temp.Any())
                return Enumerable.Empty<Skill>();
            return temp;
        }
    }
}
