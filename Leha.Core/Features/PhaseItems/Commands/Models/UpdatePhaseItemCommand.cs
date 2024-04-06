using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.PhaseItems.Commands.Models;

public class UpdatePhaseItemCommand : IRequest<Response<string>>
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
    public int ProjectPhaseID { get; set; }
    public UpdatePhaseItemCommand()
    {

    }

    public UpdatePhaseItemCommand(int iD, string phaseItemNumber, string phaseItemName, decimal acumulativePercentage, decimal progressPercentage, string executionProgress, string rFI, string wIR, string schedule, string unit, decimal initialInventoryQuantities, decimal actualInventoryQuantities, int projectPhaseID)
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
        ProjectPhaseID = projectPhaseID;
    }
}
