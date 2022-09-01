using System.Threading.Tasks;
using WebGame.Common.Exeptions;
using WebGame.Core.Services.Interfaces;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly IJwtTokenHelper _jwtTokenHelper;
        private readonly IPasswordService _passwordService;
        public AuthService(IUserRepository userRepo, IJwtTokenHelper jwtTokenHelper, IPasswordService passwordService)
        {
            _userRepo = userRepo;
            _jwtTokenHelper = jwtTokenHelper;
            _passwordService = passwordService;
        }
        public async Task<string> Login(string username, string password)
        {
            password = _passwordService.GenerateSaltedHash(password);

            var user = await _userRepo.GetIdentity(username, password);
            if (user is null)
                throw new UserNotFoundExeption("Invalid username or password.");

            var encodedJwt = _jwtTokenHelper.Create(user);

            return encodedJwt;
        }
    }
}
