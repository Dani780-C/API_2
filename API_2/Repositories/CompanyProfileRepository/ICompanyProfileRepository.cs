using API_2.Models.Entities;

namespace API_2.Repositories
{
    public interface ICompanyProfileRepository : IGenericRepository<CompanyProfile>
    {
        Task<CompanyProfile> GetByCompanyId(int companyId);
    }
}
