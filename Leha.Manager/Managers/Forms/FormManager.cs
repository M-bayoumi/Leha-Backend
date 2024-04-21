using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Forms;
using Leha.Infrastructure.UnitOfWorks;
using Microsoft.AspNetCore.Hosting;

namespace Leha.Manager.Managers.Forms;

public class FormManager : IFormManager
{
    #region Fields
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFormRepository _formRepository;
    private readonly IWebHostEnvironment _webHostEnvironment;
    #endregion

    #region Constructors
    public FormManager(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _formRepository = unitOfWork.FormRepository;
        _webHostEnvironment = webHostEnvironment;
    }
    #endregion

    #region Handle Functions
    public IQueryable<Form?> GetAll()
    {
        return _formRepository.GetAll();
    }

    public IQueryable<Form?> GetAllByJobId(int id)
    {
        return _formRepository.GetAllByJobId(id);
    }

    public async Task<Form?> GetByIdAsync(int id)
    {
        return await _formRepository.GetByIdAsync(id);
    }

    public async Task<bool> AddAsync(Form pm)
    {
        var dm = await _unitOfWork.JobRepository.GetByIdAsync(pm.JobId);
        if (dm != null)
            return await _formRepository.AddAsync(pm);
        return false;
    }

    public async Task<bool> UpdateAsync(Form pm)
    {
        var dm = await _unitOfWork.JobRepository.GetByIdAsync(pm.JobId);
        if (dm != null)
        {

            var oldImage = await _formRepository.GetByIdAsync(pm.Id);
            var oldimagePath = oldImage.CV.Split('/').Last();
            string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", oldimagePath);

            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }

            return await _formRepository.UpdateAsync(pm);
        }
        return false;
    }

    public async Task<bool> DeleteAsync(Form pm)
    {
        var oldImage = await _formRepository.GetByIdAsync(pm.Id);
        var oldimagePath = oldImage.CV.Split('/').Last();
        string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", oldimagePath);

        if (File.Exists(imagePath))
        {
            File.Delete(imagePath);
        }

        return await _formRepository.DeleteAsync(pm);
    }
    #endregion
}

