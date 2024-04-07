using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Projects;
using Leha.Infrastructure.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace Leha.Manager.Managers.Projects;

public class ProjectManager : IProjectManager
{
    #region Fields
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProjectRepository _projectRepository;
    #endregion

    #region Constructors
    public ProjectManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _projectRepository = unitOfWork.ProjectRepository;
    }


    #endregion

    #region Handle Functions


    public IQueryable<Project?> GetProjectsListAsync()
    {
        return _projectRepository.GetTableNoTracking().AsQueryable();
    }

    public IQueryable<Project?> GetProjectsListByCompanyId(int id)
    {
        return _projectRepository.GetProjectsListByCompanyId(id).AsQueryable();
    }

    public async Task<Project?> GetProjectByIDAsync(int id)
    {
        return await _projectRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.ID == id);
    }
    public async Task<bool> AddProjectAsync(Project pm)
    {
        return await _projectRepository.AddAsync(pm);
    }

    public async Task<bool> UpdateProjectAsync(Project pm)
    {
        return await _projectRepository.AddAsync(pm);
    }

    public async Task<bool> DeleteProjectAsync(Project pm)
    {
        var transaction = _projectRepository.BeginTransaction();
        try
        {
            var dms = _unitOfWork.ProjectPhaseRepository.GetProjectPhasesListByProjectId(pm.ID).ToList();

            if (dms != null)
                await _unitOfWork.ProjectPhaseRepository.DeleteRangeAsync(dms);

            await _projectRepository.DeleteAsync(pm);

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
