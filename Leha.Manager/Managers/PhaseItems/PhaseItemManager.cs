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
    public IQueryable<PhaseItem?> GetAll()
    {
        return _phaseItemRepository.GetAll();
    }

    public IQueryable<PhaseItem?> GetAllByProjectPhaseID(int id)
    {
        return _phaseItemRepository.GetAllByProjectPhaseID(id);
    }

    public async Task<PhaseItem?> GetByIdAsync(int id)
    {
        return await _phaseItemRepository.GetByIdAsync(id);
    }

    public async Task<bool> AddAsync(PhaseItem pm)
    {
        var dm_projectPhase = await _unitOfWork.ProjectPhaseRepository.GetAll().Include(x => x.PhaseItems).FirstOrDefaultAsync(x => x.Id == pm.ProjectPhaseId);
        if (dm_projectPhase == null) return false;

        var dm_project = _unitOfWork.ProjectRepository
            .GetAll()
            .Include(x => x.ProjectPhases)
            .ThenInclude(x => x.PhaseItems)
            .FirstOrDefault(x => x.Id == dm_projectPhase.ProjectId);

        if (dm_project == null) return false;

        var totalAcumulativePercentage = dm_project.ProjectPhases
            .SelectMany(x => x.PhaseItems)
            .Sum(c => c.AcumulativePercentage);

        if (totalAcumulativePercentage > 100) return false;
        pm.PercentageLossOrExceed = (pm.InitialInventoryQuantities - pm.ActualInventoryQuantities) * 100 / pm.InitialInventoryQuantities;

        var transaction = _phaseItemRepository.BeginTransaction();
        try
        {
            await _phaseItemRepository.AddAsync(pm);
            await _phaseItemRepository.SaveChangesAsync();
            dm_project.ProjectProgressPercentage = dm_project.ProjectPhases
                .SelectMany(x => x.PhaseItems)
                .Sum(c => (c.AcumulativePercentage * c.ProgressPercentage) / 100);

            await _unitOfWork.ProjectRepository
                .UpdateAsync(dm_project);
            await transaction.CommitAsync();

            return true;
        }
        catch
        {
            await transaction.RollbackAsync();
            return false;
        }
    }

    public async Task<bool> UpdateAsync(PhaseItem pm)
    {
        var dm_projectPhase = await _unitOfWork.ProjectPhaseRepository.GetAll().Include(x => x.PhaseItems).FirstOrDefaultAsync(x => x.Id == pm.ProjectPhaseId);
        if (dm_projectPhase == null) return false;

        var dm_project = _unitOfWork.ProjectRepository
            .GetAll()
            .Include(x => x.ProjectPhases)
            .ThenInclude(x => x.PhaseItems)
            .FirstOrDefault(x => x.Id == dm_projectPhase.ProjectId);

        if (dm_project == null) return false;

        var totalAcumulativePercentage = dm_project.ProjectPhases
            .SelectMany(x => x.PhaseItems)
            .Sum(c => c.AcumulativePercentage);

        if (totalAcumulativePercentage > 100) return false;
        pm.PercentageLossOrExceed = (pm.InitialInventoryQuantities - pm.ActualInventoryQuantities) * 100 / pm.InitialInventoryQuantities;

        var transaction = _phaseItemRepository.BeginTransaction();
        try
        {
            await _phaseItemRepository.UpdateAsync(pm);
            await _phaseItemRepository.SaveChangesAsync();
            dm_project.ProjectProgressPercentage = dm_project.ProjectPhases
                .SelectMany(x => x.PhaseItems)
                .Sum(c => (c.AcumulativePercentage * c.ProgressPercentage) / 100);

            await _unitOfWork.ProjectRepository
                .UpdateAsync(dm_project);
            await transaction.CommitAsync();

            return true;
        }
        catch
        {
            await transaction.RollbackAsync();
            return false;
        }
    }

    public async Task<bool> DeleteAsync(PhaseItem pm)
    {
        var dm_projectPhase = await _unitOfWork.ProjectPhaseRepository.GetAll().Include(x => x.PhaseItems).FirstOrDefaultAsync(x => x.Id == pm.ProjectPhaseId);
        if (dm_projectPhase == null) return false;

        var dm_project = _unitOfWork.ProjectRepository
            .GetAll()
            .Include(x => x.ProjectPhases)
            .ThenInclude(x => x.PhaseItems)
            .FirstOrDefault(x => x.Id == dm_projectPhase.ProjectId);

        if (dm_project == null) return false;

        var totalAcumulativePercentage = dm_project.ProjectPhases
            .SelectMany(x => x.PhaseItems)
            .Sum(c => c.AcumulativePercentage);

        if (totalAcumulativePercentage > 100) return false;
        pm.PercentageLossOrExceed = (pm.InitialInventoryQuantities - pm.ActualInventoryQuantities) * 100 / pm.InitialInventoryQuantities;



        await _phaseItemRepository.DeleteAsync(pm);
        dm_project.ProjectProgressPercentage = dm_project.ProjectPhases
            .SelectMany(x => x.PhaseItems)
            .Sum(c => (c.AcumulativePercentage * c.ProgressPercentage) / 100);

        await _unitOfWork.ProjectRepository
            .UpdateAsync(dm_project);
        return true;
    }
    #endregion
}
