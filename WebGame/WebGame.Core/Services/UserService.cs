using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGame.Common.Exeptions;
using WebGame.Core.Model.User;
using WebGame.Core.Model.Skills;
using WebGame.Core.Services.Interfaces;
using WebGame.Database.Model;
using WebGame.Database.Repositories.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using WebGame.Common;
using Microsoft.IdentityModel.Tokens;

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

        public async Task<string> Token(string username, string password)
        {
            var identity = await _userRepo.GetIdentity(username, password);
            if (identity is null)
                throw new UserNotFoundExeption("Invalid username or password.");

            var now = DateTime.Now;

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            //var response = new
            //{
            //    access_token = encodedJwt,
            //    username = identity.Name
            //};

            return encodedJwt;
        }
    }
}
