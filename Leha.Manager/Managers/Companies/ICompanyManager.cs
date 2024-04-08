using Leha.Data.Entities;

namespace Leha.Manager.Managers.Companies;
public interface ICompanyManager
{
    public IQueryable<Company?> GetAll();
    public Task<Company?> GetByIdAsync(int id);
    public Task<bool> AddAsync(Company pm);
    public Task<bool> UpdateAsync(Company pm);
    public Task<bool> DeleteAsync(Company pm);
    public Task<bool> IsNameExist(string name);
    public Task<bool> IsNameExistExludeSelf(string name, int id);
}
