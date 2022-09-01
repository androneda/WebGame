using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebGame.Core.Model.Races;
using WebGame.Core.Services.Interfaces;

namespace WebGame.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RacesController : ControllerBase
    {
        private readonly IRaceService _raceService;
        public RacesController(IRaceService raceService)
        {
            _raceService = raceService;
        }

        // GET: RacesController/GetRaces
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _raceService.GetAllAsync());
        }

        // GET: RacesController/GetRace/
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Details([FromRoute] Guid id)
        {
            return Ok(await _raceService.GetById(id));
        }

        // Post: RacesController/AddRace
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateRaceDto raceDto)
        {
            await _raceService.Add(raceDto);
            return NoContent();
        }

        // Delete: RacesController/Delete/
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _raceService.Delete(id);
            return NoContent();
        }

        // Put: RacesController/Put/
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRaceDto race)
        {
            await _raceService.Update(id, race);
            return NoContent();
        }
    }
}
