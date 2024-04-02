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

    public async Task<List<Service?>> GetServicesListAsync()
    {
        return await _serviceRepository.GetTableNoTracking().ToListAsync();
    }

    public async Task<Service?> GetServiceByIDAsync(int serviceID)
    {
        var service = await _serviceRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.ID == serviceID);
        return service;
    }

    public async Task<bool> AddServiceAsync(Service service)
    {
        return await _serviceRepository.AddAsync(service);
    }
    public async Task<bool> UpdateServiceAsync(Service service)
    {
        return await _serviceRepository.UpdateAsync(service);
    }

    public async Task<bool> DeleteServiceAsync(Service service)
    {
        var trans = _serviceRepository.BeginTransaction();
        try
        {
            //company.RemoveAllPosts();
            await _serviceRepository.DeleteAsync(service);
            await trans.CommitAsync();
            return true;
        }
        catch
        {
            await trans.RollbackAsync();
            return false;
        }
    }

    #endregion
}

