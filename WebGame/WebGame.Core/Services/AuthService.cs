using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebGame.Common.Exeptions;
using WebGame.Core.Services.Interfaces;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly JwtTokenHelper _jwtTokenHelper;
        public AuthService(IUserRepository userRepo, JwtTokenHelper jwtTokenHelper)
        {
            _userRepo = userRepo;
            _jwtTokenHelper = jwtTokenHelper;
        }
        public async Task<string> Login(string username, string password)
        {
            var user = await _userRepo.GetIdentity(username, password);
            if (user is null)
                throw new UserNotFoundExeption("Invalid username or password.");

            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
                };
            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            var encodedJwt = _jwtTokenHelper.Create(claimsIdentity);

            return encodedJwt;
        }
    }
}
