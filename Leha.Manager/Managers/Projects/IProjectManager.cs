using Leha.Data.Entities;

namespace Leha.Manager.Managers.Projects;

public interface IProjectManager
{
    public Task<List<Project?>> GetProjectsListAsync();
    public Task<List<Project?>> GetProjectsListByCompanyId(int companyID);
    public Task<Project?> GetProjectByIDAsync(int projectID);
    public Task<bool> AddProjectAsync(Project project);
    public Task<bool> UpdateProjectAsync(Project project);
    public Task<bool> DeleteProjectAsync(Project project);
}
