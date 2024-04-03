using Leha.Data.Entities;
using Leha.Infrastructure.Context;
using Leha.Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Leha.Infrastructure.Repositories.Clients;


public class ClientRepository : GenericRepository<Client>, IClientRepository
{
    #region Fields
    private readonly DbSet<Client> _clients;
    #endregion

    #region Constructors
    public ClientRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _clients = appDbContext.Set<Client>();
    }

    public async Task<List<Client?>> GetClientsListByCompanyId(int companyID)
    {
        return await _clients.Where(x => x.CompanyID == companyID).ToListAsync();
    }

    #endregion

    #region Handle Functions

    #endregion
}
