using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using WebGame.Core.Services.Interfaces;
using WebGame.Database.Model;

namespace WebGame.Api.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userservice;
        public AccountController(IUserService userservice)
        {
            _userservice = userservice;
        }

        [HttpPost("/tokens")]
        public async Task<string> Login(string username, string password)
        {
            return await _userservice.Token(username, password);
        }




    }
}
