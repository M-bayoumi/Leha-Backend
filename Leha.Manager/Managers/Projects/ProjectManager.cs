using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Projects;
using Leha.Infrastructure.UnitOfWorks;
using Microsoft.AspNetCore.Hosting;

namespace Leha.Manager.Managers.Projects;

public class ProjectManager : IProjectManager
{
    #region Fields
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProjectRepository _projectRepository;
    private readonly IWebHostEnvironment _webHostEnvironment;
    #endregion

    #region Constructors
    public ProjectManager(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _projectRepository = unitOfWork.ProjectRepository;
        _webHostEnvironment = webHostEnvironment;
    }
    #endregion

    #region Handle Functions


    public IQueryable<Project?> GetAll()
    {
        return _projectRepository.GetAll();
    }

    public IQueryable<Project?> GetAllByCompanyId(int id)
    {
        return _projectRepository.GetAllByCompanyId(id);
    }

    public async Task<Project?> GetByIdAsync(int id)
    {
        return await _projectRepository.GetByIdAsync(id);
    }

    public async Task<bool> AddAsync(Project pm)
    {
        var dm = await _unitOfWork.CompanyRepository.GetByIdAsync(pm.CompanyId);
        if (dm != null)
            return await _projectRepository.AddAsync(pm);
        return false;
    }

    public async Task<bool> UpdateAsync(Project pm)
    {
        var dm = await _unitOfWork.CompanyRepository.GetByIdAsync(pm.CompanyId);
        if (dm != null)
        {

            var oldImage = await _projectRepository.GetByIdAsync(pm.Id);
            var oldimagePath = oldImage.Image.Split('/').Last();
            string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", oldimagePath);

            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }

            return await _projectRepository.UpdateAsync(pm);
        }
        return false;
    }

    public async Task<bool> DeleteAsync(Project pm)
    {
        var transaction = _projectRepository.BeginTransaction();
        try
        {
            var dms = _unitOfWork.ProjectPhaseRepository.GetAllByProjectID(pm.Id).ToList();

            if (dms != null)
                await _unitOfWork.ProjectPhaseRepository.DeleteRangeAsync(dms);

            var oldImage = await _projectRepository.GetByIdAsync(pm.Id);
            var oldimagePath = oldImage.Image.Split('/').Last();
            string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", oldimagePath);

            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }

            return await _projectRepository.DeleteAsync(pm);

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
