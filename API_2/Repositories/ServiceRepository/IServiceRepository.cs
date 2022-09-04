using API_2.Models.Entities;

namespace API_2.Repositories
{
    public interface IServiceRepository : IGenericRepository<Service>
    {
        Task<List<Service>> GetAllServices();
        Task<Service> GetServiceById(int id);
        Task<List<Service>> GetAllServicesByIdClient(int id_client);
    }
}
