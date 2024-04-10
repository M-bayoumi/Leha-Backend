using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Clients.Commands.Models;

public class AddClientCommand : IRequest<Response<string>>
{
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public int CompanyId { get; set; }

    public AddClientCommand()
    {

    }

    public AddClientCommand(string nameAr, string nameEn, string image, int companyId)
    {
        NameAr = nameAr;
        NameEn = nameEn;
        Image = image;
        CompanyId = companyId;
    }
}
