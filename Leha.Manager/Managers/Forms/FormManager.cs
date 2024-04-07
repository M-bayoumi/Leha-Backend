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
    public IQueryable<Form?> GetFormsListAsync()
    {
        return _formRepository.GetTableNoTracking().AsQueryable();
    }

    public IQueryable<Form?> GetFormsListByJobId(int id)
    {
        return _formRepository.GetFormsListByJobId(id).AsQueryable();
    }
    public async Task<Form?> GetFormByIDAsync(int id)
    {
        return await _formRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.ID == id);
    }

    public async Task<bool> AddFormAsync(Form pm)
    {
        // check job exist
        return await _formRepository.AddAsync(pm);
    }
    public async Task<bool> UpdateFormAsync(Form pm)
    {
        return await _formRepository.UpdateAsync(pm);
    }

    public async Task<bool> DeleteFormAsync(Form pm)
    {
        return await _formRepository.DeleteAsync(pm);
    }
    #endregion
}

