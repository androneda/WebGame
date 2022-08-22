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

namespace WebGame.Core.Services
{
    public class JwtTokenHelper : IJwtTokenHelper
{
        private readonly AuthOptions _authOptions;
        public JwtTokenHelper(IOptions<AuthOptions> authOptions)
        {
            _authOptions = authOptions.Value;
        }
        public string Create(ClaimsIdentity identity)
        {
            var now = DateTime.UtcNow;

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
            var stream = jwt;
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(stream);
            var tokenS = jsonToken as JwtSecurityToken;
            var Claims = tokenS.Claims;

            return Claims;
        }
    }
}
