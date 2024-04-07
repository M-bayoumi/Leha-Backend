using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.Generic;

namespace Leha.Infrastructure.Repositories.PhaseItems;

public interface IPhaseItemRepository : IGenericRepository<PhaseItem>
{
    public IQueryable<PhaseItem?> GetPhaseItemsListByProjectPhaseId(int id);
}