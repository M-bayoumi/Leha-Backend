using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Projects;
using Leha.Infrastructure.UnitOfWorks;

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


    public IQueryable<Project?> GetAll()
    {
        return _projectRepository.GetAll();
    }

    public IQueryable<Project?> GetAllByCompanyID(int id)
    {
        return _projectRepository.GetAllByCompanyID(id);
    }

    public async Task<Project?> GetByIdAsync(int id)
    {
        return await _projectRepository.GetByIdAsync(id);
    }

    public async Task<bool> AddAsync(Project pm)
    {
        var dm = await _unitOfWork.CompanyRepository.GetByIdAsync(pm.CompanyID);
        if (dm != null)
            return await _projectRepository.AddAsync(pm);
        return false;
    }

    public async Task<bool> UpdateAsync(Project pm)
    {
        var dm = await _unitOfWork.CompanyRepository.GetByIdAsync(pm.CompanyID);
        if (dm != null)
            return await _projectRepository.UpdateAsync(pm);
        return false;
    }

    public async Task<bool> DeleteAsync(Project pm)
    {
        var transaction = _projectRepository.BeginTransaction();
        try
        {
            var dms = _unitOfWork.ProjectPhaseRepository.GetAllByProjectID(pm.ID).ToList();

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
