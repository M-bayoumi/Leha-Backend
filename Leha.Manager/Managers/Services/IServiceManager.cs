using Leha.Data.Entities;

namespace Leha.Manager.Managers.Services;

public interface IServiceManager
{
    public IQueryable<Service?> GetServicesListAsync();
    public IQueryable<Service?> GetServicesListByCompanyId(int id);
    public Task<Service?> GetServiceByIDAsync(int id);
    public Task<bool> AddServiceAsync(Service pm);
    public Task<bool> UpdateServiceAsync(Service pm);
    public Task<bool> DeleteServiceAsync(Service pm);
}
