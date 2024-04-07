using Leha.Data.Entities;

namespace Leha.Manager.Managers.Clients;

public interface IClientManager
{
    public IQueryable<Client?> GetClientsListAsync();
    public IQueryable<Client?> GetClientsListByCompanyId(int id);
    public Task<Client?> GetClientByIDAsync(int id);
    public Task<bool> AddClientAsync(Client pm);
    public Task<bool> UpdateClientAsync(Client pm);
    public Task<bool> DeleteClientAsync(Client pm);
}
