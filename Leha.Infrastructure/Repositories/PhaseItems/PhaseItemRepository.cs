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
    public async Task<List<PhaseItem?>> GetPhaseItemsListByProjectPhaseId(int projectPhaseID)
    {
        return await _phaseItems.Where(x => x.ProjectPhaseID == projectPhaseID).ToListAsync();
    }
    #endregion
}
