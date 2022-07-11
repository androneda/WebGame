using AutoMapper;
using System;
using System.Collections.Generic;
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
        public HeroService(IHeroRepository heroRepo, IMapper mapper)
        {
            _heroRepo = heroRepo;
            _mapper = mapper;
        }
        public async Task<ICollection<HeroViewDto>> GetAll()
        {
            var temp = await _heroRepo.GetAll();

            if (temp.Any())
            {
                ICollection<HeroViewDto> heroesViewDto = _mapper.Map<ICollection<HeroViewDto>>(temp);

                return heroesViewDto;
            }
            return null;

        }
        public async Task Insert(CreateHeroDto heroDto)
        {
            var hero = _mapper.Map<Hero>(heroDto);
            await _heroRepo.InsertAsync(hero);
        }

        public async Task Delete(Guid heroId)
        {
            await _heroRepo.DeleteAsync(heroId);
        }

        public async Task Update(UpdateHeroDto heroDto)
        {
            if (heroDto is null)
                throw new HeroNotFoundExeption("Герой с указанным идентификатором не найден");

            var hero = _mapper.Map<Hero>(heroDto);
            await _heroRepo.UpdateAsync(hero);

        }
        public async Task<HeroViewDto> GetByID(Guid heroId)
        {
            var temp = await _heroRepo.GetByID(heroId);
            if (temp is not null)
            {
                return _mapper.Map<HeroViewDto>(temp);
            }
            throw new HeroNotFoundExeption("Герой с указанным идентификатором не найден");
        }
    }
}
