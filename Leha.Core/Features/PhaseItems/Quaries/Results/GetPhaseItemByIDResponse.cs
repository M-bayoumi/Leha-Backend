namespace Leha.Core.Features.PhaseItems.Quaries.Results;

public class GetPhaseItemByIdResponse
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
    public string ProjectPhaseName { get; set; } = string.Empty;
}
