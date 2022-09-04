using API_2.Data;
using API_2.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_2.Repositories
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        public ServiceRepository(DataContext context) : base(context) { }

        public async Task<List<Service>> GetAllServices()
        {
            return await _context.Services.Include(s => s.Company).ToListAsync();
        }

        public async Task<Service> GetServiceById(int id)
        {
            return await _context.Services.Where(s => s.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<List<Service>> GetAllServicesByIdClient(int id_client)
        {
            return await _context.Services.FromSqlRaw("Select s.* from Services s, ClientServices cs, Clients c where s.Id = cs.ServiceId and cs.ClientId = c.Id and c.Id = " + id_client.ToString() + ";").ToListAsync();
        }
    }
}
