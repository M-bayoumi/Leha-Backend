namespace Leha.Core.Features.PhaseItems.Quaries.Results;

public class GetPhaseItemDetailsResponse
{
    public int Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public decimal AcumulativePercentage { get; set; }
    public decimal ProgressPercentage { get; set; }
    public string ExecutionProgressAr { get; set; } = string.Empty;
    public string ExecutionProgressEn { get; set; } = string.Empty;
    public string RFIAr { get; set; } = string.Empty;
    public string RFIEn { get; set; } = string.Empty;
    public string WIRAr { get; set; } = string.Empty;
    public string WIREn { get; set; } = string.Empty;
    public string ScheduleAr { get; set; } = string.Empty;
    public string ScheduleEn { get; set; } = string.Empty;
    public string UnitAr { get; set; } = string.Empty;
    public string UnitEn { get; set; } = string.Empty;
    public decimal InitialInventoryQuantities { get; set; }
    public decimal ActualInventoryQuantities { get; set; }
    public decimal PercentageLossOrExceed { get; set; }
    public int ProjectPhaseId { get; set; }
}
