using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.CompanyAddresses;
using Leha.Infrastructure.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

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
    public IQueryable<CompanyAddress?> GetCompanyAddressesListAsync()
    {
        return _companyAddressRepository.GetTableNoTracking().AsQueryable();
    }

    public IQueryable<CompanyAddress?> GetCompanyAddressesListByCompanyId(int companyID)
    {
        return _companyAddressRepository.GetCompanyAddressesListByCompanyId(companyID).AsQueryable();
    }
    public async Task<CompanyAddress?> GetCompanyAddressByIDAsync(int companyAddressID)
    {
        return await _companyAddressRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.ID == companyAddressID);
    }

    public async Task<bool> AddCompanyAddressAsync(CompanyAddress companyAddress)
    {
        return await _companyAddressRepository.AddAsync(companyAddress);
    }

    public async Task<bool> UpdateCompanyAddressAsync(CompanyAddress companyAddress)
    {
        return await _companyAddressRepository.UpdateAsync(companyAddress);
    }

    public async Task<bool> DeleteCompanyAddressAsync(CompanyAddress companyAddress)
    {
        return await _companyAddressRepository.DeleteAsync(companyAddress);
    }
    #endregion
}
