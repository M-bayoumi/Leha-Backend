using Leha.Data.Entities;

namespace Leha.Manager.Managers.Companies;
public interface ICompanyManager
{
    public IQueryable<Company?> GetAll();
    public Task<Company?> GetByIdAsync(int id);
    public Task<bool> AddAsync(Company pm);
    public Task<bool> UpdateAsync(Company pm);
    public Task<bool> DeleteAsync(Company pm);
    public Task<bool> IsNameArExist(string nameAr);
    public Task<bool> IsNameEnExist(string nameEn);
    public Task<bool> IsNameArExistExludeSelf(string nameAr, int id);
    public Task<bool> IsNameEnExistExludeSelf(string nameEn, int id);
}
