using Leha.Data.Entities;

namespace Leha.Manager.Managers.ProjectPhases;

public interface IProjectPhaseManager
{
    public IQueryable<ProjectPhase?> GetAll();
    public IQueryable<ProjectPhase?> GetAllByProjectID(int id);
    public Task<ProjectPhase?> GetByIdAsync(int id);
    public Task<bool> AddAsync(ProjectPhase pm);
    public Task<bool> UpdateAsync(ProjectPhase pm);
    public Task<bool> DeleteAsync(ProjectPhase pm);
}
