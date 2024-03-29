﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebGame.Core.Model.Specialization;
using WebGame.Core.Services.Interfaces;

namespace WebGame.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpecializationsController : ControllerBase
    {
        private readonly ISpecializationService _specializationService;
        public SpecializationsController(ISpecializationService specialization)
        {
            _specializationService = specialization;
        }

        // GET: HeroController/GetHeroes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _specializationService.GetAll());
        }

        // GET: HeroController/GetHero/
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Details([FromRoute] Guid id)
        {
            return Ok(await _specializationService.GetByID(id));
        }

        // Post: HeroController/AddHero
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSpecializationDto spec)
        {
            await _specializationService.Add(spec);
            return NoContent();
        }

        // Delete: HeroController/Delete/
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _specializationService.Delete(id);
            return NoContent();
        }

        // Put: HeroController/Put/
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateSpecializationDto spec)
        {
            await _specializationService.Update(id, spec);
            return NoContent();
        }
    }
}
