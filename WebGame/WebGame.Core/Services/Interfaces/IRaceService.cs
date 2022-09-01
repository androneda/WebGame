using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebGame.Core.Model.Races;

namespace WebGame.Core.Services.Interfaces
{
    public interface IRaceService
    {
        Task<IEnumerable<RaceViewDto>> GetAllAsync();
        Task<RaceViewDto> GetById(Guid raceId);
        Task Add(CreateRaceDto raceDto);
        Task Delete(Guid raceId);
        Task Update(Guid id, UpdateRaceDto raceDto);
    }
}
