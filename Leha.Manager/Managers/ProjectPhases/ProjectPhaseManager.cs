using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.ProjectPhases;
using Leha.Infrastructure.UnitOfWorks;

namespace Leha.Manager.Managers.ProjectPhases;

public class ProjectPhaseManager : IProjectPhaseManager
{
    #region Fields
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProjectPhaseRepository _projectPhaseRepository;
    #endregion

    #region Constructors
    public ProjectPhaseManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _projectPhaseRepository = unitOfWork.ProjectPhaseRepository;
    }


    #endregion

    #region Handle Functions


    public IQueryable<ProjectPhase?> GetAll()
    {
        return _projectPhaseRepository.GetAll();
    }

    public IQueryable<ProjectPhase?> GetAllByProjectID(int id)
    {
        return _projectPhaseRepository.GetAllByProjectID(id);
    }

    public async Task<ProjectPhase?> GetByIdAsync(int id)
    {
        return await _projectPhaseRepository.GetByIdAsync(id);
    }

    public async Task<bool> AddAsync(ProjectPhase pm)
    {
        var dm = await _unitOfWork.ProjectRepository.GetByIdAsync(pm.ProjectID);
        if (dm != null)
            return await _projectPhaseRepository.AddAsync(pm);
        return false;
    }

    public async Task<bool> UpdateAsync(ProjectPhase pm)
    {
        return await _projectPhaseRepository.UpdateAsync(pm);
    }

    public async Task<bool> DeleteAsync(ProjectPhase pm)
    {
        var transaction = _projectPhaseRepository.BeginTransaction();
        try
        {
            var dms = _unitOfWork.PhaseItemRepository.GetAllByProjectPhaseID(pm.ID).ToList();

            if (dms != null)
                await _unitOfWork.PhaseItemRepository.DeleteRangeAsync(dms);

            await _projectPhaseRepository.DeleteAsync(pm);

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
