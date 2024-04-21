using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.HomeImages;
using Leha.Infrastructure.UnitOfWorks;
using Microsoft.AspNetCore.Hosting;

namespace Leha.Manager.Managers.HomeImages;

public class HomeImageManager : IHomeImageManager
{
    #region Fields
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHomeImageRepository _homeImageRepository;
    private readonly IWebHostEnvironment _webHostEnvironment;

    #endregion

    #region Constructors
    public HomeImageManager(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _homeImageRepository = unitOfWork.HomeImageRepository;
        _webHostEnvironment = webHostEnvironment;

    }
    #endregion

    #region Handle Functions
    public IQueryable<HomeImage?> GetAll()
    {
        return _homeImageRepository.GetAll();
    }

    public IQueryable<HomeImage?> GetAllByCompanyId(int id)
    {
        return _homeImageRepository.GetAllByCompanyId(id);
    }

    public async Task<HomeImage?> GetByIdAsync(int id)
    {
        var homeImage = await _homeImageRepository.GetByIdAsync(id);
        return homeImage;
    }

    public async Task<bool> AddAsync(HomeImage pm)
    {
        var dm = await _unitOfWork.CompanyRepository.GetByIdAsync(pm.CompanyId);
        if (dm != null)
            return await _homeImageRepository.AddAsync(pm);
        return false;
    }

    public async Task<bool> UpdateAsync(HomeImage pm)
    {
        var dm = await _unitOfWork.CompanyRepository.GetByIdAsync(pm.CompanyId);


        if (dm != null)
        {
            var oldImage = await _homeImageRepository.GetByIdAsync(pm.Id);
            var oldimagePath = oldImage.ImageURL.Split('/').Last();
            string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", oldimagePath);

            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }

            return await _homeImageRepository.UpdateAsync(pm);
        }
        return false;
    }

    public async Task<bool> DeleteAsync(HomeImage pm)
    {

        var oldImage = await _homeImageRepository.GetByIdAsync(pm.Id);
        var oldimagePath = oldImage.ImageURL.Split('/').Last();
        string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", oldimagePath);

        if (File.Exists(imagePath))
        {
            File.Delete(imagePath);
        }

        return await _homeImageRepository.DeleteAsync(pm);
    }
    #endregion
}
