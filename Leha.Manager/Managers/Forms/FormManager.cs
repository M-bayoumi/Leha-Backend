using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Forms;
using Leha.Infrastructure.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace Leha.Manager.Managers.Forms;

public class FormManager : IFormManager
{
    #region Fields
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFormRepository _formRepository;
    #endregion

    #region Constructors
    public FormManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _formRepository = unitOfWork.FormRepository;
    }


    #endregion

    #region Handle Functions
    public async Task<List<Form?>> GetFormsListAsync()
    {
        return await _formRepository.GetTableNoTracking().ToListAsync();
    }

    public async Task<List<Form>?> GetFormsListByJobId(int jobID)
    {
        return await _formRepository.GetFormsListByJobId(jobID);
    }
    public async Task<Form?> GetFormByIDAsync(int formID)
    {
        return await _formRepository.GetByIdAsync(formID);
    }


    public async Task<bool> AddFormAsync(Form form)
    {
        return await _formRepository.AddAsync(form);
    }
    public async Task<bool> UpdateFormAsync(Form form)
    {
        return await _formRepository.UpdateAsync(form);
    }


    public async Task<bool> DeleteFormAsync(Form form)
    {
        return await _formRepository.DeleteAsync(form);
    }
    #endregion
}

