using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Core.Services.Interfaces;

namespace WebGame.Api.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] _roles;
        private readonly bool isRoleRequiered;
        private IJwtTokenHelper _jwtHelper;
        public CustomAuthorizeAttribute()
        {

        }

        public CustomAuthorizeAttribute(params string[] roles)
        {
            bool roleRequired = true;
            _roles = roles;
            isRoleRequiered = roleRequired;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            // authorization
            string token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            _jwtHelper = context.HttpContext.RequestServices.GetService<IJwtTokenHelper>();
            if (ValidateToken(token).IsFaulted || token is null)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
            else
            if (isRoleRequiered)
            {
                var claims = _jwtHelper.ReadClaims(token);
                string userRole = claims.Single(x => x.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Value.ToString();

                foreach (var neededRole in _roles)
                    if (neededRole == userRole)
                    {
                        context.Result = new JsonResult(new { message = "Forbidden" }) { StatusCode = StatusCodes.Status403Forbidden };
                        return;
                    }
                    else
                        context.Result = new JsonResult(new { message = "Forbidden" }) { StatusCode = StatusCodes.Status403Forbidden };

            }
        }

        private static Task ValidateToken(string token)
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
