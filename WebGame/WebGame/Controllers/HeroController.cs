using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.Linq;
using WebGame.Database;
using WebGame.Database.Model;

namespace WebGame.Api.Controllers
{
    public class HeroController : Controller
    {



        // GET: HeroController
        [HttpGet]
        [Route("/[controller]")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: test
        [HttpGet]
        [Route("/[controller]/{id}")]
        public ActionResult Test()
        {
            var optionsBuilder = new DbContextOptionsBuilder<WebGameDBContext>();
            var options = optionsBuilder.UseNpgsql("User ID=postgres; Password=postgres;Host=localhost;Port=5432;Database=WebGameBD;Pooling=true").Options;

            WebGameDBContext db = new(options);

            Hero hero = new Hero() { Id = Guid.NewGuid(), Name="Виталя" };
            db.Heroes.Add(hero);

            return View(db.Heroes.ToList());
        }

        // GET: HeroController/Details/5
        [HttpGet]
        [Route("/WebGame/[controller]/Details")]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HeroController/Create
        [HttpGet]
        [Route("/WebGame/[controller]/")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: HeroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HeroController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HeroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HeroController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HeroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
