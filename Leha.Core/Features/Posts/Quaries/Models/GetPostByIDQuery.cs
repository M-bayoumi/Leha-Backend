using Leha.Core.BaseResponse;
using Leha.Core.Features.Posts.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Posts.Quaries.Models;

public class GetPostByIDQuery : IRequest<Response<GetPostByIDResponse>>
{
    public int ID { get; set; }

    public GetPostByIDQuery(int postID)
    {
        ID = postID;
    }
    public GetPostByIDQuery()
    {
    }
}
