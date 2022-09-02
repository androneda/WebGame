using AutoMapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebGame.Common.Exeptions;
using WebGame.Core.Model.Hero;
using WebGame.Core.Services.Interfaces;
using WebGame.Database.Model;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Core.Services
{
    public class HeroService : IHeroService
    {
        private readonly IHeroRepository _heroRepo;
        private readonly IMapper _mapper;
        public HeroService(IHeroRepository heroRepo,
                           IMapper mapper,
                           ISkillService skillService)
        {
            _heroRepo = heroRepo;
            _mapper = mapper;
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
            if (heroDto is null)
                throw new CustomArgumentException();

            var hero = await _heroRepo.GetByID(id);

            if (hero is null)
                throw new HeroNotFoundExeption("Герой с указанным идентификатором не найден");

            hero.SpecializationId = heroDto.SpecializationId;
            hero.RaceId = heroDto.RaceId;

            await _heroRepo.UpdateAsync(hero);
        }

        public async Task<HeroViewDto> GetByID(Guid heroId)
        {
            var hero = await _heroRepo.GetByID(heroId);
            if (hero is null)
                throw new HeroNotFoundExeption("Герой с указанным идентификатором не найден");

            return _mapper.Map<HeroViewDto>(hero);
        }

        public async Task<string> GetAllSql()
        {
            var dataSet = await _heroRepo.GetAllSql();

            var dataTable = dataSet.Tables[0];

            if (dataTable is null)
                throw new NpgsqlException("Неудалось найти таблицу");

            string result = "";

            foreach (DataRow dr in dataTable.Rows)
            {
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    result += dataTable.Columns[i].ToString() + ": " + dr.ItemArray[i].ToString() + "\n";
                }

                result += "\n";
            }

            return result;
        }
    }
}
