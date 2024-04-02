using Leha.Infrastructure.Context;
using Leha.Infrastructure.Repositories.Companies;
using Leha.Infrastructure.Repositories.HomeImages;
using Leha.Infrastructure.Repositories.Services;

namespace Leha.Infrastructure.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    public AppDbContext AppDbContext { get; }
    public ICompanyRepository CompanyRepository { get; }
    public IHomeImageRepository HomeImageRepository { get; }
    public IServiceRepository ServiceRepository { get; }


    public UnitOfWork(
        AppDbContext appDbContext,
        ICompanyRepository companyRepository,
        IHomeImageRepository homeImageRepository,
        IServiceRepository serviceRepository)
    {
        AppDbContext = appDbContext;
        CompanyRepository = companyRepository;
        HomeImageRepository = homeImageRepository;
        ServiceRepository = serviceRepository;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await AppDbContext.SaveChangesAsync();
    }

}
