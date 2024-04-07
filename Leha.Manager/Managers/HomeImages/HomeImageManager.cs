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

    public IQueryable<HomeImage?> GetHomeImagesListAsync()
    {
        return _homeImageRepository.GetTableNoTracking().AsQueryable();
    }
    public IQueryable<HomeImage?> GetHomeImagesListByCompanyId(int id)
    {
        return _homeImageRepository.GetHomeImagesListByCompanyId(id).AsQueryable();
    }

    public async Task<HomeImage?> GetHomeImageByIDAsync(int id)
    {
        var homeImage = await _homeImageRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.ID == id);
        return homeImage;
    }

    public async Task<bool> AddHomeImageAsync(HomeImage pm)
    {
        return await _homeImageRepository.AddAsync(pm);
    }
    public async Task<bool> UpdateHomeImageAsync(HomeImage pm)
    {
        return await _homeImageRepository.UpdateAsync(pm);
    }

    public async Task<bool> DeleteHomeImageAsync(HomeImage pm)
    {

        return await _homeImageRepository.DeleteAsync(pm);

    }

    #endregion
}
