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

    public IQueryable<Post?> GetPostsListByCompanyId(int id)
    {
        return _postRepository.GetPostsListByCompanyId(id).AsQueryable();
    }
    public async Task<Post?> GetPostByIDAsync(int id)
    {
        return await _postRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.ID == id);
    }

    public async Task<bool> AddPostAsync(Post pm)
    {
        return await _postRepository.AddAsync(pm);
    }
    public async Task<bool> UpdatePostAsync(Post pm)
    {
        return await _postRepository.UpdateAsync(pm);
    }

    public async Task<bool> DeletePostAsync(Post pm)
    {
        return await _postRepository.DeleteAsync(pm);
    }

    #endregion
}
