using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebGame.Core.Model.Hero;
using WebGame.Core.Services.Interfaces;

namespace WebGame.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HeroesController : ControllerBase
    {
        private readonly IHeroService _heroService;
        public HeroesController(IHeroService heroService)
        {
            _heroService = heroService;
        }

        // GET: HeroController/GetHeroes
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _heroService.GetAll());
        }

        // GET: HeroController/GetHero/
        [HttpGet("GetByID")]
        public async Task<IActionResult> Details([FromQuery] Guid id)
        {
            return Ok(await _heroService.GetByID(id));
        }

        // Post: HeroController/AddHero
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateHeroDto hero)
        {
            await _heroService.Insert(hero);
            return NoContent();
        }

        // Delete: HeroController/Delete/
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            await _heroService.Delete(id);
            return NoContent();
        }

        // Put: HeroController/Put/
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateHeroDto hero)
        {
            await _heroService.Update(hero);
            return NoContent();
        }


    }
}
