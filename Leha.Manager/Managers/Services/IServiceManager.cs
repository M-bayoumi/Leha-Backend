using Leha.Data.Entities;

namespace Leha.Manager.Managers.Services;

public interface IServiceManager
{
    public IQueryable<Service?> GetServicesListAsync();
    public IQueryable<Service?> GetServicesListByCompanyId(int companyID);
    public Task<Service?> GetServiceByIDAsync(int serviceID);
    public Task<bool> AddServiceAsync(Service service);
    public Task<bool> UpdateServiceAsync(Service service);
    public Task<bool> DeleteServiceAsync(Service service);
}
