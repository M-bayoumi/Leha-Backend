using Leha.Data.Entities;
using Leha.Infrastructure.Context;
using Leha.Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Leha.Infrastructure.Repositories.ProjectPhases;


public class ProjectPhaseRepository : GenericRepository<ProjectPhase>, IProjectPhaseRepository
{
    #region Fields
    private readonly DbSet<ProjectPhase> _projectPhases;
    #endregion

    #region Constructors
    public ProjectPhaseRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _projectPhases = appDbContext.Set<ProjectPhase>();
    }

    #endregion

    #region Handle Functions
    public async Task<List<ProjectPhase?>> GetProjectPhasesListByProjectId(int projectID)
    {
        return await _projectPhases.Where(x => x.ProjectID == projectID).ToListAsync();
    }

    #endregion
}
