using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Posts;
using Leha.Infrastructure.UnitOfWorks;
using Microsoft.AspNetCore.Hosting;

namespace Leha.Manager.Managers.Posts;

public class PostManager : IPostManager
{
    #region Fields
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostRepository _postRepository;
    private readonly IWebHostEnvironment _webHostEnvironment;
    #endregion

    #region Constructors
    public PostManager(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _postRepository = unitOfWork.PostRepository;
        _webHostEnvironment = webHostEnvironment;
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
        {

            var oldImage = await _postRepository.GetByIdAsync(pm.Id);
            var oldimagePath = oldImage.Image.Split('/').Last();
            string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", oldimagePath);

            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }

            return await _postRepository.UpdateAsync(pm);
        }
        return false;
    }

    public async Task<bool> DeleteAsync(Post pm)
    {
        var oldImage = await _postRepository.GetByIdAsync(pm.Id);
        var oldimagePath = oldImage.Image.Split('/').Last();
        string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", oldimagePath);

        if (File.Exists(imagePath))
        {
            File.Delete(imagePath);
        }

        return await _postRepository.DeleteAsync(pm);
    }
    #endregion
}
