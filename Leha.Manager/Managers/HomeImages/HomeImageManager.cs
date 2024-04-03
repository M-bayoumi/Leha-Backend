using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.HomeImages;
using Leha.Infrastructure.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace Leha.Manager.Managers.HomeImages;

public class HomeImageManager : IHomeImageManager
{
    #region Fields
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHomeImageRepository _homeImageRepository;
    #endregion

    #region Constructors
    public HomeImageManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _homeImageRepository = unitOfWork.HomeImageRepository;
    }

    #endregion

    #region Handle Functions

    public async Task<List<HomeImage?>> GetHomeImagesListAsync()
    {
        return await _homeImageRepository.GetTableNoTracking().ToListAsync();
    }
    public async Task<List<HomeImage?>> GetHomeImagesListByCompanyId(int companyID)
    {
        return await _homeImageRepository.GetHomeImagesListByCompanyId(companyID);
    }

    public async Task<HomeImage?> GetHomeImageByIDAsync(int homeImageID)
    {
        var homeImage = await _homeImageRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.ID == homeImageID);
        return homeImage;
    }

    public async Task<bool> AddHomeImageAsync(HomeImage homeImage)
    {
        return await _homeImageRepository.AddAsync(homeImage);
    }
    public async Task<bool> UpdateHomeImageAsync(HomeImage homeImage)
    {
        return await _homeImageRepository.UpdateAsync(homeImage);
    }

    public async Task<bool> DeleteHomeImageAsync(HomeImage homeImage)
    {
        var trans = _homeImageRepository.BeginTransaction();
        try
        {
            //company.RemoveAllPosts();
            await _homeImageRepository.DeleteAsync(homeImage);
            await trans.CommitAsync();
            return true;
        }
        catch
        {
            await trans.RollbackAsync();
            return false;
        }
    }

    #endregion
}
