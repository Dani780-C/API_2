using API_2.Data;
using API_2.Models.Entities;
using API_2.Models.Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Services.Where(s => s.Id.Equals(id)).FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<List<Service>> GetAllServicesByIdClient(int id_client)
        {
            return await _context.Services.FromSqlRaw("Select s.* from Services s, ClientServices cs, Clients c where s.Id = cs.ServiceId and cs.ClientId = c.Id and c.Id = " + id_client.ToString() + ";").ToListAsync();
        }

        public async Task<List<ServiceTypeDTO>> GetJoined()
        {
            return await _context.Services.Join(_context.Companies, service => service.CompanyId, comp => comp.Id, (service, comp) => new ServiceTypeDTO(service.ServiceName, comp.Type)).ToListAsync();
        }
    }
}
