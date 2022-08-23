﻿using Microsoft.AspNetCore.Authorization;
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
        private IUserSessionService _userSesionService;
        private IUserService _userService;
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

            _userSesionService = context.HttpContext.RequestServices.GetService<IUserSessionService>();
            _userService = context.HttpContext.RequestServices.GetService<IUserService>();
            _jwtHelper = context.HttpContext.RequestServices.GetService<IJwtTokenHelper>();

            // authorization
            string token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();



            if (ValidateToken(token).IsFaulted || token is null)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
            else
            if (isRoleRequiered)
            {
                var claims = _jwtHelper.ReadClaims(token);

                string userId = claims.Single(x => x.Type == "UserId").Value;

                var temp = Guid.TryParse(userId, out var guidUser);

                var userRole = _userService.GetModelByID(guidUser).Result.Role.Name;

                string userSessionId = claims.Single(x => x.Type == "Session").Value;

                temp = Guid.TryParse(userSessionId, out var guidSession);

                var session = _userSesionService.GetByID(guidSession);

                if (session.Result.IsActive is true)
                foreach (var neededRole in _roles)
                    if (neededRole == userRole)
                    {
                        context.Result = null;
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
