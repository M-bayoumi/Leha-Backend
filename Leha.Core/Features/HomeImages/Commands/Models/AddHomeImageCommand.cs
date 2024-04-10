using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.HomeImages.Commands.Models;

public class AddHomeImageCommand : IRequest<Response<string>>
{
    public string HomeImageBytes { get; set; } = string.Empty;
    public int CompanyId { get; set; }

    public AddHomeImageCommand()
    {

    }

    public AddHomeImageCommand(string homeImageBytes, int companyId)
    {
        HomeImageBytes = homeImageBytes;
        CompanyId = companyId;
    }
}
