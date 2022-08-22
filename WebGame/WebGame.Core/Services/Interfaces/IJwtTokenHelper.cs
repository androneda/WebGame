using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebGame.Database.Model;

namespace WebGame.Core.Services.Interfaces
{
    public interface IJwtTokenHelper
    {
        string Create(User user);
        IEnumerable<Claim> ReadClaims(string jwt);
    }
}
