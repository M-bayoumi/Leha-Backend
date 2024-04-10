using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Jobs.Commands.Models;

public class UpdateJobCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public string TitleAr { get; set; } = string.Empty;
    public string TitleEn { get; set; } = string.Empty;
    public string DescriptionAr { get; set; } = string.Empty;
    public string DescriptionEn { get; set; } = string.Empty;
    public string AverageSalary { get; set; } = string.Empty;
    public int CompanyId { get; set; }

    public UpdateJobCommand()
    {

    }

    public UpdateJobCommand(
        int id,
        string titleAr, string titleEn,
        string descriptionAr, string descriptionEn,
        string averageSalary,
        int companyId)
    {
        Id = id;
        TitleAr = titleAr;
        TitleEn = titleEn;
        DescriptionAr = descriptionAr;
        DescriptionEn = descriptionEn;
        AverageSalary = averageSalary;
        CompanyId = companyId;
    }
}
