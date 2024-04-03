using Leha.Data.Entities;
using Leha.Infrastructure.Context;
using Leha.Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Leha.Infrastructure.Repositories.HomeImages;

public class HomeImageRepository : GenericRepository<HomeImage>, IHomeImageRepository
{
    #region Fields
    private readonly DbSet<HomeImage> _homeImages;
    #endregion

    #region Constructors
    public HomeImageRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _homeImages = appDbContext.Set<HomeImage>();
    }

    #endregion

    #region Handle Functions

    public async Task<List<HomeImage?>> GetHomeImagesListByCompanyId(int companyID)
    {
        return await _homeImages.Where(x => x.CompanyID == companyID).ToListAsync();
    }

    #endregion
}
