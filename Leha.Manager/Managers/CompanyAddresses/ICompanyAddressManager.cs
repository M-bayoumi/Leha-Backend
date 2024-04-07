using Leha.Data.Entities;

namespace Leha.Manager.Managers.CompanyAddresses;

public interface ICompanyAddressManager
{
    public IQueryable<CompanyAddress?> GetCompanyAddressesListAsync();
    public IQueryable<CompanyAddress?> GetCompanyAddressesListByCompanyId(int id);
    public Task<CompanyAddress?> GetCompanyAddressByIDAsync(int id);
    public Task<bool> AddCompanyAddressAsync(CompanyAddress pm);
    public Task<bool> UpdateCompanyAddressAsync(CompanyAddress pm);
    public Task<bool> DeleteCompanyAddressAsync(CompanyAddress pm);
}
