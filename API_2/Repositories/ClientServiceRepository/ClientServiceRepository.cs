using API_2.Data;
using API_2.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_2.Repositories
{
    public class ClientServiceRepository : GenericRepository<ClientService>, IClientServiceRepository
    {
        public ClientServiceRepository(DataContext context) : base(context) { }
    }
}
