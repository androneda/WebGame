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
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _heroService.GetAll());
        }

        // GET: HeroController/GetHero/
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Details([FromRoute] Guid id)
        {
            
            return Ok(await _heroService.GetByID(id));
        }

        // Post: HeroController/AddHero
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateHeroDto hero)
        {
            await _heroService.Add(hero);
            return NoContent();
        }

        // Delete: HeroController/Delete/
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _heroService.Delete(id);
            return NoContent();
        }

        // Put: HeroController/Put/
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateHeroDto hero)
        {
            await _heroService.Update(id, hero);
            return NoContent();
        }
    }
}
