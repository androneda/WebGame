using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGame.Common.Exeptions;
using WebGame.Core.Model.Hero;
using WebGame.Core.Model.Skills;
using WebGame.Core.Model.UserSession;
using WebGame.Core.Services.Interfaces;
using WebGame.Database.Model;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Core.Services
{
    public class SessionSercvice : ISessionService
    {
        private readonly ISessionRepository _sessionRepo;
        private readonly IMapper _mapper;
        public SessionSercvice(ISessionRepository sessionRepo,
                           IMapper mapper)
        {
            _sessionRepo = sessionRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserSessionViewDto>> GetAll()
        {
            var temp = await _sessionRepo.GetAll();

            if (!temp.Any())
                return Enumerable.Empty<UserSessionViewDto>();

            return _mapper.Map<IEnumerable<UserSessionViewDto>>(temp);
        }

        public async Task Update(Guid id, bool isActive)
        {
            var user = await _sessionRepo.GetByID(id);

            user.IsActive = isActive;

            await _sessionRepo.UpdateAsync(user);
        }

        public async Task Add(Session session)
        {
            if (session is null)
                throw new ArgumentException("Сессия с указанным идентификатором не найдена");

            await _sessionRepo.AddAsync(session);
        }

        public async Task Delete(Guid sessionId)
        {
            await _sessionRepo.DeleteAsync(sessionId);
        }

        public async Task<UserSessionViewDto> GetByID(Guid sessionId)
        {
            var temp = await _sessionRepo.GetByID(sessionId);
            if (temp is null)
                throw new SessionNotFoundExeption("Сессия с указанным идентификатором не найдена");

            return _mapper.Map<UserSessionViewDto>(temp);
        }

        public async Task DeactivateSessionAsync(Guid userId)
        {
           var sessions = _sessionRepo.GetSessionByUser(userId);

            if (sessions is null)
                throw new SessionNotFoundExeption("Сессии не найдены");

            foreach (var session in sessions)
                await Update(session.Id, false);
        }
    }
}
