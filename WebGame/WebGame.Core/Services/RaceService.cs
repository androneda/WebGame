﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Core.Services.Interfaces;
using WebGame.Database.Model;
using WebGame.Database.Repositories.Interfaces;
using WebGame.Core.Model.Races;
using WebGame.Common.Exeptions;

namespace WebGame.Core.Services
{
    public class RaceService:IRaceService
    {
        private readonly IRaceRepository _raceRepo;
        private readonly ISkillService _skillService;
        private readonly IMapper _mapper;

        public RaceService(IRaceRepository raceRepo, ISkillService skillService, IMapper mapper)
        {
            _raceRepo = raceRepo;
            _skillService = skillService;
            _mapper = mapper;
        }

        public async Task Add(CreateRaceDto raceDto)
        {
            if (raceDto is null)
                throw new RaceNotFoundExeption("Расса не найдена");

            var race = _mapper.Map<Race>(raceDto);
            await _raceRepo.AddAsync(race);
        }

        public async Task Delete(Guid raceId)
        {
            await _raceRepo.DeleteAsync(raceId);
        }

        public async Task<IEnumerable<RaceViewDto>> GetAll()
        {
            var temp = await _raceRepo.GetAll();

            if (!temp.Any())
                return Enumerable.Empty<RaceViewDto>();

            foreach (var item in temp)
                item.Skills = await _skillService.GetByRaceId(item.Id);

            return _mapper.Map<IEnumerable<RaceViewDto>>(temp);

        }

        public async Task<RaceViewDto> GetById(Guid raceId)
        {
            var temp = await _raceRepo.GetByID(raceId);

            if (temp is null)
                throw new RaceNotFoundExeption("Расса не найдена");
            temp.Skills = await _skillService.GetBySpecId(raceId);
            return _mapper.Map<RaceViewDto>(temp);
        }

        public async Task Update(UpdateRaceDto raceDto)
        {
            if (raceDto is null)
                throw new RaceNotFoundExeption("Расса не найдена");

            var race = _mapper.Map<Race>(raceDto);
            await _raceRepo.UpdateAsync(race);
        }
    }
}
