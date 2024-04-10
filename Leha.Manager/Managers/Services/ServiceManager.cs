using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Services;
using Leha.Infrastructure.UnitOfWorks;

namespace Leha.Manager.Managers.Services;

public class ServiceManager : IServiceManager
{
    #region Fields
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServiceRepository _serviceRepository;
    #endregion

    #region Constructors
    public ServiceManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _serviceRepository = unitOfWork.ServiceRepository;
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
            return await _serviceRepository.UpdateAsync(pm);
        return false;
    }

    public async Task<bool> DeleteAsync(Service pm)
    {

        return await _unitOfWork.ServiceRepository.DeleteAsync(pm);
    }

    #endregion
}
