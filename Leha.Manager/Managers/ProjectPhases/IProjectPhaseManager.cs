using Leha.Data.Entities;

namespace Leha.Manager.Managers.ProjectPhases;

public interface IProjectPhaseManager
{
    public IQueryable<ProjectPhase?> GetProjectPhasesListAsync();
    public IQueryable<ProjectPhase?> GetProjectPhasesListByProjectId(int id);
    public Task<ProjectPhase?> GetProjectPhaseByIDAsync(int id);
    public Task<bool> AddProjectPhaseAsync(ProjectPhase pm);
    public Task<bool> UpdateProjectPhaseAsync(ProjectPhase pm);
    public Task<bool> DeleteProjectPhaseAsync(ProjectPhase pm);
}
