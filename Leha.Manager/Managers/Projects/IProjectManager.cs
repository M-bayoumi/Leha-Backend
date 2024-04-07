using Leha.Data.Entities;

namespace Leha.Manager.Managers.Projects;

public interface IProjectManager
{
    public IQueryable<Project?> GetProjectsListAsync();
    public IQueryable<Project?> GetProjectsListByCompanyId(int id);
    public Task<Project?> GetProjectByIDAsync(int id);
    public Task<bool> AddProjectAsync(Project pm);
    public Task<bool> UpdateProjectAsync(Project pm);
    public Task<bool> DeleteProjectAsync(Project pm);
}
