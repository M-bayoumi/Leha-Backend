using Leha.Data.Entities;
using Leha.Infrastructure.Repositories.PhaseItems;
using Leha.Infrastructure.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace Leha.Manager.Managers.PhaseItems;

public class PhaseItemManager : IPhaseItemManager
{
    #region Fields
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPhaseItemRepository _phaseItemRepository;
    #endregion

    #region Constructors
    public PhaseItemManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _phaseItemRepository = unitOfWork.PhaseItemRepository;
    }

    #endregion

    #region Handle Functions
    public async Task<List<PhaseItem?>> GetPhaseItemsListAsync()
    {
        return await _phaseItemRepository.GetTableNoTracking().ToListAsync();
    }

    public async Task<List<PhaseItem>?> GetPhaseItemsListByProjectPhaseId(int projectPhaseID)
    {
        return await _phaseItemRepository.GetPhaseItemsListByProjectPhaseId(projectPhaseID);
    }

    public async Task<PhaseItem?> GetPhaseItemByIDAsync(int phaseItemID)
    {
        return await _phaseItemRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.ID == phaseItemID);
    }

    public async Task<bool> AddPhaseItemAsync(PhaseItem phaseItem)
    {
        return await _phaseItemRepository.AddAsync(phaseItem);
    }

    public async Task<bool> UpdatePhaseItemAsync(PhaseItem phaseItem)
    {
        return await _phaseItemRepository.UpdateAsync(phaseItem);
    }

    public async Task<bool> DeletePhaseItemAsync(PhaseItem phaseItem)
    {
        return await _unitOfWork.PhaseItemRepository.DeleteAsync(phaseItem);
    }
    #endregion
}
