using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Services.Commands.Models;

public class AddServiceCommand : IRequest<Response<string>>
{
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public string DescriptionAr { get; set; } = string.Empty;
    public string DescriptionEn { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public int CompanyId { get; set; }

    public AddServiceCommand()
    {

    }

    public AddServiceCommand(string nameAr, string nameEn, string descriptionAr, string descriptionEn, string image, int companyId)
    {
        NameAr = nameAr;
        NameEn = nameEn;
        DescriptionAr = descriptionAr;
        DescriptionEn = descriptionEn;
        Image = image;
        CompanyId = companyId;
    }
}
