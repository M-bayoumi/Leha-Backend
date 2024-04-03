using Leha.Data.Entities;

namespace Leha.Manager.Managers.Products;

public interface IProductManager
{
    public Task<List<Product?>> GetProductsListAsync();
    public Task<List<Product?>> GetProductsListByCompanyId(int companyID);
    public Task<Product?> GetProductByIDAsync(int productID);
    public Task<bool> AddProductAsync(Product product);
    public Task<bool> UpdateProductAsync(Product product);
    public Task<bool> DeleteProductAsync(Product product);
}

