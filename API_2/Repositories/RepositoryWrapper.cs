using API_2.Data;

namespace API_2.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly DataContext _context;
        private IUserRepository _user;
        private IClientRepository _client;
        private ISessionTokenRepository _sessionToken;
        private ICompanyRepository _company;
        private IServiceRepository _service;
        private IClientServiceRepository _clientService;
        private ICompanyProfileRepository _companyProfile;
        public RepositoryWrapper(DataContext context)
        {
            _context = context;
        }

        public IServiceRepository Service
        {
            get
            {
                if (_service == null) _service = new ServiceRepository(_context);
                return _service;
            }
        }

        public ICompanyProfileRepository CompanyProfile
        {
            get
            {
                if (_companyProfile == null) _companyProfile = new CompanyProfileRepository(_context);
                return _companyProfile;
            }
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null) _user = new UserRepository(_context);
                return _user;
            }
        }

        public IClientServiceRepository ClientService
        {
            get
            {
                if (_clientService == null) _clientService = new ClientServiceRepository(_context);
                return _clientService;
            }
        }


        public ICompanyRepository Company
        {
            get
            {
                if (_company == null) _company = new CompanyRepository(_context);
                return _company;
            }
        }

        public IClientRepository Client
        {
            get
            {
                if (_client == null) _client = new ClientRepository(_context);
                return _client;
            }
        }

        public ISessionTokenRepository SessionToken
        {
            get
            {
                if (_sessionToken == null) _sessionToken = new SessionTokenRepository(_context);
                return _sessionToken;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
