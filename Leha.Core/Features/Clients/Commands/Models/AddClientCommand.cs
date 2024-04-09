using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Clients.Commands.Models;

public class AddClientCommand : IRequest<Response<string>>
{
    public string ClientNameAr { get; set; } = string.Empty;
    public string ClientNameEn { get; set; } = string.Empty;
    public string ClientImage { get; set; } = string.Empty;
    public int CompanyID { get; set; }
    public AddClientCommand(string clientNameAr, string clientNameEn, string clientImage, int companyID)
    {
        ClientNameAr = clientNameAr;
        ClientNameEn = clientNameEn;
        ClientImage = clientImage;
        CompanyID = companyID;
    }
    public AddClientCommand()
    {

    }
}
