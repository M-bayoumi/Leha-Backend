using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Services;
using Leha.Infrastructure.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

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

    public IQueryable<Service?> GetServicesListAsync()
    {
        return _serviceRepository.GetTableNoTracking().AsQueryable();
    }

    public IQueryable<Service?> GetServicesListByCompanyId(int companyID)
    {
        return _serviceRepository.GetServicesListByCompanyId(companyID).AsQueryable();
    }

    public async Task<Service?> GetServiceByIDAsync(int serviceID)
    {
        return await _serviceRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.ID == serviceID);
    }
    public async Task<bool> AddServiceAsync(Service service)
    {
        return await _serviceRepository.AddAsync(service);
    }

    public async Task<bool> UpdateServiceAsync(Service service)
    {
        return await _serviceRepository.AddAsync(service);
    }

    public async Task<bool> DeleteServiceAsync(Service service)
    {

        return await _unitOfWork.ServiceRepository.DeleteAsync(service);
    }

    #endregion
}
