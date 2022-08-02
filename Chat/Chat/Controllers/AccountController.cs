﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Chat.Data;
using Chat.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Chat.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationContext _context;
        public AccountController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpPost("/token")]
        public async Task<IActionResult> Token(string username, string password)
        {
            var identity = await GetIdentity(username, password);
            if (identity is null)
                return BadRequest("Invalid username or password.");

            var now = DateTime.Now;

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };
            return Json(response);
        }

        private async Task<ClaimsIdentity> GetIdentity(string username, string password)
        {
            User person = await _context.Users.Include(r => r.Role).FirstOrDefaultAsync(x => x.Email == username && x.Password == password);
            if (person is not null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role.Name)
                };
                ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            //если пользователь не найден
            return null;
        }


    }
}
