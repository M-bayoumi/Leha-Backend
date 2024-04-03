using Leha.Data.Entities;

namespace Leha.Manager.Managers.HomeImages;

public interface IHomeImageManager
{
    public Task<List<HomeImage?>> GetHomeImagesListAsync();
    public Task<List<HomeImage?>> GetHomeImagesListByCompanyId(int companyID);
    public Task<HomeImage?> GetHomeImageByIDAsync(int homeImageID);
    public Task<bool> AddHomeImageAsync(HomeImage homeImage);
    public Task<bool> UpdateHomeImageAsync(HomeImage homeImage);
    public Task<bool> DeleteHomeImageAsync(HomeImage homeImage);
}
