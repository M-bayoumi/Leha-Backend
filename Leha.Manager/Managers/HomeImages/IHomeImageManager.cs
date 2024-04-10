using Leha.Data.Entities;

namespace Leha.Manager.Managers.HomeImages;

public interface IHomeImageManager
{
    public IQueryable<HomeImage?> GetAll();
    public IQueryable<HomeImage?> GetAllByCompanyId(int id);
    public Task<HomeImage?> GetByIdAsync(int id);
    public Task<bool> AddAsync(HomeImage pm);
    public Task<bool> UpdateAsync(HomeImage pm);
    public Task<bool> DeleteAsync(HomeImage pm);
}
