using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Jobs;
using Leha.Infrastructure.UnitOfWorks;

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

    public IQueryable<Job?> GetAll()
    {
        return _jobRepository.GetAll();
    }

    public IQueryable<Job?> GetAllByCompanyID(int id)
    {
        return _jobRepository.GetAllByCompanyID(id);
    }

    public async Task<Job?> GetByIdAsync(int id)
    {
        return await _jobRepository.GetByIdAsync(id);
    }

    public async Task<bool> AddAsync(Job pm)
    {
        var dm = await _unitOfWork.CompanyRepository.GetByIdAsync(pm.CompanyID);
        if (dm != null)
            return await _jobRepository.AddAsync(pm);
        return false;
    }

    public async Task<bool> UpdateAsync(Job pm)
    {
        var dm = await _unitOfWork.CompanyRepository.GetByIdAsync(pm.CompanyID);
        if (dm != null)
            return await _jobRepository.UpdateAsync(pm);
        return false;
    }

    public async Task<bool> DeleteAsync(Job pm)
    {
        var transaction = _jobRepository.BeginTransaction();
        try
        {
            var dms = _unitOfWork.FormRepository.GetAllByJobID(pm.ID).ToList();

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
