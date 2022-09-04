using API_2.Models.Entities;
using API_2.Repositories;

namespace API_2.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    { 
        Task<List<User>> GetAllUsers();
        Task<User> GetUserByEmail(string email);
        Task<User> GetByIdWithRoles(int id);
    }
}
