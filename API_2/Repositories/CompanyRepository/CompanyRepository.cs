using API_2.Data;
using API_2.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_2.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(DataContext context) : base(context) { }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await _context.Companies.Include(comp => comp.Services).ToListAsync();
        }

        public async Task<List<Company>> GetAllCompanies()
        {
            return await _context.Companies.Include(comp => comp.Services).Include(comp => comp.CompanyProfile).ToListAsync();
        }

        public async Task<IEnumerable<Service>> GetAllServices(int id_company)
        {
            return await _context.Services.Where(service => service.CompanyId.Equals(id_company)).ToListAsync();
        }

        public async Task<Company> GetCompanyById(int id)
        {
            return await _context.Companies.Where(c => c.Id.Equals(id)).FirstOrDefaultAsync();
        }
    }
}
