using API_2.Data;
using API_2.Models.Entities;
using API_2.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API_2.Repositories
{
    public class SessionTokenRepository : GenericRepository<SessionToken>, ISessionTokenRepository
    {
        public SessionTokenRepository(DataContext context) : base(context) { }

        public async Task<SessionToken> GetByJti(string jti)
        {
            return await _context.SessionTokens.FirstOrDefaultAsync(t => t.Jti.Equals(jti));
        }
    }
}
