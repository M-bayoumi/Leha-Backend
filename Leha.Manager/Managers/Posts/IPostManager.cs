using Leha.Data.Entities;

namespace Leha.Manager.Managers.Posts;

public interface IPostManager
{
    public Task<List<Post?>> GetPostsListAsync();
    public Task<List<Post?>> GetPostsListByCompanyId(int companyID);
    public Task<Post?> GetPostByIDAsync(int postID);
    public Task<bool> AddPostItemAsync(Post post);
    public Task<bool> UpdatePostItemAsync(Post post);
    public Task<bool> DeletePostItemAsync(Post post);
}
