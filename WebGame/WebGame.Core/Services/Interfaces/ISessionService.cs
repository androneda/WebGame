using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebGame.Core.Model.UserSession;
using WebGame.Database.Model;

namespace WebGame.Core.Services.Interfaces
{
    public interface ISessionService
    {
        Task<IEnumerable<UserSessionViewDto>> GetAll();
        Task Add(Session session);
        Task Delete(Guid sessionId);
        Task<UserSessionViewDto> GetByID(Guid sessionId);
    }
}