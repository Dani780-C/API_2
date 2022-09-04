using API_2.Data;
using API_2.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_2.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(DataContext context) : base(context) { }

        public async Task<List<Client>> GetAllClientsWithData()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<List<Client>> GetAllClientsWithServices()
        {
            return await _context.Clients.Include(c => c.ClientServices).ThenInclude(s => s.Service).ToListAsync();
        }

        public async Task<Client> GetByName(string name)
        {
            return await _context.Clients.Where(c => c.FirstName.Equals(name)).FirstOrDefaultAsync();
        }

        public async Task<Client> GetClientByEmail(string email)
        {
            return await _context.Clients.Where(c => c.Email.Equals(email)).FirstOrDefaultAsync();
        }

        public async Task<Client> GetClientById(int id)
        {
            return await _context.Clients.Where(c => c.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<List<Client>> GetClientDataById(int id)
        {
            return await _context.Clients.Where(c => c.Id.Equals(id)).Include(c => c.ClientServices).ThenInclude(s => s.Service).ToListAsync();
        }
    }
}
