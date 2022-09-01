using System;
using System.Threading.Tasks;
using WebGame.Database.Model;

namespace WebGame.Database.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetIdentity(string username, string password);
        Task<User> GetIdentity(Guid id);
    }
}
