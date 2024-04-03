using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Generic;

namespace Leha.Infrastructure.Repositories.Products;

public interface IProductRepository : IGenericRepository<Product>
{
    public Task<List<Product?>> GetProductsListByCompanyId(int companyID);

}