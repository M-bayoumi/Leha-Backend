using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Services;
using Leha.Infrastructure.UnitOfWorks;
using Microsoft.AspNetCore.Hosting;

namespace Leha.Manager.Managers.Services;

public class ServiceManager : IServiceManager
{
    #region Fields
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServiceRepository _serviceRepository;
    private readonly IWebHostEnvironment _webHostEnvironment;
    #endregion

    #region Constructors
    public ServiceManager(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _serviceRepository = unitOfWork.ServiceRepository;
        _webHostEnvironment = webHostEnvironment;
    }
    #endregion

    #region Handle Functions

    public IQueryable<Service?> GetAll()
    {
        return _serviceRepository.GetAll();
    }

    public IQueryable<Service?> GetAllByCompanyId(int id)
    {
        return _serviceRepository.GetAllByCompanyId(id);
    }

    public async Task<Service?> GetByIdAsync(int id)
    {
        return await _serviceRepository.GetByIdAsync(id);
    }
    public async Task<bool> AddAsync(Service pm)
    {
        var dm = await _unitOfWork.CompanyRepository.GetByIdAsync(pm.CompanyId);
        if (dm != null)
            return await _serviceRepository.AddAsync(pm);
        return false;
    }

    public async Task<bool> UpdateAsync(Service pm)
    {
        var dm = await _unitOfWork.CompanyRepository.GetByIdAsync(pm.CompanyId);
        if (dm != null)
        {

            var oldImage = await _serviceRepository.GetByIdAsync(pm.Id);
            var oldimagePath = oldImage.Image.Split('/').Last();
            string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", oldimagePath);

            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }

            return await _serviceRepository.UpdateAsync(pm);
        }
        return false;
    }

    public async Task<bool> DeleteAsync(Service pm)
    {

        var oldImage = await _serviceRepository.GetByIdAsync(pm.Id);
        var oldimagePath = oldImage.Image.Split('/').Last();
        string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", oldimagePath);

        if (File.Exists(imagePath))
        {
            File.Delete(imagePath);
        }

        return await _serviceRepository.DeleteAsync(pm);
    }

    #endregion
}
