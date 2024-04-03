using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Generic;

namespace Leha.Infrastructure.Repositories.HomeImages;

public interface IHomeImageRepository : IGenericRepository<HomeImage>
{
    public Task<List<HomeImage?>> GetHomeImagesListByCompanyId(int companyID);

}