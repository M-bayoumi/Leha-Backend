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

    public IQueryable<Company?> GetCompaniesListAsync()
    {
        return _companyRepository.GetTableNoTracking().AsQueryable();
    }

    public async Task<Company?> GetCompanyByIDAsync(int id)
    {
        var company = await _companyRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.ID == id);
        return company;
    }

    public async Task<bool> AddCompanyAsync(Company pm)
    {
        return await _companyRepository.AddAsync(pm);
    }
    public async Task<bool> UpdateCompanyAsync(Company pm)
    {
        return await _companyRepository.UpdateAsync(pm);
    }

    public async Task<bool> DeleteCompanyAsync(Company pm)
    {
        var transaction = _companyRepository.BeginTransaction();
        try
        {

            var dms_project = _unitOfWork.ProjectRepository.GetProjectsListByCompanyId(pm.ID).ToList();

            if (dms_project != null)
                await _unitOfWork.ProjectRepository.DeleteRangeAsync(dms_project);

            var dms_service = _unitOfWork.ServiceRepository.GetServicesListByCompanyId(pm.ID).ToList();

            if (dms_service != null)
                await _unitOfWork.ServiceRepository.DeleteRangeAsync(dms_service);


            var dms_product = _unitOfWork.ProductRepository.GetProductsListByCompanyId(pm.ID).ToList();

            if (dms_product != null)
                await _unitOfWork.ProductRepository.DeleteRangeAsync(dms_product);


            var dms_homeImage = _unitOfWork.HomeImageRepository.GetHomeImagesListByCompanyId(pm.ID).ToList();

            if (dms_homeImage != null)
                await _unitOfWork.HomeImageRepository.DeleteRangeAsync(dms_homeImage);

            var dms_address = _unitOfWork.CompanyAddressRepository.GetCompanyAddressesListByCompanyId(pm.ID).ToList();

            if (dms_address != null)
                await _unitOfWork.CompanyAddressRepository.DeleteRangeAsync(dms_address);

            var dms_post = _unitOfWork.PostRepository.GetPostsListByCompanyId(pm.ID).ToList();

            if (dms_post != null)
                await _unitOfWork.PostRepository.DeleteRangeAsync(dms_post);

            var dms_postClients = _unitOfWork.ClientRepository.GetClientsListByCompanyId(pm.ID).ToList();

            if (dms_postClients != null)
                await _unitOfWork.ClientRepository.DeleteRangeAsync(dms_postClients);

            var dms_jobs = _unitOfWork.JobRepository.GetJobsListByCompanyId(pm.ID).ToList();

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
        var isNameExist = await _companyRepository.GetTableNoTracking().AnyAsync(x => x!.CompanyName == name);
        return isNameExist;
    }

    public async Task<bool> IsNameExistExludeSelf(string name, int id)
    {
        var isNameExist = await _companyRepository.GetTableNoTracking().AnyAsync(x => x!.CompanyName == name && x.ID != id);
        return isNameExist;
    }

    #endregion
}

