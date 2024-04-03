using Leha.Data.Entities;

namespace Leha.Manager.Managers.Services;

public interface IServiceManager
{
    public Task<List<Service?>> GetServicesListAsync();
    public Task<List<Service?>> GetServicesListByCompanyId(int companyID);
    public Task<Service?> GetServiceByIDAsync(int serviceID);
    public Task<bool> AddServiceAsync(Service service);
    public Task<bool> UpdateServiceAsync(Service service);
    public Task<bool> DeleteServiceAsync(Service service);
}
