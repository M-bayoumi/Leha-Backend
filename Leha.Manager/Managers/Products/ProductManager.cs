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

    public IQueryable<Product?> GetProductsListByCompanyId(int companyID)
    {
        return _productRepository.GetProductsListByCompanyId(companyID).AsQueryable();
    }
    public async Task<Product?> GetProductByIDAsync(int productID)
    {
        return await _productRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.ID == productID);
    }

    public async Task<bool> AddProductAsync(Product product)
    {
        return await _productRepository.AddAsync(product);
    }
    public async Task<bool> UpdateProductAsync(Product product)
    {
        return await _productRepository.UpdateAsync(product);
    }

    public async Task<bool> DeleteProductAsync(Product product)
    {
        return await _productRepository.DeleteAsync(product);
    }

    #endregion
}

