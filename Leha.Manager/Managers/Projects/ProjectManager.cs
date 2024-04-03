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


    public async Task<List<Project?>> GetProjectsListAsync()
    {
        return await _projectRepository.GetTableNoTracking().ToListAsync();
    }

    public async Task<List<Project?>> GetProjectsListByCompanyId(int companyID)
    {
        return await _projectRepository.GetProjectsListByCompanyId(companyID);
    }

    public async Task<Project?> GetProjectByIDAsync(int projectID)
    {
        return await _projectRepository.GetByIdAsync(projectID);
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
            var projectPhases = await _unitOfWork.ProjectPhaseRepository.GetProjectPhasesListByProjectId(project.ID);

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
