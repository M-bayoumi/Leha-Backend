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

    public async Task<List<Company?>> GetCompaniesListAsync()
    {
        return await _companyRepository.GetTableNoTracking().ToListAsync();
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
        var trans = _companyRepository.BeginTransaction();
        try
        {
            //company.RemoveAllPosts();
            await _companyRepository.DeleteAsync(company);
            await trans.CommitAsync();
            return true;
        }
        catch
        {
            await trans.RollbackAsync();
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

