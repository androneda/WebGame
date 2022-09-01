using AutoMapper;
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
            var heroes = await _heroRepo.GetAll();

            if (!heroes.Any())
                return Enumerable.Empty<HeroViewDto>();

            return _mapper.Map<IEnumerable<HeroViewDto>>(heroes);
        }

        public async Task Add(CreateHeroDto heroDto)
        {
            if (heroDto is null)
                throw new CustomArgumentException("Введите данные");

            var hero = _mapper.Map<Hero>(heroDto);
            await _heroRepo.AddAsync(hero);
        }

        public async Task Delete(Guid heroId)
        {
            await _heroRepo.DeleteAsync(heroId);
        }

        public async Task Update(Guid id, UpdateHeroDto heroDto)
        {
            var originalhero = await GetByID(heroDto.Id);

            if (heroDto is null)
                throw new CustomArgumentException();

            heroDto.SpecializationId = originalhero.SpecializationId;
            heroDto.RaceId = originalhero.RaceId;

            var hero = _mapper.Map<Hero>(heroDto);
            await _heroRepo.UpdateAsync(hero);
        }

        public async Task<HeroViewDto> GetByID(Guid heroId)
        {
            var hero = await _heroRepo.GetByID(heroId);
            if (hero is null)
                throw new HeroNotFoundExeption("Герой с указанным идентификатором не найден");

            return _mapper.Map<HeroViewDto>(hero);
        }

        //public async Task<IEnumerable<SkillViewDto>> GetSkillsByHeroId(Guid heroId)
        //{
        //    IEnumerable<SkillViewDto> skills = await _skillService.GetByRaceId(heroId);
        //    skills = await _skillService.GetBySpecId(heroId);
        //    return skills;
        //}
    }
}
