using Leha.Data.Entities;

namespace Leha.Manager.Managers.PhaseItems;

public interface IPhaseItemManager
{
    public Task<List<PhaseItem?>> GetPhaseItemsListAsync();
    public Task<List<PhaseItem?>> GetPhaseItemsListByProjectPhaseId(int projectPhaseID);
    public Task<PhaseItem?> GetPhaseItemByIDAsync(int phaseItemID);
    public Task<bool> AddPhaseItemAsync(PhaseItem phaseItem);
    public Task<bool> UpdatePhaseItemAsync(PhaseItem phaseItem);
    public Task<bool> DeletePhaseItemAsync(PhaseItem phaseItem);
}
