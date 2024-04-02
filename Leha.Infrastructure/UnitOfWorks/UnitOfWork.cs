using Leha.Infrastructure.Context;
using Leha.Infrastructure.Repositories.Companies;
using Leha.Infrastructure.Repositories.HomeImages;

namespace Leha.Infrastructure.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    public AppDbContext AppDbContext { get; }
    public ICompanyRepository CompanyRepository { get; }
    public IHomeImageRepository HomeImageRepository { get; }


    public UnitOfWork(
        AppDbContext appDbContext,
        ICompanyRepository companyRepository,
        IHomeImageRepository homeImageRepository)
    {
        AppDbContext = appDbContext;
        CompanyRepository = companyRepository;
        HomeImageRepository = homeImageRepository;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await AppDbContext.SaveChangesAsync();
    }

}
