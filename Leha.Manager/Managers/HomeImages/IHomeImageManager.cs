using Leha.Data.Entities;

namespace Leha.Manager.Managers.HomeImages;

public interface IHomeImageManager
{
    public IQueryable<HomeImage?> GetHomeImagesListAsync();
    public IQueryable<HomeImage?> GetHomeImagesListByCompanyId(int id);
    public Task<HomeImage?> GetHomeImageByIDAsync(int id);
    public Task<bool> AddHomeImageAsync(HomeImage pm);
    public Task<bool> UpdateHomeImageAsync(HomeImage pm);
    public Task<bool> DeleteHomeImageAsync(HomeImage pm);
}
