using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Clients;
using Leha.Infrastructure.UnitOfWorks;
using Microsoft.AspNetCore.Hosting;

namespace Leha.Manager.Managers.Clients;

public class ClientManager : IClientManager
{

    #region Fields
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClientRepository _clientRepository;
    private readonly IWebHostEnvironment _webHostEnvironment;

    #endregion

    #region Constructors
    public ClientManager(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _clientRepository = unitOfWork.ClientRepository;
        _webHostEnvironment = webHostEnvironment;

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
        {

            var oldImage = await _clientRepository.GetByIdAsync(pm.Id);
            var oldimagePath = oldImage.Image.Split('/').Last();
            string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", oldimagePath);

            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }

            return await _clientRepository.UpdateAsync(pm);
        }
        return false;
    }

    public async Task<bool> DeleteAsync(Client pm)
    {
        var oldImage = await _clientRepository.GetByIdAsync(pm.Id);
        var oldimagePath = oldImage.Image.Split('/').Last();
        string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", oldimagePath);

        if (File.Exists(imagePath))
        {
            File.Delete(imagePath);
        }

        return await _clientRepository.DeleteAsync(pm);
    }
    #endregion
}
