using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Core.Services.Interfaces
{
    public interface IJwtTokenHelper
    {
        string Create(ClaimsIdentity identity);
        IEnumerable<Claim> ReadClaims(string jwt);
    }
}
