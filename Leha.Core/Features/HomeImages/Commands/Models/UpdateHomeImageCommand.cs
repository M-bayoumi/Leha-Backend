using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.HomeImages.Commands.Models;

public class UpdateHomeImageCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public string ImageURL { get; set; } = string.Empty;
    public int CompanyId { get; set; }

    public UpdateHomeImageCommand()
    {

    }

    public UpdateHomeImageCommand(int id, string imageURL, int companyId)
    {
        Id = id;
        ImageURL = imageURL;
        CompanyId = companyId;
    }
}
