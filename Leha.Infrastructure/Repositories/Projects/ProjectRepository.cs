using Leha.Data.Entities;
using Leha.Infrastructure.Context;
using Leha.Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Leha.Infrastructure.Repositories.Projects;


public class ProjectRepository : GenericRepository<Project>, IProjectRepository
{
    #region Fields
    private readonly DbSet<Project> _projects;
    #endregion

    #region Constructors
    public ProjectRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _projects = appDbContext.Set<Project>();
    }

    public async Task<List<Project?>> GetProjectsListByCompanyId(int companyID)
    {
        return await _projects.Where(x => x.CompanyID == companyID).ToListAsync();
    }

    #endregion

    #region Handle Functions

    #endregion
}
