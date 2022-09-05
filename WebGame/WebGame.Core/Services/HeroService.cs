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

        public string GetHeroesSql()
        {
            var cs = "User ID=postgres; Password=postgres;Host=localhost;Port=5432;Database=WebGameBD;Pooling=true";

            using var con = new NpgsqlConnection(cs);
            con.Open();
            DataTable dataTable = new DataTable();
            using var cmd = new NpgsqlCommand();

            cmd.Connection = con;

            cmd.CommandText = $"SELECT * FROM public.\"Heroes\"" /*WHERE public.\"Heroes\".\"Id\" = @id"*/;

            //cmd.Parameters.AddWithValue("@id", heroId);

            cmd.Prepare();

            DataSet _ds = new DataSet();
            DataTable _dt = new DataTable();

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);

            da.Fill(_ds);

            _dt = _ds.Tables[0];
            string result="";
            foreach (DataRow dr in _dt.Rows)
            {
                foreach (var columnValue in dr.ItemArray)
                {
                    result += columnValue.ToString() + " \n ";
                }
            }
            return result;

            //var reader = cmd.ExecuteReader();
            //string result;
            //if (reader.HasRows)
            //{
            //    while (reader.Read())
            //    {
            //        foreach (var column in reader.)
            //        {

            //        }

            //        //result += reader.GetGuid(0).ToString() + " " + reader.GetString(1);
            //    }
            //}
            //return result;
        }
    }
}
