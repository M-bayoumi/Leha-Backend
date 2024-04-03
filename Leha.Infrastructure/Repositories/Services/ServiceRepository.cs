using Leha.Data.Entities;
using Leha.Infrastructure.Context;
using Leha.Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Leha.Infrastructure.Repositories.Services;

public class ServiceRepository : GenericRepository<Service>, IServiceRepository
{
    #region Fields
    private readonly DbSet<Service> _services;
    #endregion

    #region Constructors
    public ServiceRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _services = appDbContext.Set<Service>();
    }

    #endregion

    #region Handle Functions

    public async Task<List<Service?>> GetServicesListByCompanyId(int companyID)
    {
        return await _services.Where(x => x.CompanyID == companyID).ToListAsync();
    }

    #endregion
}
