using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Clients.Commands.Models;

public class UpdateClientCommand : IRequest<Response<string>>
{
    public int ID { get; set; }
    public string ClientName { get; set; } = string.Empty;
    public string ClientImage { get; set; } = string.Empty;
    public int CompanyID { get; set; }

    public UpdateClientCommand()
    {

    }
    public UpdateClientCommand(int iD, string clientName, string clientImage, int companyID)
    {
        ID = iD;
        ClientName = clientName;
        ClientImage = clientImage;
        CompanyID = companyID;
    }

}
