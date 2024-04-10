using Leha.Data.Entities;
using Leha.Infrastructure.Context;
using Leha.Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Leha.Infrastructure.Repositories.Jobs;


public class JobRepository : GenericRepository<Job>, IJobRepository
{
    #region Fields
    private readonly DbSet<Job> _jobs;
    #endregion

    #region Constructors
    public JobRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _jobs = appDbContext.Set<Job>();
    }

    #endregion

    #region Handle Functions

    public IQueryable<Job?> GetAllByCompanyId(int id)
    {
        return _jobs.Where(x => x.CompanyId == id)
            .AsNoTracking()
            .AsQueryable();
    }

    #endregion
}
