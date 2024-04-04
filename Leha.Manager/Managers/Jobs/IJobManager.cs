using Leha.Data.Entities;

namespace Leha.Manager.Managers.Jobs;

public interface IJobManager
{
    public IQueryable<Job?> GetJobsListAsync();
    public IQueryable<Job?> GetJobsListByCompanyId(int companyID);
    public Task<Job?> GetJobByIDAsync(int jobID);
    public Task<bool> AddJobAsync(Job job);
    public Task<bool> UpdateJobAsync(Job job);
    public Task<bool> DeleteJobAsync(Job job);
}
