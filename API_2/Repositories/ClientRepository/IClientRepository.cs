using API_2.Models.Entities;
using API_2.Repositories;

namespace API_2.Repositories
{
    public interface IClientRepository : IGenericRepository<Client>
    {
        Task<Client> GetByName(string name);
        Task<List<Client>> GetAllClientsWithServices();
        Task<List<Client>> GetAllClientsWithData();
        Task<List<Client>> GetClientDataById(int id);
        Task<Client> GetClientByEmail(string email);
        Task<Client> GetClientById(int id);
    }
}
