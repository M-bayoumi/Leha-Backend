using Leha.Data.Entities;

namespace Leha.Manager.Managers.Projects;

public interface IProjectManager
{
    public IQueryable<Project?> GetAll();
    public IQueryable<Project?> GetAllByCompanyId(int id);
    public Task<Project?> GetByIdAsync(int id);
    public Task<bool> AddAsync(Project pm);
    public Task<bool> UpdateAsync(Project pm);
    public Task<bool> DeleteAsync(Project pm);
}
