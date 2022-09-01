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

        public AmmunitionService(IAmmunitionRepository ammunitionRepo,
                                 IMapper mapper)
        {
            _ammunitionRepo = ammunitionRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AmmunitionViewDto>> GetAll()
        {
            var ammunition = await _ammunitionRepo.GetAll();

            if (!ammunition.Any())
                return Enumerable.Empty<AmmunitionViewDto>();

            return _mapper.Map<IEnumerable<AmmunitionViewDto>>(ammunition);
        }

        public async Task Add(CreateAmmunitionDto ammunitionDto)
        {
            if (ammunitionDto is null)
                throw new CustomArgumentException("Введите данные");

            var ammunition = _mapper.Map<Ammunition>(ammunitionDto);
            await _ammunitionRepo.AddAsync(ammunition);
        }

        public async Task Delete(Guid ammunitionId)
        {
            await _ammunitionRepo.DeleteAsync(ammunitionId);
        }

        public async Task Update(Guid id, UpdateAmmunitionDto ammunitionDto)
        {
            var ammunition = await _ammunitionRepo.GetByID(id);
            if (ammunitionDto is null)
                throw new CustomArgumentException("Введите данные");

            ammunition.Name = ammunitionDto.Name;
            ammunition.RaceId = ammunitionDto.RaceId;
            ammunition.SpecializationId = ammunitionDto.SpecializationId;

            await _ammunitionRepo.UpdateAsync(ammunition);
        }

        public async Task<AmmunitionViewDto> GetByID(Guid ammunitionId)
        {
            var ammunition = await _ammunitionRepo.GetByID(ammunitionId);
            if (ammunition is null)
                throw new AmmunitionNotFoundExeption("Предмет с указанным идентификатором не найден");

            return _mapper.Map<AmmunitionViewDto>(ammunition);
        }
    }
}
