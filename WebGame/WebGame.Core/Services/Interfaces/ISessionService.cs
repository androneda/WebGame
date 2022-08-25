using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebGame.Core.Model.Session;
using WebGame.Database.Model;

namespace WebGame.Core.Services.Interfaces
{
    public interface ISessionService
    {
        Task<IEnumerable<SessionViewDto>> GetAll();
        Task Add(Session session);
        Task Update(Guid id, bool isActive);
        Task Delete(Guid sessionId);
        Task<SessionViewDto> GetByID(Guid sessionId);
        Task DeactivateSessionAsync(Guid userId);
    }
}