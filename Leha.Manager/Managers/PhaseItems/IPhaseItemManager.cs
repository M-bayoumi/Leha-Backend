using Leha.Data.Entities;

namespace Leha.Manager.Managers.PhaseItems;

public interface IPhaseItemManager
{
    public IQueryable<PhaseItem?> GetPhaseItemsListAsync();
    public IQueryable<PhaseItem?> GetPhaseItemsListByProjectPhaseId(int id);
    public Task<PhaseItem?> GetPhaseItemByIDAsync(int id);
    public Task<bool> AddPhaseItemAsync(PhaseItem pm);
    public Task<bool> UpdatePhaseItemAsync(PhaseItem pm);
    public Task<bool> DeletePhaseItemAsync(PhaseItem pm);
}
