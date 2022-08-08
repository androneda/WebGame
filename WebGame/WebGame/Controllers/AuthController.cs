using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebGame.Core.Services.Interfaces;

namespace WebGame.Api.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authorizationService;
        public AuthController(IAuthService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] string username, string password)
        {
            _authorizationService.Login(username, password);
            return Ok();
        }
        
        [Authorize]
        [HttpPost]
        public IActionResult LogOut()
        {
            
            return Ok();
        }

        [HttpPost]
        public IActionResult Registration([FromBody] string username, string password)
        {
            _authorizationService.Login(username, password);
            return Ok();
        }
    }
}
