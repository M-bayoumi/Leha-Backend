using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Posts.Commands.Models;

public class UpdatePostCommand : IRequest<Response<string>>
{
    public int ID { get; set; }
    public string PostContent { get; set; } = string.Empty;
    public string PostImage { get; set; } = string.Empty;
    public int CompanyID { get; set; }
    public UpdatePostCommand()
    {

    }

    public UpdatePostCommand(int iD, string postContent, string postImage, int companyID)
    {
        ID = iD;
        PostContent = postContent;
        PostImage = postImage;
        CompanyID = companyID;
    }
}
