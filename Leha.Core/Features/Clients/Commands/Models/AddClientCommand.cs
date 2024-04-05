using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Clients.Commands.Models;

public class AddClientCommand : IRequest<Response<string>>
{
    public string ClientName { get; set; } = string.Empty;
    public string ClientImage { get; set; } = string.Empty;
    public int CompanyID { get; set; }
    public AddClientCommand(string clientName, string clientImage, int companyID)
    {
        ClientName = clientName;
        ClientImage = clientImage;
        CompanyID = companyID;
    }
    public AddClientCommand()
    {

    }
}
