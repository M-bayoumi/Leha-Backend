using Leha.Data.Entities;

namespace Leha.Manager.Managers.Clients;

public interface IClientManager
{
    public IQueryable<Client?> GetAll();
    public IQueryable<Client?> GetAllByCompanyID(int id);
    public Task<Client?> GetByIdAsync(int id);
    public Task<bool> AddAsync(Client pm);
    public Task<bool> UpdateAsync(Client pm);
    public Task<bool> DeleteAsync(Client pm);
}
