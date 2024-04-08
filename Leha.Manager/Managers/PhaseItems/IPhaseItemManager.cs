using Leha.Data.Entities;

namespace Leha.Manager.Managers.PhaseItems;

public interface IPhaseItemManager
{
    public IQueryable<PhaseItem?> GetAll();
    public IQueryable<PhaseItem?> GetAllByProjectPhaseID(int id);
    public Task<PhaseItem?> GetByIdAsync(int id);
    public Task<bool> AddAsync(PhaseItem pm);
    public Task<bool> UpdateAsync(PhaseItem pm);
    public Task<bool> DeleteAsync(PhaseItem pm);
}
