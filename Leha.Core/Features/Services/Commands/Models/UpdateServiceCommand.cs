using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Services.Commands.Models;

public class UpdateServiceCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public string DescriptionAr { get; set; } = string.Empty;
    public string DescriptionEn { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public int CompanyId { get; set; }
    public UpdateServiceCommand()
    {

    }

    public UpdateServiceCommand(int id,
        string nameAr, string nameEn,
        string descriptionAr, string descriptionEn,
        string image, int companyId)
    {
        Id = id;
        NameAr = nameAr;
        NameEn = nameEn;
        DescriptionAr = descriptionAr;
        DescriptionEn = descriptionEn;
        Image = image;
        CompanyId = companyId;
    }
}
