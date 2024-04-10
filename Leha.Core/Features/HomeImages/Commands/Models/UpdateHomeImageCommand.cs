using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.HomeImages.Commands.Models;

public class UpdateHomeImageCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public string HomeImageBytes { get; set; } = string.Empty;
    public int CompanyId { get; set; }

    public UpdateHomeImageCommand()
    {

    }

    public UpdateHomeImageCommand(int id, string homeImageBytes, int companyId)
    {
        Id = id;
        HomeImageBytes = homeImageBytes;
        CompanyId = companyId;
    }
}
