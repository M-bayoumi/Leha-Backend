using Leha.Data.Entities;

namespace Leha.Manager.Managers.Jobs;

public interface IJobManager
{
    public IQueryable<Job?> GetJobsListAsync();
    public IQueryable<Job?> GetJobsListByCompanyId(int id);
    public Task<Job?> GetJobByIDAsync(int id);
    public Task<bool> AddJobAsync(Job pm);
    public Task<bool> UpdateJobAsync(Job pm);
    public Task<bool> DeleteJobAsync(Job pm);
}
