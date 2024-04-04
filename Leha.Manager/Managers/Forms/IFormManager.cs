using Leha.Data.Entities;

namespace Leha.Manager.Managers.Forms;

public interface IFormManager
{
    public IQueryable<Form?> GetFormsListAsync();
    public IQueryable<Form?> GetFormsListByJobId(int jobID);
    public Task<Form?> GetFormByIDAsync(int formID);
    public Task<bool> AddFormAsync(Form form);
    public Task<bool> UpdateFormAsync(Form form);
    public Task<bool> DeleteFormAsync(Form form);
}

