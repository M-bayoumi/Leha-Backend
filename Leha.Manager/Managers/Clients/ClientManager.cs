using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Clients;
using Leha.Infrastructure.UnitOfWorks;

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
    public IQueryable<Client?> GetAll()
    {
        return _clientRepository.GetAll();
    }

    public IQueryable<Client?> GetAllByCompanyId(int id)
    {
        return _clientRepository.GetAllByCompanyId(id);
    }

    public async Task<Client?> GetByIdAsync(int id)
    {
        return await _clientRepository.GetByIdAsync(id);
    }

    public async Task<bool> AddAsync(Client pm)
    {
        var dm = await _unitOfWork.CompanyRepository.GetByIdAsync(pm.CompanyId);
        if (dm != null)
            return await _clientRepository.AddAsync(pm);
        return false;
    }

    public async Task<bool> UpdateAsync(Client pm)
    {
        var dm = await _unitOfWork.CompanyRepository.GetByIdAsync(pm.CompanyId);
        if (dm != null)
            return await _clientRepository.UpdateAsync(pm);
        return false;
    }

    public async Task<bool> DeleteAsync(Client pm)
    {
        return await _clientRepository.DeleteAsync(pm);
    }
    #endregion
}
