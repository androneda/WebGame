using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGame.Database.Model;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Database.Repositories
{
    public class SessionRepository : BaseRepository<Session>, ISessionRepository
    {
        public SessionRepository(WebGameDBContext context) : base (context)  
        {

        }
        public  IEnumerable<Session> GetSessionByUser(Guid id)
        {
            return _dbSet.Where(x => x.UserId == id).ToList();
        }
    }
}
