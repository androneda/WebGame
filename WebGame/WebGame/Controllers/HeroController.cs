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

    public class HeroController : ControllerBase
    {
        private readonly IHeroService _heroService;
        public HeroController(IHeroService heroService) 
        {
            _heroService = heroService;
        }

        // GET: HeroController
        [HttpGet]
        [Route("/[controller]")]
        public async Task<IActionResult> Index()
        {
                return Ok(await _heroService.GetAll());
        }

        // GET: HeroController/Details/5
        [HttpGet]
        [Route("/Details")]
        public ActionResult Details(Guid id)
        {
            return Ok(_heroService.GetByID(id));
        }

        // GET: HeroController/Create
        [HttpGet]
        [Route("/Create")]
        public ActionResult Create(Hero hero)
        {
            hero.Id= Guid.NewGuid();
            _heroService.Insert(hero);
            return Ok(_heroService.GetAll());
        }

        // GET: HeroController/Delete/5
        [HttpGet]
        [Route ("/Delete")]
        public ActionResult Delete(Guid id)
        {
            _heroService.Delete(id);
            return Ok(_heroService.GetAll());
        }


    }
}
