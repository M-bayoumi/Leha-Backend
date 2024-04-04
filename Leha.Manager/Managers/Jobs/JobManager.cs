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

    public IQueryable<Job?> GetJobsListAsync()
    {
        return _jobRepository.GetTableNoTracking().AsQueryable();
    }
    public IQueryable<Job?> GetJobsListByCompanyId(int companyID)
    {
        return _jobRepository.GetJobsListByCompanyId(companyID).AsQueryable();
    }
    public async Task<Job?> GetJobByIDAsync(int jobID)
    {
        return await _jobRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.ID == jobID);
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
            var jobForms = _unitOfWork.FormRepository.GetFormsListByJobId(job.ID).ToList();

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
