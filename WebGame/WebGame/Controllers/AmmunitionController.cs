using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebGame.Core.Model.Ammunition;
using WebGame.Core.Model.Hero;
using WebGame.Core.Services.Interfaces;

namespace WebGame.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AmmunitionController : ControllerBase
    {
        private readonly IAmmunitionService _ammunitionService;
        public AmmunitionController(IAmmunitionService ammunitionService)
        {
            _ammunitionService = ammunitionService;
        }

        // GET: HeroController/GetHeroes
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _ammunitionService.GetAll());
        }

        // GET: HeroController/GetHero/
        [HttpGet("GetByID")]
        public async Task<IActionResult> Details([FromQuery] Guid id)
        {
            return Ok(await _ammunitionService.GetByID(id));
        }

        // Post: HeroController/AddHero
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateAmmunitionDto ammunitionDto)
        {
            await _ammunitionService.Add(ammunitionDto);
            return NoContent();
        }

        // Delete: HeroController/Delete/
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            await _ammunitionService.Delete(id);
            return NoContent();
        }

        // Put: HeroController/Put/
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateAmmunitionDto ammunitionDto)
        {
            await _ammunitionService.Update(ammunitionDto);
            return NoContent();
        }


    }
}
