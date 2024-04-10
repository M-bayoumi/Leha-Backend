using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.CompanyAddresses;
using Leha.Infrastructure.UnitOfWorks;

namespace Leha.Manager.Managers.CompanyAddresses;

public class CompanyAddressManager : ICompanyAddressManager
{
    #region Fields
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICompanyAddressRepository _companyAddressRepository;
    #endregion

    #region Constructors
    public CompanyAddressManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _companyAddressRepository = unitOfWork.CompanyAddressRepository;
    }
    #endregion

    #region Handle Functions
    public IQueryable<CompanyAddress?> GetAll()
    {
        return _companyAddressRepository.GetAll();
    }

    public IQueryable<CompanyAddress?> GetAllByCompanyId(int id)
    {
        return _companyAddressRepository.GetAllByCompanyId(id);
    }

    public async Task<CompanyAddress?> GetByIdAsync(int id)
    {
        return await _companyAddressRepository.GetByIdAsync(id);
    }

    public async Task<bool> AddAsync(CompanyAddress pm)
    {
        var dm = await _unitOfWork.CompanyRepository.GetByIdAsync(pm.CompanyId);
        if (dm != null)
            return await _companyAddressRepository.AddAsync(pm);
        return false;
    }

    public async Task<bool> UpdateAsync(CompanyAddress pm)
    {
        var dm = await _unitOfWork.CompanyRepository.GetByIdAsync(pm.CompanyId);
        if (dm != null)
            return await _companyAddressRepository.UpdateAsync(pm);
        return false;
    }

    public async Task<bool> DeleteAsync(CompanyAddress pm)
    {
        return await _companyAddressRepository.DeleteAsync(pm);
    }
    #endregion
}
