using System.Threading.Tasks;

namespace WebGame.Core.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Login(string username, string password);
    }
}
