using Leha.Core.BaseResponse;
using Leha.Core.Features.Posts.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Posts.Quaries.Models;

public class GetPostByIdQuery : IRequest<Response<GetPostByIdResponse>>
{
    public int ID { get; set; }

    public GetPostByIdQuery(int postID)
    {
        ID = postID;
    }
    public GetPostByIdQuery()
    {
    }
}
