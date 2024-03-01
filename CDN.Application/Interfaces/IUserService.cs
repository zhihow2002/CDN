using System.Collections.Generic;
using System.Threading.Tasks;
using CDN.Application.DTOs;

namespace CDN.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(int id);
        Task<UserDto> CreateUserAsync(UserDto userDto);
        Task UpdateUserAsync(int id, UserDto userDto);
        Task DeleteUserAsync(int id);
    }
}
