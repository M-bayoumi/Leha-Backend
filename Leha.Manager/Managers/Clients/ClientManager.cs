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

    public IQueryable<Client?> GetClientsListAsync()
    {
        return _clientRepository.GetTableNoTracking().AsQueryable();

    }


    public IQueryable<Client?> GetClientsListByCompanyId(int id)
    {
        return _clientRepository.GetClientsListByCompanyId(id).AsQueryable();

    }

    public async Task<Client?> GetClientByIDAsync(int id)
    {
        return await _clientRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.ID == id);
    }

    public async Task<bool> AddClientAsync(Client pm)
    { // check if company is exist
        return await _clientRepository.AddAsync(pm);
    }

    public async Task<bool> UpdateClientAsync(Client pm)
    {
        return await _clientRepository.UpdateAsync(pm);
    }
    public async Task<bool> DeleteClientAsync(Client pm)
    {
        return await _clientRepository.DeleteAsync(pm);
    }

    #endregion
}
