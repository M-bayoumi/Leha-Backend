using Leha.Data.Entities;

namespace Leha.Manager.Managers.PhaseItems;

public interface IPhaseItemManager
{
    public IQueryable<PhaseItem?> GetPhaseItemsListAsync();
    public IQueryable<PhaseItem?> GetPhaseItemsListByProjectPhaseId(int projectPhaseID);
    public Task<PhaseItem?> GetPhaseItemByIDAsync(int phaseItemID);
    public Task<bool> AddPhaseItemAsync(PhaseItem phaseItem);
    public Task<bool> UpdatePhaseItemAsync(PhaseItem phaseItem);
    public Task<bool> DeletePhaseItemAsync(PhaseItem phaseItem);
}
