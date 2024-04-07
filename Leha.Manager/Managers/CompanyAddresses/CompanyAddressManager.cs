﻿using Leha.Data.Entities;
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

    public IQueryable<CompanyAddress?> GetCompanyAddressesListByCompanyId(int id)
    {
        return _companyAddressRepository.GetCompanyAddressesListByCompanyId(id).AsQueryable();
    }
    public async Task<CompanyAddress?> GetCompanyAddressByIDAsync(int id)
    {
        return await _companyAddressRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.ID == id);
    }

    public async Task<bool> AddCompanyAddressAsync(CompanyAddress pm)
    {
        return await _companyAddressRepository.AddAsync(pm);
    }

    public async Task<bool> UpdateCompanyAddressAsync(CompanyAddress pm)
    {
        return await _companyAddressRepository.UpdateAsync(pm);
    }

    public async Task<bool> DeleteCompanyAddressAsync(CompanyAddress pm)
    {
        return await _companyAddressRepository.DeleteAsync(pm);
    }
    #endregion
}
