using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Api.Filters
{
    public class AuntificationFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                filterContext.Result = new UnauthorizedResult();
            }
            else
            {
                var token = filterContext.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
                if (ValidateToken(token).IsFaulted)
                {
                    filterContext.Result = new StatusCodeResult(402);
                }
            }
        }

        private Task ValidateToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("MySuperSecret_SecretKey123");
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return Task.FromException(new TaskCanceledException());
            }

            return Task.CompletedTask;
        }

    }
}
