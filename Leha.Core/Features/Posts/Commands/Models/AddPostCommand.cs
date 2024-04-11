using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Posts.Commands.Models;

public class AddPostCommand : IRequest<Response<string>>
{
    public string ContentAr { get; set; } = string.Empty;
    public string ContentEn { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public int CompanyId { get; set; }
    public AddPostCommand()
    {

    }

    public AddPostCommand(string contentAr, string contentEn, string image, int companyId)
    {
        ContentAr = contentAr;
        ContentEn = contentEn;
        Image = image;
        CompanyId = companyId;
    }
}
