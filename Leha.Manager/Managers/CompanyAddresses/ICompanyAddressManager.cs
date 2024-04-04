using Leha.Data.Entities;

namespace Leha.Manager.Managers.CompanyAddresses;

public interface ICompanyAddressManager
{
    public IQueryable<CompanyAddress?> GetCompanyAddressesListAsync();
    public IQueryable<CompanyAddress?> GetCompanyAddressesListByCompanyId(int companyID);
    public Task<CompanyAddress?> GetCompanyAddressByIDAsync(int companyAddressID);
    public Task<bool> AddCompanyAddressAsync(CompanyAddress companyAddress);
    public Task<bool> UpdateCompanyAddressAsync(CompanyAddress companyAddress);
    public Task<bool> DeleteCompanyAddressAsync(CompanyAddress companyAddress);
}
