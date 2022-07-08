using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.Linq;
using WebGame.Database;
using WebGame.Database.Model;
using WebGame.Core.Services.Interfaces;
using System.Threading.Tasks;

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
        [HttpGet]
        [Route("/GetAll")]
        public async Task<IActionResult> Index()
        {
                return Ok(await _heroService.GetAll());
        }

        // GET: HeroController/GetHero/
        [HttpGet]
        [Route("/GetByID")]
        public async Task<IActionResult> Details([FromQuery]Guid id)
        {
            return Ok(await _heroService.GetByID(id));
        }

        // Post: HeroController/AddHero
        [HttpPost]
        [Route("/Add")]
        public async Task<IActionResult> Add([FromForm] Hero hero)
        {
            hero.Id= Guid.NewGuid();
            await _heroService.Insert(hero);
            return Ok(hero);
        }

        // Delete: HeroController/Delete/
        [HttpDelete]
        [Route ("/Delete")]
        public async Task<IActionResult> Delete([FromQuery]Guid id)
        {
            await _heroService.Delete(id);
            return Ok();
        }

        // Put: HeroController/Put/
        [HttpPut]
        [Route("/Put")]
        public async Task<IActionResult> Put([FromForm]Hero hero)
        {
            await _heroService.UpdateHero(hero);
            return Ok(await _heroService.GetAll());
        }


    }
}
