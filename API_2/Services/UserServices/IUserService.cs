using API_2.Models.Entities;
using API_2.Models.Entities.DTOs;

namespace API_2.Services.UserServices
{
    public interface IUserService
    {
        Task<bool> RegisteredUserClientAsync(RegisterUserDTO dto);
        Task<bool> RegisteredUserCompanyAsync(RegisterUserDTO dto);
        Task<string> LoginUser(LoginUserDTO dto);
    }
}
