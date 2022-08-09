using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using WebGame.Core.Services.Interfaces;
using WebGame.Database.Model;

namespace WebGame.Api.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authservice;
        public AccountController(IAuthService authservice)
        {
            _authservice = authservice;
        }

        [HttpPost("/token")]
        public async Task<IActionResult> LoginAsync(string username, string password)
        {
            var encodedJwt = await _authservice.Login(username, password);
            return Json(encodedJwt);
        }



        [Authorize]
        [HttpGet("getlogin")]
        public IActionResult GetLogin()
        {
            return Ok($"Ваш логин: {User.Identity.Name}");
        }

        //private List<User> people = new List<User>
        //{
        //    new User {Login="admin@gmail.com", Password="12345"},
        //    new User { Login="qwerty@gmail.com", Password="55555"}
        //};

        //[HttpPost("/token")]

        //public IActionResult Token(string username, string password)
        //{
        //    var identity = GetIdentity(username, password);  
        //    if (identity == null)
        //    {
        //        return BadRequest(new { errorText = "Invalid username or password." });
        //    }

        //    var now = DateTime.UtcNow;
        //    // создаем JWT-токен
        //    var jwt = new JwtSecurityToken(
        //            issuer: AuthOptions.ISSUER,
        //            audience: AuthOptions.AUDIENCE,
        //            notBefore: now,
        //            claims: identity.Claims,
        //            expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
        //            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        //    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        //    HttpContext.User.AddIdentity(identity);  //??????

        //    var response = new
        //    {
        //        access_token = encodedJwt,
        //        username = identity.Name
        //    };

        //    return Json(response);
        //}

        //private ClaimsIdentity GetIdentity(string username, string password)
        //{
        //    User person = people.FirstOrDefault(x => x.Login == username && x.Password == password);
        //    if (person != null)
        //    {
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login)
        //        };
        //        ClaimsIdentity claimsIdentity =
        //        new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
        //            ClaimsIdentity.DefaultRoleClaimType);
        //        return claimsIdentity;
        //    }

        //    // если пользователя не найдено
        //    return null;
        //}

    }
}
