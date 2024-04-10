using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Clients.Commands.Models;

public class UpdateClientCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public int CompanyId { get; set; }

    public UpdateClientCommand()
    {

    }

    public UpdateClientCommand(int id, string nameAr, string nameEn, string image, int companyId)
    {
        Id = id;
        NameAr = nameAr;
        NameEn = nameEn;
        Image = image;
        CompanyId = companyId;
    }
}
