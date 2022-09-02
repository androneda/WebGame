using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGame.Common.Exeptions;
using WebGame.Core.Model.Role;
using WebGame.Core.Model.User;
using WebGame.Core.Services.Interfaces;
using WebGame.Database.Model;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly ISessionService _sessionService;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;

        public UserService(IUserRepository userRepo,
                           IMapper mapper,
                           ISessionService sessionService,
                           IPasswordService passwordService)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _sessionService = sessionService;
            _passwordService = passwordService;
        }

        public async Task<IEnumerable<UserViewDto>> GetAll()
        {
            var users = await _userRepo.GetAll();

            if (!users.Any())
                return Enumerable.Empty<UserViewDto>();

            return _mapper.Map<IEnumerable<UserViewDto>>(users);
        }

        public async Task Add(CreateUserDto userDto)
        {
            if (userDto is null)
                throw new CustomArgumentException("Неудалось добавить пользователя");

            var user = _mapper.Map<User>(userDto);
            user.Password = _passwordService.GenerateSaltedHash(userDto.Password);
            await _userRepo.AddAsync(user);
        }

        public async Task Delete(Guid userId)
        {
            await _userRepo.DeleteAsync(userId);
        }

        public async Task Update(Guid id, UpdateUserDto userDto)
        {
            if (userDto is null)
                throw new CustomArgumentException("Введите Данные");

            var user = await _userRepo.GetByID(id);

            if (user is null)
                throw new UserNotFoundExeption("Пользователь с указанным идентификатором не найден");

            user.Login = userDto.Login;
            user.Password = userDto.Password;
            user.RoleId = userDto.RoleId;

            await _sessionService.DeactivateSessionAsync(id);

            await _userRepo.UpdateAsync(user);
        }

        public async Task<UserViewDto> GetByID(Guid userId)
        {
            var userModel = await _userRepo.GetIdentity(userId);
            if (userModel is null)
                throw new UserNotFoundExeption("Пользователь с указанным идентификатором не найден");

            var userDto = _mapper.Map<UserViewDto>(userModel);
            userDto.Role = _mapper.Map<RoleViewDto>(userModel.Role);
            return userDto;
        }

    }
}
