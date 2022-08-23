using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Core.Model.User;
using WebGame.Database.Model;

namespace WebGame.Core.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewDto>> GetAll();
        Task<UserViewDto> GetByID(Guid userId);
        Task Add(CreateUserDto userDto);
        Task Delete(Guid userId);
        Task Update(UpdateUserDto userDto);
        Task<User> GetModelByID(Guid userId);
    }
}
