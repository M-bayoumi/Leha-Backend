using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Companies;
using Leha.Infrastructure.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace Leha.Manager.Managers.Companies;

public class CompanyManager : ICompanyManager
{
    #region Fields
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICompanyRepository _companyRepository;
    #endregion

    #region Constructors
    public CompanyManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _companyRepository = unitOfWork.CompanyRepository;
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
        return await _companyRepository.UpdateAsync(pm);
    }

    public async Task<bool> DeleteAsync(Company pm)
    {
        var transaction = _companyRepository.BeginTransaction();
        try
        {
            var dms_project = _unitOfWork.ProjectRepository.GetAllByCompanyID(pm.ID).ToList();
            if (dms_project != null)
                await _unitOfWork.ProjectRepository.DeleteRangeAsync(dms_project);

            var dms_service = _unitOfWork.ServiceRepository.GetAllByCompanyID(pm.ID).ToList();
            if (dms_service != null)
                await _unitOfWork.ServiceRepository.DeleteRangeAsync(dms_service);


            var dms_product = _unitOfWork.ProductRepository.GetAllByCompanyID(pm.ID).ToList();
            if (dms_product != null)
                await _unitOfWork.ProductRepository.DeleteRangeAsync(dms_product);


            var dms_homeImage = _unitOfWork.HomeImageRepository.GetAllByCompanyID(pm.ID).ToList();
            if (dms_homeImage != null)
                await _unitOfWork.HomeImageRepository.DeleteRangeAsync(dms_homeImage);

            var dms_address = _unitOfWork.CompanyAddressRepository.GetAllByCompanyID(pm.ID).ToList();
            if (dms_address != null)
                await _unitOfWork.CompanyAddressRepository.DeleteRangeAsync(dms_address);

            var dms_post = _unitOfWork.PostRepository.GetAllByCompanyID(pm.ID).ToList();
            if (dms_post != null)
                await _unitOfWork.PostRepository.DeleteRangeAsync(dms_post);

            var dms_postClients = _unitOfWork.ClientRepository.GetAllByCompanyID(pm.ID).ToList();
            if (dms_postClients != null)
                await _unitOfWork.ClientRepository.DeleteRangeAsync(dms_postClients);

            var dms_jobs = _unitOfWork.JobRepository.GetAllByCompanyID(pm.ID).ToList();
            if (dms_jobs != null)
                await _unitOfWork.JobRepository.DeleteRangeAsync(dms_jobs);


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

    public async Task<bool> IsNameExist(string name)
    {
        var isNameExist = await _companyRepository.GetAll().AnyAsync(x => x!.CompanyName == name);
        return isNameExist;
    }

    public async Task<bool> IsNameExistExludeSelf(string name, int id)
    {
        var isNameExist = await _companyRepository.GetAll().AnyAsync(x => x!.CompanyName == name && x.ID != id);
        return isNameExist;
    }
    #endregion
}

