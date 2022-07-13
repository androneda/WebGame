using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        
    }
}
