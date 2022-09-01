using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGame.Common.Exeptions;
using WebGame.Core.Model.Races;
using WebGame.Core.Services.Interfaces;
using WebGame.Database.Model;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Core.Services
{
    public class RaceService : IRaceService
    {
        private readonly IRaceRepository _raceRepo;
        private readonly ISkillService _skillService;
        private readonly IMapper _mapper;

        public RaceService(IRaceRepository raceRepo,
                           ISkillService skillService,
                           IMapper mapper)
        {
            _raceRepo = raceRepo;
            _skillService = skillService;
            _mapper = mapper;
        }

        public async Task Add(CreateRaceDto raceDto)
        {
            if (raceDto is null)
                throw new ArgumentException("Введите данные");

            var race = _mapper.Map<Race>(raceDto);
            await _raceRepo.AddAsync(race);
        }

        public async Task Delete(Guid raceId)
        {
            await _raceRepo.DeleteAsync(raceId);
        }

        public async Task<IEnumerable<RaceViewDto>> GetAllAsync()
        {
            var races = await _raceRepo.GetAll();

            if (!races.Any())
                return Enumerable.Empty<RaceViewDto>();

            var racesDto = _mapper.Map<IEnumerable<RaceViewDto>>(races);

            foreach (var race in racesDto)
                race.Skills = await _skillService.GetByRaceId(race.Id);

            return racesDto;
        }

        public async Task<RaceViewDto> GetById(Guid raceId)
        {
            var race = await _raceRepo.GetByID(raceId);

            if (race is null)
                throw new RaceNotFoundExeption("Расса не найдена");

            var userDto = _mapper.Map<RaceViewDto>(race);
            userDto.Skills = await _skillService.GetByRaceId(raceId);
            return userDto;
        }

        public async Task Update(Guid id, UpdateRaceDto raceDto)
        {
            var race = await _raceRepo.GetByID(id);

            if (raceDto is null)
                throw new CustomArgumentException("Введите данные");

            race.Name = raceDto.Name;
            race.Description = raceDto.Description;

            await _raceRepo.UpdateAsync(race);
        }
    }
}
