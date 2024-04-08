using Leha.Data.Entities;

namespace Leha.Manager.Managers.Posts;

public interface IPostManager
{
    public IQueryable<Post?> GetAll();
    public IQueryable<Post?> GetAllByCompanyID(int id);
    public Task<Post?> GetByIdAsync(int id);
    public Task<bool> AddAsync(Post pm);
    public Task<bool> UpdateAsync(Post pm);
    public Task<bool> DeleteAsync(Post pm);
}
