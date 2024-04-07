using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Products;
using Leha.Infrastructure.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace Leha.Manager.Managers.Products;

public class ProductManager : IProductManager
{
    #region Fields
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductRepository _productRepository;
    #endregion

    #region Constructors
    public ProductManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _productRepository = unitOfWork.ProductRepository;
    }
    #endregion

    #region Handle Functions   
    public IQueryable<Product?> GetProductsListAsync()
    {
        return _productRepository.GetTableNoTracking().AsQueryable();
    }

    public IQueryable<Product?> GetProductsListByCompanyId(int id)
    {
        return _productRepository.GetProductsListByCompanyId(id).AsQueryable();
    }
    public async Task<Product?> GetProductByIDAsync(int id)
    {
        return await _productRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.ID == id);
    }

    public async Task<bool> AddProductAsync(Product pm)
    {
        return await _productRepository.AddAsync(pm);
    }
    public async Task<bool> UpdateProductAsync(Product pm)
    {
        return await _productRepository.UpdateAsync(pm);
    }

    public async Task<bool> DeleteProductAsync(Product pm)
    {
        return await _productRepository.DeleteAsync(pm);
    }

    #endregion
}

