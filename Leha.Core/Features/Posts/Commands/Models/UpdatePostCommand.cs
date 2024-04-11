using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Posts.Commands.Models;

public class UpdatePostCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public string ContentAr { get; set; } = string.Empty;
    public string ContentEn { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public int CompanyId { get; set; }
    public UpdatePostCommand()
    {

    }

    public UpdatePostCommand(int id, string contentAr, string contentEn, string image, int companyId)
    {
        Id = id;
        ContentAr = contentAr;
        ContentEn = contentEn;
        Image = image;
        CompanyId = companyId;
    }
}
