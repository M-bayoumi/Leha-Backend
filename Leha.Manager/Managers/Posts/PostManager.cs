using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Posts;
using Leha.Infrastructure.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace Leha.Manager.Managers.Posts;

public class PostManager : IPostManager
{
    #region Fields
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostRepository _postRepository;
    #endregion

    #region Constructors
    public PostManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _postRepository = unitOfWork.PostRepository;
    }

    #endregion

    #region Handle Functions

    public IQueryable<Post?> GetPostsListAsync()
    {
        return _postRepository.GetTableNoTracking().AsQueryable();
    }

    public IQueryable<Post?> GetPostsListByCompanyId(int companyID)
    {
        return _postRepository.GetPostsListByCompanyId(companyID).AsQueryable();
    }
    public async Task<Post?> GetPostByIDAsync(int postID)
    {
        return await _postRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.ID == postID);
    }

    public async Task<bool> AddPostItemAsync(Post post)
    {
        return await _postRepository.AddAsync(post);
    }
    public async Task<bool> UpdatePostItemAsync(Post post)
    {
        return await _postRepository.UpdateAsync(post);
    }

    public async Task<bool> DeletePostItemAsync(Post post)
    {
        return await _postRepository.DeleteAsync(post);
    }

    #endregion
}
