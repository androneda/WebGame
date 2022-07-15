using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Database.Repositories.Interfaces;
using WebGame.Core.Model.Races;

namespace WebGame.Core.Services.Interfaces
{
    public interface IRaceService
    {
        Task<IEnumerable<RaceViewDto>> GetAll();
        Task<RaceViewDto> GetById(Guid raceId);
        Task Add(CreateRaceDto raceDto);
        Task Delete(Guid raceId);
        Task Update(UpdateRaceDto raceDto);
    }
}
