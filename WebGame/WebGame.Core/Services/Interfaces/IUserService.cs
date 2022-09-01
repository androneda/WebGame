using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebGame.Core.Model.User;

namespace WebGame.Core.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewDto>> GetAll();
        Task<UserViewDto> GetByID(Guid userId);
        Task Add(CreateUserDto userDto);
        Task Delete(Guid userId);
        Task Update(Guid id, UpdateUserDto userDto);
    }
}
