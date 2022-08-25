using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using WebGame.Common;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using WebGame.Core.Services.Interfaces;
using WebGame.Database.Model;
using WebGame.Core.Model.Role;

namespace WebGame.Core.Services
{
    public class JwtTokenHelper : IJwtTokenHelper
{
        private readonly AuthOptions _authOptions;
        private readonly ISessionService _sessionService;
        private readonly IUserService _userService;
        public JwtTokenHelper(IOptions<AuthOptions> authOptions, ISessionService sessionService, IUserService userService)
        {
            _authOptions = authOptions.Value;
            _sessionService = sessionService;
            _userService = userService;
        }

        public string Create(User user)
        {
            var now = DateTime.UtcNow;

            var identity = SetClaim(user);

            var jwt = new JwtSecurityToken(
                issuer: _authOptions.ISSUER,
                audience: _authOptions.AUDIENCE,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(_authOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_authOptions.KEY)), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public IEnumerable<Claim> ReadClaims(string jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwt);
            var tokenS = jsonToken as JwtSecurityToken;
            return tokenS.Claims;
        }

        private ClaimsIdentity SetClaim(User user)
        {
            var session = new Session(user.Id,user.RoleId);
            _sessionService.Add(session);

            var claims = new List<Claim>
                {
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("Session", session.Id.ToString())
                };

            ClaimsIdentity claimsIdentity =
                new(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }

        public async Task<string> GetRole(string jwt)
        {
            var claims = ReadClaims(jwt);

            var userId = claims.FirstOrDefault().Value;
            Guid.TryParse(userId, out var userGuid);
            var user = await _userService.GetByID(userGuid);
            return user.Role.Name;
        }
    }
}
