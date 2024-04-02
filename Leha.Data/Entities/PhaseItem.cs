
namespace Leha.Data.Entities;

public class PhaseItem
{
    public int ID { get; set; }
    public string PhaseItemNumber { get; set; } = string.Empty;
    public string PhaseItemName { get; set; } = string.Empty;
    public decimal AcumulativePercentage { get; set; }
    public decimal ProgressPercentage { get; set; }
    public string ExecutionProgress { get; set; } = string.Empty;
    public string RFI { get; set; } = string.Empty;
    public string WIR { get; set; } = string.Empty;
    public string Schedule { get; set; } = string.Empty;
    public string Unit { get; set; } = string.Empty;
    public decimal InitialInventoryQuantities { get; set; }
    public decimal ActualInventoryQuantities { get; set; }
    public decimal PercentageLossOrExceed { get; set; }
    public int ProjectPhaseID { get; set; }
    public ProjectPhase ProjectPhase { get; set; } = null!;

    public PhaseItem()
    {
    }

    public PhaseItem(int iD, string phaseItemNumber, string phaseItemName, decimal acumulativePercentage, decimal progressPercentage, string executionProgress, string rFI, string wIR, string schedule, string unit, decimal initialInventoryQuantities, decimal actualInventoryQuantities, decimal percentageLossOrExceed, int projectPhaseID)
    {
        ID = iD;
        PhaseItemNumber = phaseItemNumber;
        PhaseItemName = phaseItemName;
        AcumulativePercentage = acumulativePercentage;
        ProgressPercentage = progressPercentage;
        ExecutionProgress = executionProgress;
        RFI = rFI;
        WIR = wIR;
        Schedule = schedule;
        Unit = unit;
        InitialInventoryQuantities = initialInventoryQuantities;
        ActualInventoryQuantities = actualInventoryQuantities;
        PercentageLossOrExceed = percentageLossOrExceed;
        ProjectPhaseID = projectPhaseID;
    }
}
