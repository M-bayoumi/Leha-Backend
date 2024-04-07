using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.ProjectPhases;
using Leha.Infrastructure.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

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


    public IQueryable<ProjectPhase?> GetProjectPhasesListAsync()
    {
        return _projectPhaseRepository.GetTableNoTracking().AsQueryable();
    }

    public IQueryable<ProjectPhase?> GetProjectPhasesListByProjectId(int id)
    {
        return _projectPhaseRepository.GetProjectPhasesListByProjectId(id).AsQueryable();
    }

    public async Task<ProjectPhase?> GetProjectPhaseByIDAsync(int id)
    {
        return await _projectPhaseRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.ID == id);
    }
    public async Task<bool> AddProjectPhaseAsync(ProjectPhase pm)
    {
        return await _projectPhaseRepository.AddAsync(pm);
    }

    public async Task<bool> UpdateProjectPhaseAsync(ProjectPhase pm)
    {
        return await _projectPhaseRepository.AddAsync(pm);
    }

    public async Task<bool> DeleteProjectPhaseAsync(ProjectPhase pm)
    {
        var transaction = _projectPhaseRepository.BeginTransaction();
        try
        {
            var dms = _unitOfWork.PhaseItemRepository.GetPhaseItemsListByProjectPhaseId(pm.ID).ToList();

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
