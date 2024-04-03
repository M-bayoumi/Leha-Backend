using Leha.Data.Entities;

namespace Leha.Manager.Managers.ProjectPhases;

public interface IProjectPhaseManager
{
    public Task<List<ProjectPhase?>> GetProjectPhasesListAsync();
    public Task<List<ProjectPhase?>> GetProjectPhasesListByProjectId(int projectID);
    public Task<ProjectPhase?> GetProjectPhaseByIDAsync(int projectPhaseID);
    public Task<bool> AddProjectPhaseAsync(ProjectPhase projectPhase);
    public Task<bool> UpdateProjectPhaseAsync(ProjectPhase projectPhase);
    public Task<bool> DeleteProjectPhaseAsync(ProjectPhase projectPhase);
}
