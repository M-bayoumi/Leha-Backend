using Leha.Data.Entities;

namespace Leha.Manager.Managers.HomeImages;

public interface IHomeImageManager
{
    public IQueryable<HomeImage?> GetHomeImagesListAsync();
    public IQueryable<HomeImage?> GetHomeImagesListByCompanyId(int companyID);
    public Task<HomeImage?> GetHomeImageByIDAsync(int homeImageID);
    public Task<bool> AddHomeImageAsync(HomeImage homeImage);
    public Task<bool> UpdateHomeImageAsync(HomeImage homeImage);
    public Task<bool> DeleteHomeImageAsync(HomeImage homeImage);
}
