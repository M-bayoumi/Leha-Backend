using Leha.Data.Entities;

namespace Leha.Manager.Managers.Jobs;

public interface IJobManager
{
    public IQueryable<Job?> GetAll();
    public IQueryable<Job?> GetAllByCompanyID(int id);
    public Task<Job?> GetByIdAsync(int id);
    public Task<bool> AddAsync(Job pm);
    public Task<bool> UpdateAsync(Job pm);
    public Task<bool> DeleteAsync(Job pm);
}
