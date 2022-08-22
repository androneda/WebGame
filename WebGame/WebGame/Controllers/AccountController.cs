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
using WebGame.Api.Attributes;
using WebGame.Api.Filters;
using WebGame.Core.Model.User;
using WebGame.Core.Services.Interfaces;
using WebGame.Database.Model;

namespace WebGame.Api.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authservice;
        private readonly IUserService _userService;
        public AccountController(IAuthService authservice, IUserService userservice)
        {
            _authservice = authservice;
            _userService = userservice;
        }

        [HttpPost("/login")]
        public async Task<IActionResult> LoginAsync(string username, string password)
        {
            var encodedJwt = await _authservice.Login(username, password);
            return Json(encodedJwt);
        }

        [HttpPost("/register")]
        public async Task<IActionResult> RegisterAsync([FromBody] CreateUserDto userDto)
        {
            await _userService.Add(userDto);
            return Ok();
        }

        [CustomAuthorize]
        [HttpGet("getlogin")]
        public IActionResult GetLogin()
        {
            return Ok($"Ваш логин: {User.Identity.Name}");
        }


    }
}
