using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.PhaseItems.Commands.Models;

public class AddPhaseItemCommand : IRequest<Response<string>>
{
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

    public AddPhaseItemCommand()
    {

    }

    public AddPhaseItemCommand(
        string number,
        string nameAr, string nameEn,
        decimal acumulativePercentage,
        decimal progressPercentage,
        string executionProgressAr, string executionProgressEn,
        string rFIAr, string rFIEn,
        string wIRAr, string wIREn,
        string scheduleAr, string scheduleEn,
        string unitAr, string unitEn,
        decimal initialInventoryQuantities,
        decimal actualInventoryQuantities,
        decimal percentageLossOrExceed,
        int projectPhaseId)
    {
        Number = number;
        NameAr = nameAr;
        NameEn = nameEn;
        AcumulativePercentage = acumulativePercentage;
        ProgressPercentage = progressPercentage;
        ExecutionProgressAr = executionProgressAr;
        ExecutionProgressEn = executionProgressEn;
        RFIAr = rFIAr;
        RFIEn = rFIEn;
        WIRAr = wIRAr;
        WIREn = wIREn;
        ScheduleAr = scheduleAr;
        ScheduleEn = scheduleEn;
        UnitAr = unitAr;
        UnitEn = unitEn;
        InitialInventoryQuantities = initialInventoryQuantities;
        ActualInventoryQuantities = actualInventoryQuantities;
        PercentageLossOrExceed = percentageLossOrExceed;
        ProjectPhaseId = projectPhaseId;
    }
}
