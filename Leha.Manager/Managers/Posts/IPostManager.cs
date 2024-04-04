using Leha.Data.Entities;

namespace Leha.Manager.Managers.Posts;

public interface IPostManager
{
    public IQueryable<Post?> GetPostsListAsync();
    public IQueryable<Post?> GetPostsListByCompanyId(int companyID);
    public Task<Post?> GetPostByIDAsync(int postID);
    public Task<bool> AddPostItemAsync(Post post);
    public Task<bool> UpdatePostItemAsync(Post post);
    public Task<bool> DeletePostItemAsync(Post post);
}
