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

    public IQueryable<ProjectPhase?> GetProjectPhasesListByProjectId(int projectID)
    {
        return _projectPhaseRepository.GetProjectPhasesListByProjectId(projectID).AsQueryable();
    }

    public async Task<ProjectPhase?> GetProjectPhaseByIDAsync(int projectPhaseID)
    {
        return await _projectPhaseRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.ID == projectPhaseID);
    }
    public async Task<bool> AddProjectPhaseAsync(ProjectPhase projectPhase)
    {
        return await _projectPhaseRepository.AddAsync(projectPhase);
    }

    public async Task<bool> UpdateProjectPhaseAsync(ProjectPhase projectPhase)
    {
        return await _projectPhaseRepository.AddAsync(projectPhase);
    }

    public async Task<bool> DeleteProjectPhaseAsync(ProjectPhase projectPhase)
    {
        var transaction = _projectPhaseRepository.BeginTransaction();
        try
        {
            var projectPhaseItems = _unitOfWork.PhaseItemRepository.GetPhaseItemsListByProjectPhaseId(projectPhase.ID).ToList();

            if (projectPhaseItems != null)
                await _unitOfWork.PhaseItemRepository.DeleteRangeAsync(projectPhaseItems);

            await _projectPhaseRepository.DeleteAsync(projectPhase);

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
