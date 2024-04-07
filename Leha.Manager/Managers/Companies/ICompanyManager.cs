using Leha.Data.Entities;

namespace Leha.Manager.Managers.Companies;
public interface ICompanyManager
{
    public IQueryable<Company?> GetCompaniesListAsync();
    public Task<Company?> GetCompanyByIDAsync(int id);
    public Task<bool> AddCompanyAsync(Company pm);
    public Task<bool> UpdateCompanyAsync(Company pm);
    public Task<bool> DeleteCompanyAsync(Company pm);
    public Task<bool> IsNameExist(string name);
    public Task<bool> IsNameExistExludeSelf(string name, int id);
}
