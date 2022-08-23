using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebGame.Common.Exeptions;
using WebGame.Core.Model.User;
using WebGame.Core.Services.Interfaces;
using WebGame.Database.Model;
using WebGame.Database.Repositories.Interfaces;

namespace WebGame.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepo,
                           IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserViewDto>> GetAll()
        {
            var temp = await _userRepo.GetAll();

            if (!temp.Any())
                return Enumerable.Empty<UserViewDto>();

            return _mapper.Map<IEnumerable<UserViewDto>>(temp);
        }

        public async Task Add(CreateUserDto userDto)
        {
            if (userDto is null)
                throw new UserNotFoundExeption("Неудалось добавить пользователя");

            var user = _mapper.Map<User>(userDto);
            await _userRepo.AddAsync(user);
        }

        public async Task Delete(Guid userId)
        {
            await _userRepo.DeleteAsync(userId);
        }

        public async Task Update(UpdateUserDto userDto)
        {

            var user = _mapper.Map<User>(userDto);
            await _userRepo.UpdateAsync(user);
        }

        public async Task<UserViewDto> GetByID(Guid userId)
        {
            var temp = await _userRepo.GetByID(userId);
            if (temp is null)
                throw new UserNotFoundExeption("Пользователь с указанным идентификатором не найден");

            return _mapper.Map<UserViewDto>(temp);
        }

        public async Task<User> GetModelByID(Guid userId)
        {
            var user = await _userRepo.GetIdentity(userId);
            if (user is null)
                throw new UserNotFoundExeption("Пользователь с указанным идентификатором не найден");

            return user;
        }


    }
}
