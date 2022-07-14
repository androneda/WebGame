using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGame.Common.Exeptions;
using WebGame.Core.Model.Ammunition;
using WebGame.Core.Services.Interfaces;
using WebGame.Database.Model;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Core.Services
{
    public class AmmunitionService : IAmmunitionService
    {
        private readonly IAmmunitionRepository _ammunitionRepo;
        private readonly IMapper _mapper;
        public AmmunitionService(IAmmunitionRepository ammunitionRepo, IMapper mapper)
        {
            _ammunitionRepo = ammunitionRepo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AmmunitionViewDto>> GetAll()
        {
            var temp = await _ammunitionRepo.GetAll();

            if (temp.Any())
                return _mapper.Map<IEnumerable<AmmunitionViewDto>>(temp);

            return Enumerable.Empty<AmmunitionViewDto>();
        }

        public async Task Add(CreateAmmunitionDto heroDto)
        {
            if (heroDto is null)
                throw new AmmunitionNotFoundExeption("Предмет с указанным идентификатором не найден");

            var hero = _mapper.Map<Ammunition>(heroDto);
            await _ammunitionRepo.AddAsync(hero);
        }

        public async Task Delete(Guid heroId)
        {
            await _ammunitionRepo.DeleteAsync(heroId);
        }

        public async Task Update(UpdateAmmunitionDto heroDto)
        {
            if (heroDto is null)
                throw new AmmunitionNotFoundExeption("Предмет с указанным идентификатором не найден");

            var hero = _mapper.Map<Ammunition>(heroDto);
            await _ammunitionRepo.UpdateAsync(hero);
        }

        public async Task<AmmunitionViewDto> GetByID(Guid heroId)
        {
            var temp = await _ammunitionRepo.GetByID(heroId);
            if (temp is null)
                throw new AmmunitionNotFoundExeption("Предмет с указанным идентификатором не найден");

            return _mapper.Map<AmmunitionViewDto>(temp);
        }
    }
}
