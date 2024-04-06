using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.HomeImages.Commands.Models;

public class AddHomeImageCommand : IRequest<Response<string>>
{
    public string HomeImageBytes { get; set; } = string.Empty;
    public int CompanyID { get; set; }

    public AddHomeImageCommand()
    {

    }

    public AddHomeImageCommand(string homeImageBytes, int companyID)
    {
        HomeImageBytes = homeImageBytes;
        CompanyID = companyID;
    }
}
