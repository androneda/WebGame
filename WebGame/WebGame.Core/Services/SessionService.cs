using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGame.Common.Exeptions;
using WebGame.Core.Model.Session;
using WebGame.Core.Services.Interfaces;
using WebGame.Database.Model;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Core.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepo;
        private readonly IMapper _mapper;
        public SessionService(ISessionRepository sessionRepo,
                           IMapper mapper)
        {
            _sessionRepo = sessionRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SessionViewDto>> GetAll()
        {
            var sessions = await _sessionRepo.GetAll();

            if (!sessions.Any())
                return Enumerable.Empty<SessionViewDto>();

            return _mapper.Map<IEnumerable<SessionViewDto>>(sessions);
        }

        public async Task Update(Guid id, bool isActive)
        {
            var session = await _sessionRepo.GetByID(id);

            if (session is null)
                throw new SessionNotFoundExeption("Сессия с указанным идентификатором не найдена");

            session.IsActive = isActive;

            await _sessionRepo.UpdateAsync(session);
        }

        public async Task Add(Session session)
        {
            if (session is null)
                throw new ArgumentException("Приятного дня, Сань)");

            await _sessionRepo.AddAsync(session);
        }

        public async Task Delete(Guid sessionId)
        {
            await _sessionRepo.DeleteAsync(sessionId);
        }

        public async Task<SessionViewDto> GetByID(Guid sessionId)
        {
            var session = await _sessionRepo.GetByID(sessionId);

            if (session is null)
                throw new SessionNotFoundExeption("Сессия с указанным идентификатором не найдена");

            return _mapper.Map<SessionViewDto>(session);
        }

        public async Task DeactivateSessionAsync(Guid userId)
        {
            var sessions = await _sessionRepo.GetSessionByUser(userId);

            if (sessions is null)
                throw new SessionNotFoundExeption("Сессии не найдены");

            foreach (var session in sessions)
                await Update(session.Id, false);
        }
    }
}
