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
    public IQueryable<Job?> GetJobsListByCompanyId(int id)
    {
        return _jobRepository.GetJobsListByCompanyId(id).AsQueryable();
    }
    public async Task<Job?> GetJobByIDAsync(int id)
    {
        return await _jobRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.ID == id);
    }
    public async Task<bool> AddJobAsync(Job pm)
    {
        return await _jobRepository.AddAsync(pm);
    }
    public async Task<bool> UpdateJobAsync(Job pm)
    {
        return await _jobRepository.UpdateAsync(pm);
    }
    public async Task<bool> DeleteJobAsync(Job pm)
    {
        var transaction = _jobRepository.BeginTransaction();
        try
        {
            var dms = _unitOfWork.FormRepository.GetFormsListByJobId(pm.ID).ToList();

            if (dms != null)
                await _unitOfWork.FormRepository.DeleteRangeAsync(dms);

            await _jobRepository.DeleteAsync(pm);

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
