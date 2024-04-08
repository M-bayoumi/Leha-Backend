using Leha.Data.Entities;

namespace Leha.Manager.Managers.Forms;

public interface IFormManager
{
    public IQueryable<Form?> GetAll();
    public IQueryable<Form?> GetAllByJobID(int id);
    public Task<Form?> GetByIdAsync(int id);
    public Task<bool> AddAsync(Form pm);
    public Task<bool> UpdateAsync(Form pm);
    public Task<bool> DeleteAsync(Form pm);
}

