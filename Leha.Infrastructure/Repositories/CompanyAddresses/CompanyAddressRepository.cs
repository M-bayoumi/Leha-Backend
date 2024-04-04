using Leha.Data.Entities;
using Leha.Infrastructure.Context;
using Leha.Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Leha.Infrastructure.Repositories.CompanyAddresses;


public class CompanyAddressRepository : GenericRepository<CompanyAddress>, ICompanyAddressRepository
{
    #region Fields
    private readonly DbSet<CompanyAddress> _companyAddresses;
    #endregion

    #region Constructors
    public CompanyAddressRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _companyAddresses = appDbContext.Set<CompanyAddress>();
    }

    #endregion

    #region Handle Functions

    public IQueryable<CompanyAddress?> GetCompanyAddressesListByCompanyId(int companyID)
    {
        return _companyAddresses.Where(x => x.CompanyID == companyID).AsNoTracking().AsQueryable();
    }

    #endregion
}
