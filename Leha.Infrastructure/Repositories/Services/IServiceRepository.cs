using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Generic;

namespace Leha.Infrastructure.Repositories.Services;

public interface IServiceRepository : IGenericRepository<Service>
{
    public Task<List<Service?>> GetServicesListByCompanyId(int companyID);

}
