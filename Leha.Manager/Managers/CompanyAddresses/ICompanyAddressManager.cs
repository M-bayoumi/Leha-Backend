using Leha.Data.Entities;

namespace Leha.Manager.Managers.CompanyAddresses;

public interface ICompanyAddressManager
{
    public IQueryable<CompanyAddress?> GetAll();
    public IQueryable<CompanyAddress?> GetAllByCompanyID(int id);
    public Task<CompanyAddress?> GetByIdAsync(int id);
    public Task<bool> AddAsync(CompanyAddress pm);
    public Task<bool> UpdateAsync(CompanyAddress pm);
    public Task<bool> DeleteAsync(CompanyAddress pm);
}
