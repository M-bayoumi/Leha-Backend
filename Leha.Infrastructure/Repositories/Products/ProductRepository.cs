using Leha.Data.Entities;
using Leha.Infrastructure.Context;
using Leha.Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Leha.Infrastructure.Repositories.Products;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    #region Fields
    private readonly DbSet<Product> _products;
    #endregion

    #region Constructors
    public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _products = appDbContext.Set<Product>();
    }


    #endregion

    #region Handle Functions
    public IQueryable<Product?> GetProductsListByCompanyId(int id)
    {
        return _products.Where(x => x.CompanyID == id).AsNoTracking().AsQueryable();
    }

    #endregion
}
