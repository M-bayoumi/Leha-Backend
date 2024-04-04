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

    public IQueryable<Project?> GetProjectsListByCompanyId(int companyID)
    {
        return _projectRepository.GetProjectsListByCompanyId(companyID).AsQueryable();
    }

    public async Task<Project?> GetProjectByIDAsync(int projectID)
    {
        return await _projectRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.ID == projectID);
    }
    public async Task<bool> AddProjectAsync(Project project)
    {
        return await _projectRepository.AddAsync(project);
    }

    public async Task<bool> UpdateProjectAsync(Project project)
    {
        return await _projectRepository.AddAsync(project);
    }

    public async Task<bool> DeleteProjectAsync(Project project)
    {
        var transaction = _projectRepository.BeginTransaction();
        try
        {
            var projectPhases = _unitOfWork.ProjectPhaseRepository.GetProjectPhasesListByProjectId(project.ID).ToList();

            if (projectPhases != null)
                await _unitOfWork.ProjectPhaseRepository.DeleteRangeAsync(projectPhases);

            await _projectRepository.DeleteAsync(project);

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
