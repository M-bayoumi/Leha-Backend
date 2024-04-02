using Leha.Infrastructure.Repositories.Companies;
using Leha.Infrastructure.Repositories.HomeImages;

namespace Leha.Infrastructure.UnitOfWorks;

public interface IUnitOfWork
{
    public ICompanyRepository CompanyRepository { get; }
    public IHomeImageRepository HomeImageRepository { get; }

    Task<int> SaveChangesAsync();
}
