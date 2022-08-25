﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGame.Common.Exeptions;
using WebGame.Core.Model.Hero;
using WebGame.Core.Model.Skills;
using WebGame.Core.Services.Interfaces;
using WebGame.Database.Model;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Core.Services
{
    public class HeroService : IHeroService
    {
        private readonly IHeroRepository _heroRepo;
        private readonly IMapper _mapper;
        private readonly ISkillService _skillService;
        public HeroService(IHeroRepository heroRepo,
                           IMapper mapper,
                           ISkillService skillService)
        {
            _heroRepo = heroRepo;
            _mapper = mapper;
            _skillService = skillService;
        }

        public async Task<IEnumerable<HeroViewDto>> GetAll()
        {
            var temp = await _heroRepo.GetAll();

            if (!temp.Any())
                return Enumerable.Empty<HeroViewDto>();

            return _mapper.Map<IEnumerable<HeroViewDto>>(temp);
        }

        public async Task Add(CreateHeroDto heroDto)
        {
            if (heroDto is null)
                throw new ArgumentException("Герой с указанным идентификатором не найден");

            var hero = _mapper.Map<Hero>(heroDto);
            await _heroRepo.AddAsync(hero);
        }

        public async Task Delete(Guid heroId)
        {
            await _heroRepo.DeleteAsync(heroId);
        }

        public async Task Update(UpdateHeroDto heroDto)
        {
            var originalhero = await GetByID(heroDto.Id);

            heroDto.SpecializationId = originalhero.SpecializationId;
            heroDto.RaceId = originalhero.RaceId;

            var hero = _mapper.Map<Hero>(heroDto);
            await _heroRepo.UpdateAsync(hero);
        }

        public async Task<HeroViewDto> GetByID(Guid heroId)
        {
            var temp = await _heroRepo.GetByID(heroId);
            if (temp is null)
                throw new HeroNotFoundExeption("Герой с указанным идентификатором не найден");

            return _mapper.Map<HeroViewDto>(temp);
        }

        public async Task<IEnumerable<SkillViewDto>> GetSkillsByHeroId(Guid heroId)
        {
            IEnumerable<SkillViewDto> skills = await _skillService.GetByRaceId(heroId);
            skills = await _skillService.GetBySpecId(heroId);
            return skills;
        }
    }
}
