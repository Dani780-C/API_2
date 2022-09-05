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
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
            return await _context.Clients.Include(c => c.ClientServices).ThenInclude(s => s.Service).ToListAsync();
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
        }

        public async Task<Client> GetByName(string name)
        {
#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return await _context.Clients.Where(c => c.FirstName.Equals(name)).FirstOrDefaultAsync();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Client> GetClientByEmail(string email)
        {
#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return await _context.Clients.Where(c => c.Email.Equals(email)).FirstOrDefaultAsync();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Client> GetClientById(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Clients.Where(c => c.Id.Equals(id)).FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<List<Client>> GetClientDataById(int id)
        {
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
            return await _context.Clients.Where(c => c.Id.Equals(id)).Include(c => c.ClientServices).ThenInclude(s => s.Service).ToListAsync();
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
        }
    }
}
