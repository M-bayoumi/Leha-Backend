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
    #endregion

    #region Handle Functions
    public IQueryable<Client?> GetAllByCompanyID(int id)
    {
        return _clients.Where(x => x.CompanyID == id)
            .AsNoTracking()
            .AsQueryable();
    }
    #endregion
}
