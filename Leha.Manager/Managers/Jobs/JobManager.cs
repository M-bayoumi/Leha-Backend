using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Jobs;
using Leha.Infrastructure.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace Leha.Manager.Managers.Jobs;

public class JobManager : IJobManager
{
    #region Fields
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJobRepository _jobRepository;
    #endregion

    #region Constructors
    public JobManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _jobRepository = unitOfWork.JobRepository;
    }


    #endregion

    #region Handle Functions

    public async Task<List<Job?>> GetJobsListAsync()
    {
        return await _jobRepository.GetTableNoTracking().ToListAsync();
    }
    public async Task<List<Job>?> GetJobsListByCompanyId(int companyID)
    {
        return await _jobRepository.GetJobsListByCompanyId(companyID);
    }
    public async Task<Job?> GetJobByIDAsync(int jobID)
    {
        return await _jobRepository.GetByIdAsync(jobID);
    }
    public async Task<bool> AddJobAsync(Job job)
    {
        return await _jobRepository.AddAsync(job);
    }
    public async Task<bool> UpdateJobAsync(Job job)
    {
        return await _jobRepository.UpdateAsync(job);
    }
    public async Task<bool> DeleteJobAsync(Job job)
    {
        var transaction = _jobRepository.BeginTransaction();
        try
        {
            var jobForms = await _unitOfWork.FormRepository.GetFormsListByJobId(job.ID);

            if (jobForms != null)
                await _unitOfWork.FormRepository.DeleteRangeAsync(jobForms);

            await _jobRepository.DeleteAsync(job);

            await transaction.CommitAsync();

            return true;
        }
        catch
        {
            await transaction.RollbackAsync();
            return false;
        }
    }
    #endregion
}
