using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Services.Commands.Models;

public class UpdateServiceCommand : IRequest<Response<string>>
{
    public int ID { get; set; }
    public string ServiceName { get; set; } = string.Empty;
    public string ServiceDescription { get; set; } = string.Empty;
    public string ServiceImage { get; set; } = string.Empty;
    public int CompanyID { get; set; }
    public UpdateServiceCommand()
    {

    }

    public UpdateServiceCommand(int iD, string serviceName, string serviceDescription, string serviceImage, int companyID)
    {
        ID = iD;
        ServiceName = serviceName;
        ServiceDescription = serviceDescription;
        ServiceImage = serviceImage;
        CompanyID = companyID;
    }
}
