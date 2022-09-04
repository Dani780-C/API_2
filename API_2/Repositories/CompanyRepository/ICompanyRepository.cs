using API_2.Models.Entities;

namespace API_2.Repositories
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task<IEnumerable<Company>> GetAllAsync();
        Task<IEnumerable<Service>> GetAllServices(int id_company);
        Task<List<Company>> GetAllCompanies();
        Task<Company> GetCompanyById(int id);
    }
}
