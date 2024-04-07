using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Generic;

namespace Leha.Infrastructure.Repositories.Clients;

public interface IClientRepository : IGenericRepository<Client>
{
    public IQueryable<Client?> GetClientsListByCompanyId(int id);

}
