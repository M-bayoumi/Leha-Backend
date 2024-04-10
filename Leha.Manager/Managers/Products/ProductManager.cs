using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Products;
using Leha.Infrastructure.UnitOfWorks;

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
    public IQueryable<Product?> GetAll()
    {
        return _productRepository.GetAll();
    }

    public IQueryable<Product?> GetAllByCompanyId(int id)
    {
        return _productRepository.GetAllByCompanyId(id);
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _productRepository.GetByIdAsync(id);
    }

    public async Task<bool> AddAsync(Product pm)
    {
        var dm = await _unitOfWork.CompanyRepository.GetByIdAsync(pm.CompanyId);
        if (dm != null)
            return await _productRepository.AddAsync(pm);
        return false;
    }

    public async Task<bool> UpdateAsync(Product pm)
    {
        var dm = await _unitOfWork.CompanyRepository.GetByIdAsync(pm.CompanyId);
        if (dm != null)
            return await _productRepository.UpdateAsync(pm);
        return false;
    }

    public async Task<bool> DeleteAsync(Product pm)
    {
        return await _productRepository.DeleteAsync(pm);
    }
    #endregion
}

