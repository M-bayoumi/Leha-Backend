using Leha.Data.Entities;

namespace Leha.Manager.Managers.Products;

public interface IProductManager
{
    public IQueryable<Product?> GetProductsListAsync();
    public IQueryable<Product?> GetProductsListByCompanyId(int id);
    public Task<Product?> GetProductByIDAsync(int id);
    public Task<bool> AddProductAsync(Product pm);
    public Task<bool> UpdateProductAsync(Product pm);
    public Task<bool> DeleteProductAsync(Product pm);
}

