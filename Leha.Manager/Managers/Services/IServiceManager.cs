using Leha.Data.Entities;

namespace Leha.Manager.Managers.Services;

public interface IServiceManager
{
    public IQueryable<Service?> GetAll();
    public IQueryable<Service?> GetAllByCompanyID(int id);
    public Task<Service?> GetByIdAsync(int id);
    public Task<bool> AddAsync(Service pm);
    public Task<bool> UpdateAsync(Service pm);
    public Task<bool> DeleteAsync(Service pm);
}
