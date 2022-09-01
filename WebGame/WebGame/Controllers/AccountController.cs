using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebGame.Api.Attributes;
using WebGame.Core.Model.User;
using WebGame.Core.Services.Interfaces;

namespace WebGame.Api.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authservice;
        private readonly IUserService _userService;
        private readonly ISessionService _sessionService;
        private readonly IJwtTokenHelper _jwtHelper;
        public AccountController(IAuthService authservice, IUserService userservice,
            IJwtTokenHelper jwtHelper, ISessionService sessionService)
        {
            _authservice = authservice;
            _userService = userservice;
            _jwtHelper = jwtHelper;
            _sessionService = sessionService;
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

        [CustomAuthorize("admin", "user")]
        [HttpGet("getlogin")]
        public async Task<IActionResult> GetLogin()
        {
            var role = await _jwtHelper.GetRole(HttpContext.Request.Headers["Authorization"]);

            return Ok($"Ваша роль: {role}");
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Test(Guid id)
        {
            await _sessionService.DeactivateSessionAsync(id);

            return Ok();
        }


    }
}
