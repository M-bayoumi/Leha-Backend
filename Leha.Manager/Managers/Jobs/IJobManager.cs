using Leha.Data.Entities;

namespace Leha.Manager.Managers.Jobs;

public interface IJobManager
{
    public Task<List<Job?>> GetJobsListAsync();
    public Task<List<Job>?> GetJobsListByCompanyId(int companyID);
    public Task<Job?> GetJobByIDAsync(int jobID);
    public Task<bool> AddJobAsync(Job job);
    public Task<bool> UpdateJobAsync(Job job);
    public Task<bool> DeleteJobAsync(Job job);
}
