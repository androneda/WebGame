using WebGame.Core.Model.Account;

namespace WebGame.Core.Services.Interfaces
{
    public interface IAccountService
    {
        void SignUp(string username, string password);
        JsonWebToken SignIn(string username, string password);
        JsonWebToken RefreshAccessToken(string token);
        void RevokeRefreshToken(string token);
    }
}