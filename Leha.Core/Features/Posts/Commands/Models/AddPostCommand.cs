using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Posts.Commands.Models;

public class AddPostCommand : IRequest<Response<string>>
{
    public string PostContent { get; set; } = string.Empty;
    public string PostImage { get; set; } = string.Empty;
    public int CompanyID { get; set; }

    public AddPostCommand()
    {

    }

    public AddPostCommand(string postContent, string postImage, int companyID)
    {
        PostContent = postContent;
        PostImage = postImage;
        CompanyID = companyID;
    }
}
