using Leha.Data.Entities;

namespace Leha.Manager.Managers.CompanyAddresses;

public interface ICompanyAddressManager
{
    public Task<List<CompanyAddress?>> GetCompanyAddressesListAsync();
    public Task<List<CompanyAddress>?> GetCompanyAddressesListByCompanyId(int companyID);
    public Task<CompanyAddress?> GetCompanyAddressByIDAsync(int companyAddressID);
    public Task<bool> AddCompanyAddressAsync(CompanyAddress companyAddress);
    public Task<bool> UpdateCompanyAddressAsync(CompanyAddress companyAddress);
    public Task<bool> DeleteCompanyAddressAsync(CompanyAddress companyAddress);
}
