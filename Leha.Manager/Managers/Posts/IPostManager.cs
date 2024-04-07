using Leha.Data.Entities;

namespace Leha.Manager.Managers.Posts;

public interface IPostManager
{
    public IQueryable<Post?> GetPostsListAsync();
    public IQueryable<Post?> GetPostsListByCompanyId(int id);
    public Task<Post?> GetPostByIDAsync(int id);
    public Task<bool> AddPostAsync(Post pm);
    public Task<bool> UpdatePostAsync(Post pm);
    public Task<bool> DeletePostAsync(Post pm);
}
