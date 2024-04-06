using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.HomeImages.Commands.Models;

public class UpdateHomeImageCommand : IRequest<Response<string>>
{
    public int ID { get; set; }
    public string HomeImageBytes { get; set; } = string.Empty;
    public int CompanyID { get; set; }

    public UpdateHomeImageCommand()
    {

    }

    public UpdateHomeImageCommand(int iD, string homeImageBytes, int companyID)
    {
        ID = iD;
        HomeImageBytes = homeImageBytes;
        CompanyID = companyID;
    }
}
