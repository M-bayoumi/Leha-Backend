using Leha.Data.Entities;

namespace Leha.Manager.Managers.Products;

public interface IProductManager
{
    public IQueryable<Product?> GetAll();
    public IQueryable<Product?> GetAllByCompanyId(int id);
    public Task<Product?> GetByIdAsync(int id);
    public Task<bool> AddAsync(Product pm);
    public Task<bool> UpdateAsync(Product pm);
    public Task<bool> DeleteAsync(Product pm);
}

