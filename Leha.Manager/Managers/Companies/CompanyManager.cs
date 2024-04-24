using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Companies;
using Leha.Infrastructure.UnitOfWorks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Leha.Manager.Managers.Companies;

public class CompanyManager : ICompanyManager
{
    #region Fields
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICompanyRepository _companyRepository;
    private readonly IWebHostEnvironment _webHostEnvironment;

    #endregion

    #region Constructors
    public CompanyManager(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _companyRepository = unitOfWork.CompanyRepository;
        _webHostEnvironment = webHostEnvironment;

    }

    #endregion

    #region Handle Functions

    public IQueryable<Company?> GetAll()
    {
        return _companyRepository.GetAll();
    }

    public async Task<Company?> GetByIdAsync(int id)
    {
        var dm = await _companyRepository.GetByIdAsync(id);
        return dm;
    }

    public async Task<bool> AddAsync(Company pm)
    {
        return await _companyRepository.AddAsync(pm);
    }

    public async Task<bool> UpdateAsync(Company pm)
    {

        var oldImage = await _companyRepository.GetByIdAsync(pm.Id);
        var oldimagePath = oldImage.Image.Split('/').Last();
        string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", oldimagePath);

        if (File.Exists(imagePath))
        {
            File.Delete(imagePath);
        }

        return await _companyRepository.UpdateAsync(pm);

    }

    public async Task<bool> DeleteAsync(Company pm)
    {
        var transaction = _companyRepository.BeginTransaction();
        try
        {
            var dms_project = _unitOfWork.ProjectRepository.GetAllByCompanyId(pm.Id).ToList();
            if (dms_project != null)
                await _unitOfWork.ProjectRepository.DeleteRangeAsync(dms_project);

            var dms_service = _unitOfWork.ServiceRepository.GetAllByCompanyId(pm.Id).ToList();
            if (dms_service != null)
                await _unitOfWork.ServiceRepository.DeleteRangeAsync(dms_service);


            var dms_product = _unitOfWork.ProductRepository.GetAllByCompanyId(pm.Id).ToList();
            if (dms_product != null)
                await _unitOfWork.ProductRepository.DeleteRangeAsync(dms_product);


            var dms_homeImage = _unitOfWork.HomeImageRepository.GetAllByCompanyId(pm.Id).ToList();
            if (dms_homeImage != null)
                await _unitOfWork.HomeImageRepository.DeleteRangeAsync(dms_homeImage);

            var dms_address = _unitOfWork.CompanyAddressRepository.GetAllByCompanyId(pm.Id).ToList();
            if (dms_address != null)
                await _unitOfWork.CompanyAddressRepository.DeleteRangeAsync(dms_address);

            var dms_post = _unitOfWork.PostRepository.GetAllByCompanyId(pm.Id).ToList();
            if (dms_post != null)
                await _unitOfWork.PostRepository.DeleteRangeAsync(dms_post);

            var dms_postClients = _unitOfWork.ClientRepository.GetAllByCompanyId(pm.Id).ToList();
            if (dms_postClients != null)
                await _unitOfWork.ClientRepository.DeleteRangeAsync(dms_postClients);

            var dms_jobs = _unitOfWork.JobRepository.GetAllByCompanyId(pm.Id).ToList();
            if (dms_jobs != null)
                await _unitOfWork.JobRepository.DeleteRangeAsync(dms_jobs);


            var oldImage = await _companyRepository.GetByIdAsync(pm.Id);
            var oldimagePath = oldImage.Image.Split('/').Last();
            string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", oldimagePath);

            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }
            await _companyRepository.DeleteAsync(pm);
            await transaction.CommitAsync();

            return true;
        }
        catch
        {
            await transaction.RollbackAsync();
            return false;
        }
    }

    public async Task<bool> IsNameArExist(string nameAr)
    {
        var isNameExist = await _companyRepository.GetAll().AnyAsync(x => x!.NameAr == nameAr);
        return isNameExist;
    }

    public async Task<bool> IsNameEnExist(string nameEn)
    {
        var isNameExist = await _companyRepository.GetAll().AnyAsync(x => x!.NameEn == nameEn);
        return isNameExist;
    }

    public async Task<bool> IsNameArExistExludeSelf(string nameAr, int id)
    {
        var isNameExist = await _companyRepository.GetAll().AnyAsync(x => x!.NameAr == nameAr && x.Id != id);
        return isNameExist;
    }

    public async Task<bool> IsNameEnExistExludeSelf(string nameEn, int id)
    {
        var isNameExist = await _companyRepository.GetAll().AnyAsync(x => x!.NameEn == nameEn && x.Id != id);
        return isNameExist;
    }


    #endregion
}

