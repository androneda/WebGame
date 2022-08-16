﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Common;
using WebGame.Core.Services.Interfaces;

namespace WebGame.Api.Middlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private AuthOptions _authOptions;
        private IUserService _userService;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context ,IOptions<AuthOptions> authOptions, IUserService userService)
        {

            _authOptions = authOptions.Value;
            _userService = userService;

            var token = context.Request.Headers["Authorization"].FirstOrDefault();
            if (token is not null)
            {
                await ValidateToken(token);
                context.Request.Headers["Authorization"] = "Bearer " + token;
            }
            

            await _next(context);
        }

        private Task ValidateToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_authOptions.KEY);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                //var accountId = Guid.Parse(jwtToken.Claims.First(x => x.Value == "admin").Value);
            }
            catch
            {
                // do nothing if jwt validation fails
                // account is not attached to context so request won't have access to secure routes
            }

            return Task.CompletedTask;
        }
    }
}
