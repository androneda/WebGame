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
    public class UserSessionSercvice : IUserSessionService
    {
        private readonly IUserSessionRepository _sessionRepo;
        private readonly IMapper _mapper;
        public UserSessionSercvice(IUserSessionRepository sessionRepo,
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

        public async Task Add(UserSession session)
        {
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
                throw new UserSessionNotFoundExeption("Сессия с указанным идентификатором не найдена");

            return _mapper.Map<UserSessionViewDto>(temp);
        }
    }
}
