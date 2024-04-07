using Leha.Data.Entities;

namespace Leha.Manager.Managers.Forms;

public interface IFormManager
{
    public IQueryable<Form?> GetFormsListAsync();
    public IQueryable<Form?> GetFormsListByJobId(int id);
    public Task<Form?> GetFormByIDAsync(int id);
    public Task<bool> AddFormAsync(Form pm);
    public Task<bool> UpdateFormAsync(Form pm);
    public Task<bool> DeleteFormAsync(Form pm);
}

