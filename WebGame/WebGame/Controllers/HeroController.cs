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

namespace WebGame.Api.Controllers
{
    [ApiController]
    [Route ("/[controller]")]
    public class HeroController : Controller
    {
        private readonly IHeroService _heroService;
        public HeroController(IHeroService heroService) 
        {
            _heroService = heroService;
        }

        // GET: HeroController
        [HttpGet]
        public ActionResult Index()
        {
            return Ok(_heroService.GetHeroes());
        }

        // GET: HeroController/Details/5
        [HttpGet]
        [Route("/Details")]
        public ActionResult Details()
        {
            return View();
        }

        // GET: HeroController/Create
        [HttpGet]
        [Route("/Create")]
        public ActionResult Create(Hero hero)
        {
            hero.Id= Guid.NewGuid();
            _heroService.InsertHero(hero);
            return Ok(_heroService.GetHeroes());
        }

        // GET: HeroController/Delete/5
        [HttpGet]
        [Route ("/Delete")]
        public ActionResult Delete(Guid id)
        {
            _heroService.DeleteHero(id);
            return Ok(_heroService.GetHeroes());
        }


    }
}
