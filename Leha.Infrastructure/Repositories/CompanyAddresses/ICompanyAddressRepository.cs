using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Generic;

namespace Leha.Infrastructure.Repositories.CompanyAddresses;

public interface ICompanyAddressRepository : IGenericRepository<CompanyAddress>
{
    public IQueryable<CompanyAddress?> GetAllByCompanyId(int id);
}
