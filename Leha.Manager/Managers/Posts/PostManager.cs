using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Posts;
using Leha.Infrastructure.UnitOfWorks;

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

    public IQueryable<Post?> GetAll()
    {
        return _postRepository.GetAll();
    }

    public IQueryable<Post?> GetAllByCompanyId(int id)
    {
        return _postRepository.GetAllByCompanyId(id);
    }

    public async Task<Post?> GetByIdAsync(int id)
    {
        return await _postRepository.GetByIdAsync(id);
    }

    public async Task<bool> AddAsync(Post pm)
    {
        var dm = await _unitOfWork.CompanyRepository.GetByIdAsync(pm.CompanyId);
        if (dm != null)
            return await _postRepository.AddAsync(pm);
        return false;
    }
    public async Task<bool> UpdateAsync(Post pm)
    {
        var dm = await _unitOfWork.CompanyRepository.GetByIdAsync(pm.CompanyId);
        if (dm != null)
            return await _postRepository.UpdateAsync(pm);
        return false;
    }

    public async Task<bool> DeleteAsync(Post pm)
    {
        return await _postRepository.DeleteAsync(pm);
    }
    #endregion
}
