using API_2.Data;
using API_2.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_2.Repositories
{
    public class CompanyProfileRepository : GenericRepository<CompanyProfile>, ICompanyProfileRepository
    {
        public CompanyProfileRepository(DataContext context) : base(context) { }

        public async Task<CompanyProfile> GetByCompanyId(int companyId)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.CompanyProfiles.Where(companyprofile => companyprofile.CompanyId.Equals(companyId)).FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
