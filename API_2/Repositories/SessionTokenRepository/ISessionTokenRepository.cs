using API_2.Models.Entities;
using API_2.Repositories;

namespace API_2.Repositories
{
    public interface ISessionTokenRepository : IGenericRepository<SessionToken>
    {
        Task<SessionToken> GetByJti(string jti);
    }
}
