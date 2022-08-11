using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebGame.Core.Model.User;
using WebGame.Core.Services.Interfaces;

namespace WebGame.Api.Controllers
{
    [ApiController]
    [Authorize(Roles = "admin")]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: UsersController/GetUsers
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }

        // GET: HeroController/GetHero/
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Details([FromRoute] Guid id)
        {
            return Ok(await _userService.GetByID(id));
        }

        // Post: HeroController/AddHero
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserDto user)
        {
            await _userService.Add(user);
            return NoContent();
        }

        // Delete: HeroController/Delete/
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid userid)
        {
            await _userService.Delete(userid);
            return NoContent();
        }

        // Put: HeroController/Put/
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserDto hero)
        {
            await _userService.Update(hero);
            return NoContent();
        }
    }
}
