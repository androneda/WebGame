using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<ICollection<Hero>> GetAll() => await _heroRepo.GetAll();
        public async Task Insert(CreateHeroDto heroDto)
        {
            var hero = _mapper.Map<Hero>(heroDto);
            hero.Id = Guid.NewGuid();
            await _heroRepo.InsertAsync(hero);
        }

        public async Task Delete(Guid heroId)
        {
            await _heroRepo.DeleteAsync(heroId);
        }

        public async Task Update(UpdateHeroDto heroDto)
        {
            if (heroDto != null)
            {
                var hero = _mapper.Map<Hero>(heroDto);
                await _heroRepo.UpdateAsync(hero);
            }
        }
        public async Task<Hero> GetByID(Guid heroId)
        {
            return await _heroRepo.GetByID(heroId);
        }
    }
}
