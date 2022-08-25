using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WebGame.Database.Model;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Database.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(WebGameDBContext context) : base (context)  
        {

        }

        public async Task<User> GetIdentity(string username, string password)
        {
            return await _dbSet.Include(r => r.Role).FirstOrDefaultAsync(x => x.Login == username && x.Password == password);
        }
        public async Task<User> GetIdentity(Guid id)
        {
            return await _dbSet.Include(r => r.Role).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
