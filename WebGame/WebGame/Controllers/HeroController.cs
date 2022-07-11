using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebGame.Common.Exeptions;
using WebGame.Core.Services.Interfaces;
using WebGame.Database.Model;

namespace WebGame.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HeroController : ControllerBase
    {
        private readonly IHeroService _heroService;
        public HeroController(IHeroService heroService)
        {
            _heroService = heroService;
        }

        // GET: HeroController/GetHeroes
        [HttpGet("/GetAll")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _heroService.GetAll());
        }

        // GET: HeroController/GetHero/
        [HttpGet("/GetByID")]
        public async Task<IActionResult> Details([FromQuery] Guid id)
        {
            return Ok(await _heroService.GetByID(id));
        }

        // Post: HeroController/AddHero
        [HttpPost("/Add")]
        public async Task<IActionResult> Add([FromForm] Hero hero)
        {
            hero.Id = Guid.NewGuid();
            await _heroService.Insert(hero);
            return Ok(hero);
        }

        // Delete: HeroController/Delete/
        [HttpDelete("/Delete")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            await _heroService.Delete(id);
            return Ok();
        }

        // Put: HeroController/Put/
        [HttpPut("/Put")]
        public async Task<IActionResult> Update([FromForm] Hero hero)
        {
            try
            {
                if (hero is null)
                    throw new HeroNotFoundExeption("Герой с указанным идентификатором не найден");
            }
            catch (Exception ex)
            {
                //return ex.Message;
            }

            await _heroService.UpdateHero(hero);
            return Ok(await _heroService.GetAll());
        }


    }
}
