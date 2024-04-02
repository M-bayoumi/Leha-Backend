using Leha.Data.Entities;
using Leha.Infrastructure.Context;
using Leha.Infrastructure.Repositories.Companies;
using Leha.Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Leha.Infrastructure.Repositories.Services;

public class ServiceRepository : GenericRepository<Company>, ICompanyRepository
{
    #region Fields
    private readonly DbSet<Company> _companies;
    #endregion

    #region Constructors
    public ServiceRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _companies = appDbContext.Set<Company>();
    }

    #endregion

    #region Handle Functions

    #endregion
}
