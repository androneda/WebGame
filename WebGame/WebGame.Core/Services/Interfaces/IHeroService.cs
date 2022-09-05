using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using WebGame.Core.Model.Hero;

namespace WebGame.Core.Services.Interfaces
{
    public interface IHeroService
    {
        Task<IEnumerable<HeroViewDto>> GetAll();
        Task<HeroViewDto> GetByID(Guid heroId);
        Task Add(CreateHeroDto heroDto);
        Task Delete(Guid heroId);
        Task Update(Guid Id, UpdateHeroDto heroDto);
    }
}
