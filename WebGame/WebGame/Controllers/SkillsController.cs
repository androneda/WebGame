using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebGame.Core.Model.Skills;
using WebGame.Core.Services.Interfaces;

namespace WebGame.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;
        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        // GET: HeroController/GetHeroes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _skillService.GetAll());
        }

        // GET: HeroController/GetHero/
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Details([FromRoute] Guid id)
        {
            return Ok(await _skillService.GetByID(id));
        }

        // Post: HeroController/AddHero
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSkillDto skill)
        {
            await _skillService.Add(skill);
            return NoContent();
        }

        // Delete: HeroController/Delete/
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _skillService.Delete(id);
            return NoContent();
        }

        // Put: HeroController/Put/
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateSkillDto skill)
        {
            await _skillService.Update(id, skill);
            return NoContent();
        }
    }
}
