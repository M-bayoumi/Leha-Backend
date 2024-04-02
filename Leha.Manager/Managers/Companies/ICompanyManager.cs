using Leha.Data.Entities;

namespace Leha.Manager.Managers.Companies;
public interface ICompanyManager
{
    public Task<List<Company?>> GetCompaniesListAsync();
    public Task<Company?> GetCompanyByIDAsync(int companyID);
    public Task<bool> AddCompanyAsync(Company company);
    public Task<bool> UpdateCompanyAsync(Company company);
    public Task<bool> DeleteCompanyAsync(Company company);
    public Task<bool> IsNameExist(string companyName);
    public Task<bool> IsNameExistExludeSelf(string companyName, int id);
}
