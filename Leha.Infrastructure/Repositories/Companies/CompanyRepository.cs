using Leha.Data.Entities;
using Leha.Infrastructure.Context;
using Leha.Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Leha.Infrastructure.Repositories.Companies;

public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
{
    #region Fields
    private readonly DbSet<Company> _companies;
    #endregion

    #region Constructors
    public CompanyRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _companies = appDbContext.Set<Company>();
    }

    #endregion

    #region Handle Functions

    #endregion
}
