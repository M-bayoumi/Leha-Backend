using Leha.Core.BaseResponse;
using Leha.Core.Features.Posts.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Posts.Quaries.Models;

public class GetPostByIdQuery : IRequest<Response<GetPostByIdResponse>>
{
    public int Id { get; set; }

    public GetPostByIdQuery(int postID)
    {
        Id = postID;
    }
    public GetPostByIdQuery()
    {
    }
}
