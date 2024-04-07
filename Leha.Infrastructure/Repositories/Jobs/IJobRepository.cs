using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Generic;

namespace Leha.Infrastructure.Repositories.Jobs;

public interface IJobRepository : IGenericRepository<Job>
{
    public IQueryable<Job?> GetJobsListByCompanyId(int id);
}