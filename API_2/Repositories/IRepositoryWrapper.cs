namespace API_2.Repositories
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IClientRepository Client { get; }
        ISessionTokenRepository SessionToken { get; }
        ICompanyRepository Company { get; }
        IServiceRepository Service { get; }
        IClientServiceRepository ClientService { get; }
        ICompanyProfileRepository CompanyProfile { get; }
        Task SaveAsync();
    }
}
