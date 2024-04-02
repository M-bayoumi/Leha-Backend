using Leha.Infrastructure.Repositories.Companies;
using Leha.Infrastructure.Repositories.HomeImages;
using Leha.Infrastructure.Repositories.Services;

namespace Leha.Infrastructure.UnitOfWorks;

public interface IUnitOfWork
{
    public ICompanyRepository CompanyRepository { get; }
    public IHomeImageRepository HomeImageRepository { get; }
    public IServiceRepository ServiceRepository { get; }

    Task<int> SaveChangesAsync();
}
