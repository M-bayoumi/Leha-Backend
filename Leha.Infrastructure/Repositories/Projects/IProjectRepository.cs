using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Generic;

namespace Leha.Infrastructure.Repositories.Projects;

public interface IProjectRepository : IGenericRepository<Project>
{
    public IQueryable<Project?> GetProjectsListByCompanyId(int id);

}
