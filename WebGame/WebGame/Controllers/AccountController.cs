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
using WebGame.Core.Model.Account;
using WebGame.Core.Services.Interfaces;
using WebGame.Database.Model;

namespace WebGame.Api.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IJwtTokenHelper _tokenHelper;

        public AccountController(IAccountService accountService,
                IJwtTokenHelper tokenHelper)
        {
            _accountService = accountService;
            _tokenHelper = tokenHelper;
        }

        [HttpGet("account")]
        public IActionResult Get([FromQuery] SignUp request)
            => Content($"Hello {User.Identity.Name}");

        [HttpPost("sign-up")]
        [AllowAnonymous]
        public IActionResult SignUp([FromBody] SignUp request)
        {
            _accountService.SignUp(request.Username, request.Password);

            return NoContent();
        }

        [HttpPost("sign-in")]
        [AllowAnonymous]
        public IActionResult SignIn([FromBody] SignIn request)
            => Ok(_accountService.SignIn(request.Username, request.Password));

        [HttpPost("tokens/{token}/refresh")]
        [AllowAnonymous]
        public IActionResult RefreshAccessToken(string token)
            => Ok(_accountService.RefreshAccessToken(token));

        [HttpPost("tokens/{token}/revoke")]
        public IActionResult RevokeRefreshToken(string token)
        {
            _accountService.RevokeRefreshToken(token);

            return NoContent();
        }

        [HttpPost("tokens/cancel")]
        public async Task<IActionResult> CancelAccessToken()
        {
            await _tokenHelper.DeactivateCurrentAsync();

            return NoContent();
        }
    }
}
