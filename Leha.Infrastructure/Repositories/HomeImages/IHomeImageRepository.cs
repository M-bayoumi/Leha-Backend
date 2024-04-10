using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Generic;

namespace Leha.Infrastructure.Repositories.HomeImages;

public interface IHomeImageRepository : IGenericRepository<HomeImage>
{
    public IQueryable<HomeImage?> GetAllByCompanyId(int id);

}