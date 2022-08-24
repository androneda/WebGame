using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebGame.Api.Attributes;
using WebGame.Core.Model.User;
using WebGame.Core.Services;
using WebGame.Core.Services.Interfaces;

namespace WebGame.Api.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authservice;
        private readonly IUserService _userService;
        private readonly IJwtTokenHelper _jwtHelper;
        public AccountController(IAuthService authservice, IUserService userservice, IJwtTokenHelper jwtHelper)
        {
            _authservice = authservice;
            _userService = userservice;
            _jwtHelper = jwtHelper;
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

        [CustomAuthorize("admin","user")]
        [HttpGet("getlogin")]
        public IActionResult GetLogin()
        {
            var claims = _jwtHelper.ReadClaims(HttpContext.Request.Headers["Authorization"]);

            var userId = claims.FirstOrDefault().Value;
            Guid.TryParse(userId, out var user);
            var role = _userService.GetModelByID(user).Result.Role.Name;

            return Ok($"Ваш логин: {role}");
        }


    }
}
