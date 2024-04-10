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
    #endregion

    #region Handle Functions
    public IQueryable<Project?> GetAllByCompanyId(int id)
    {
        return _projects.Where(x => x.CompanyId == id)
            .AsNoTracking()
            .AsQueryable();
    }
    #endregion
}
