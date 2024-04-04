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

    public async Task<Company?> GetCompanyByIDAsync(int companyID)
    {
        var company = await _companyRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.ID == companyID);
        return company;
    }

    public async Task<bool> AddCompanyAsync(Company company)
    {
        return await _companyRepository.AddAsync(company);
    }
    public async Task<bool> UpdateCompanyAsync(Company company)
    {
        return await _companyRepository.UpdateAsync(company);
    }

    public async Task<bool> DeleteCompanyAsync(Company company)
    {
        var transaction = _companyRepository.BeginTransaction();
        try
        {
            var companyProjects = _unitOfWork.ProjectRepository.GetProjectsListByCompanyId(company.ID).ToList();

            if (companyProjects != null)
                await _unitOfWork.ProjectRepository.DeleteRangeAsync(companyProjects);

            var companyServices = _unitOfWork.ServiceRepository.GetServicesListByCompanyId(company.ID).ToList();

            if (companyServices != null)
                await _unitOfWork.ServiceRepository.DeleteRangeAsync(companyServices);


            var companyProducts = _unitOfWork.ProductRepository.GetProductsListByCompanyId(company.ID).ToList();

            if (companyProducts != null)
                await _unitOfWork.ProductRepository.DeleteRangeAsync(companyProducts);


            var companyHomeImages = _unitOfWork.HomeImageRepository.GetHomeImagesListByCompanyId(company.ID).ToList();

            if (companyHomeImages != null)
                await _unitOfWork.HomeImageRepository.DeleteRangeAsync(companyHomeImages);

            var companyAddresss = _unitOfWork.CompanyAddressRepository.GetCompanyAddressesListByCompanyId(company.ID).ToList();

            if (companyAddresss != null)
                await _unitOfWork.CompanyAddressRepository.DeleteRangeAsync(companyAddresss);

            var companyPosts = _unitOfWork.PostRepository.GetPostsListByCompanyId(company.ID).ToList();

            if (companyPosts != null)
                await _unitOfWork.PostRepository.DeleteRangeAsync(companyPosts);

            var companyClients = _unitOfWork.ClientRepository.GetClientsListByCompanyId(company.ID).ToList();

            if (companyClients != null)
                await _unitOfWork.ClientRepository.DeleteRangeAsync(companyClients);

            var companyJobs = _unitOfWork.JobRepository.GetJobsListByCompanyId(company.ID).ToList();

            if (companyJobs != null)
                await _unitOfWork.JobRepository.DeleteRangeAsync(companyJobs);


            await _companyRepository.DeleteAsync(company);

            await transaction.CommitAsync();

            return true;
        }
        catch
        {
            await transaction.RollbackAsync();
            return false;
        }
    }

    public async Task<bool> IsNameExist(string companyName)
    {
        var isNameExist = await _companyRepository.GetTableNoTracking().AnyAsync(x => x!.CompanyName == companyName);
        return isNameExist;
    }

    public async Task<bool> IsNameExistExludeSelf(string companyName, int id)
    {
        var isNameExist = await _companyRepository.GetTableNoTracking().AnyAsync(x => x!.CompanyName == companyName && x.ID != id);
        return isNameExist;
    }

    #endregion
}

