﻿using Leha.Data.Entities;
using Leha.Infrastructure.Context;
using Leha.Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace Leha.Infrastructure.Repositories.PhaseItems;


public class PhaseItemRepository : GenericRepository<PhaseItem>, IPhaseItemRepository
{
    #region Fields
    private readonly DbSet<PhaseItem> _phaseItems;
    #endregion

    #region Constructors
    public PhaseItemRepository(AppDbContext appDbContext) : base(appDbContext)
    {

        _phaseItems = appDbContext.Set<PhaseItem>();
    }
    #endregion

    #region Handle Functions
    public IQueryable<PhaseItem?> GetAllByProjectPhaseID(int id)
    {
        return _phaseItems.Where(x => x.ProjectPhaseId == id)
            .AsNoTracking()
            .AsQueryable();
    }
    #endregion
}
