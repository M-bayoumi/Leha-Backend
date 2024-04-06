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
    public IQueryable<PhaseItem?> GetPhaseItemsListAsync()
    {
        return _phaseItemRepository.GetTableNoTracking().AsQueryable();
    }

    public IQueryable<PhaseItem?> GetPhaseItemsListByProjectPhaseId(int projectPhaseID)
    {
        return _phaseItemRepository.GetPhaseItemsListByProjectPhaseId(projectPhaseID).AsQueryable();
    }

    public async Task<PhaseItem?> GetPhaseItemByIDAsync(int phaseItemID)
    {
        return await _phaseItemRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.ID == phaseItemID);
    }

    public async Task<bool> AddPhaseItemAsync(PhaseItem phaseItem)
    {
        var projectPhase = _unitOfWork.ProjectPhaseRepository.GetTableNoTracking().FirstOrDefault(x => x.ID == phaseItem.ProjectPhaseID);
        if (projectPhase == null) return false;

        var project = _unitOfWork.ProjectRepository.GetTableAsTracking().Include(x => x.ProjectPhases).ThenInclude(x => x.PhaseItems).FirstOrDefault(x => x.ID == projectPhase.ProjectID);
        if (project == null) return false;

        var totalAcumulativePercentage = project.ProjectPhases
            .SelectMany(x => x.PhaseItems)
            .Sum(c => c.AcumulativePercentage);

        if (totalAcumulativePercentage > 100) return false;
        phaseItem.PercentageLossOrExceed = (phaseItem.InitialInventoryQuantities - phaseItem.ActualInventoryQuantities) * 100 / phaseItem.InitialInventoryQuantities;

        var transaction = _phaseItemRepository.BeginTransaction();
        try
        {
            await _phaseItemRepository.AddAsync(phaseItem);
            project.ProjectProgressPercentage = project.ProjectPhases
                .SelectMany(x => x.PhaseItems)
                .Sum(c => c.AcumulativePercentage * c.ProgressPercentage / 100);
            await _unitOfWork.ProjectRepository.SaveChangesAsync();
            await transaction.CommitAsync();

            return true;
        }
        catch
        {
            await transaction.RollbackAsync();
            return false;
        }
    }

    public async Task<bool> UpdatePhaseItemAsync(PhaseItem phaseItem)
    {
        var projectPhase = _unitOfWork.ProjectPhaseRepository.GetTableNoTracking().FirstOrDefault(x => x.ID == phaseItem.ProjectPhaseID);
        if (projectPhase == null) return false;

        var project = _unitOfWork.ProjectRepository.GetTableAsTracking().Include(x => x.ProjectPhases).ThenInclude(x => x.PhaseItems).FirstOrDefault(x => x.ID == projectPhase.ProjectID);
        if (project == null) return false;

        var totalAcumulativePercentage = project.ProjectPhases
            .SelectMany(x => x.PhaseItems)
            .Sum(c => c.AcumulativePercentage);

        if (totalAcumulativePercentage > 100) return false;
        phaseItem.PercentageLossOrExceed = (phaseItem.InitialInventoryQuantities - phaseItem.ActualInventoryQuantities) * 100 / phaseItem.InitialInventoryQuantities;

        var transaction = _phaseItemRepository.BeginTransaction();
        try
        {
            await _phaseItemRepository.UpdateAsync(phaseItem);
            project.ProjectProgressPercentage = project.ProjectPhases
                .SelectMany(x => x.PhaseItems)
                .Sum(c => c.AcumulativePercentage * c.ProgressPercentage / 100);
            await _unitOfWork.ProjectRepository.SaveChangesAsync();
            await transaction.CommitAsync();

            return true;
        }
        catch
        {
            await transaction.RollbackAsync();
            return false;
        }
    }

    public async Task<bool> DeletePhaseItemAsync(PhaseItem phaseItem)
    {
        return await _unitOfWork.PhaseItemRepository.DeleteAsync(phaseItem);
    }
    #endregion
}
