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
    public IQueryable<HomeImage?> GetAllByCompanyID(int id)
    {
        return _homeImages.Where(x => x.CompanyID == id)
            .AsNoTracking()
            .AsQueryable();
    }
    #endregion
}
