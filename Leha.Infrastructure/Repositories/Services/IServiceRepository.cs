using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Generic;

namespace Leha.Infrastructure.Repositories.Services;

public interface IServiceRepository : IGenericRepository<Service>
{
    public IQueryable<Service?> GetAllByCompanyID(int id);
}
