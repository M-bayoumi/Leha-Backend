﻿using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Generic;

namespace Leha.Infrastructure.Repositories.ProjectPhases;

public interface IProjectPhaseRepository : IGenericRepository<ProjectPhase>
{
    public IQueryable<ProjectPhase?> GetAllByProjectID(int id);

}
