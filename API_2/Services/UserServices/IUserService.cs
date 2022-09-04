using API_2.Models.Entities;
using API_2.Models.Entities.DTOs;

namespace API_2.Services.UserServices
{
    public interface IUserService
    {
        Task<bool> RegisteredUserAsync(RegisterUserDTO dto);
        Task<string> LoginUser(LoginUserDTO dto);
    }
}
