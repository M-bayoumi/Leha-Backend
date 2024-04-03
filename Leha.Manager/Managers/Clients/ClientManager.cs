using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Clients;
using Leha.Infrastructure.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace Leha.Manager.Managers.Clients;

public class ClientManager : IClientManager
{
    #region Fields
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClientRepository _clientRepository;
    #endregion

    #region Constructors
    public ClientManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _clientRepository = unitOfWork.ClientRepository;
    }
    #endregion

    #region Handle Functions

    public async Task<List<Client?>> GetClientsListAsync()
    {
        return await _clientRepository.GetTableNoTracking().ToListAsync();

    }

    public async Task<List<Client>?> GetClientsListByCompanyId(int companyID)
    {
        return await _clientRepository.GetClientsListByCompanyId(companyID);

    }

    public async Task<Client?> GetClientByIDAsync(int clientID)
    {
        return await _clientRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.ID == clientID);
    }

    public async Task<bool> AddClientAsync(Client client)
    {
        return await _clientRepository.AddAsync(client);
    }


    public async Task<bool> UpdateClientAsync(Client client)
    {
        return await _clientRepository.UpdateAsync(client);
    }
    public async Task<bool> DeleteClientAsync(Client client)
    {
        return await _clientRepository.DeleteAsync(client);
    }

    #endregion
}
