using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Services.Commands.Models;

public class AddServiceCommand : IRequest<Response<string>>
{
    public string ServiceName { get; set; } = string.Empty;
    public string ServiceDescription { get; set; } = string.Empty;
    public string ServiceImage { get; set; } = string.Empty;
    public int CompanyID { get; set; }

    public AddServiceCommand()
    {

    }

    public AddServiceCommand(string serviceName, string serviceDescription, string serviceImage, int companyID)
    {
        ServiceName = serviceName;
        ServiceDescription = serviceDescription;
        ServiceImage = serviceImage;
        CompanyID = companyID;
    }
}
