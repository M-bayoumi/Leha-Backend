using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.PhaseItems.Commands.Models;

public class UpdatePhaseItemCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public decimal AcumulativePercentage { get; set; }
    public decimal ProgressPercentage { get; set; }
    public string ExecutionProgressAr { get; set; } = string.Empty;
    public string ExecutionProgressEn { get; set; } = string.Empty;
    public string RfiAr { get; set; } = string.Empty;
    public string RfiEn { get; set; } = string.Empty;
    public string WirAr { get; set; } = string.Empty;
    public string WirEn { get; set; } = string.Empty;
    public string ScheduleAr { get; set; } = string.Empty;
    public string ScheduleEn { get; set; } = string.Empty;
    public string UnitAr { get; set; } = string.Empty;
    public string UnitEn { get; set; } = string.Empty;
    public decimal InitialInventoryQuantities { get; set; }
    public decimal ActualInventoryQuantities { get; set; }
    public int ProjectPhaseId { get; set; }
    public UpdatePhaseItemCommand()
    {

    }

    public UpdatePhaseItemCommand(int id, string number, string nameAr, string nameEn, decimal acumulativePercentage, decimal progressPercentage, string executionProgressAr, string executionProgressEn, string rfiAr, string rfiEn, string wirAr, string wirEn, string scheduleAr, string scheduleEn, string unitAr, string unitEn, decimal initialInventoryQuantities, decimal actualInventoryQuantities, int projectPhaseId)
    {
        Id = id;
        Number = number;
        NameAr = nameAr;
        NameEn = nameEn;
        AcumulativePercentage = acumulativePercentage;
        ProgressPercentage = progressPercentage;
        ExecutionProgressAr = executionProgressAr;
        ExecutionProgressEn = executionProgressEn;
        RfiAr = rfiAr;
        RfiEn = rfiEn;
        WirAr = wirAr;
        WirEn = wirEn;
        ScheduleAr = scheduleAr;
        ScheduleEn = scheduleEn;
        UnitAr = unitAr;
        UnitEn = unitEn;
        InitialInventoryQuantities = initialInventoryQuantities;
        ActualInventoryQuantities = actualInventoryQuantities;
        ProjectPhaseId = projectPhaseId;
    }
}
