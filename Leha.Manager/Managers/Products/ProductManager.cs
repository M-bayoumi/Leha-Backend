using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Products;
using Leha.Infrastructure.UnitOfWorks;
using Microsoft.AspNetCore.Hosting;

namespace Leha.Manager.Managers.Products;

public class ProductManager : IProductManager
{

    #region Fields
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductRepository _productRepository;
    private readonly IWebHostEnvironment _webHostEnvironment;
    #endregion

    #region Constructors
    public ProductManager(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _productRepository = unitOfWork.ProductRepository;
        _webHostEnvironment = webHostEnvironment;
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
        {

            var oldImage = await _productRepository.GetByIdAsync(pm.Id);
            var oldimagePath = oldImage.Image.Split('/').Last();
            string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", oldimagePath);

            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }

            return await _productRepository.UpdateAsync(pm);
        }
        return false;
    }

    public async Task<bool> DeleteAsync(Product pm)
    {
        var oldImage = await _productRepository.GetByIdAsync(pm.Id);
        var oldimagePath = oldImage.Image.Split('/').Last();
        string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", oldimagePath);

        if (File.Exists(imagePath))
        {
            File.Delete(imagePath);
        }

        return await _productRepository.DeleteAsync(pm);
    }
    #endregion
}

