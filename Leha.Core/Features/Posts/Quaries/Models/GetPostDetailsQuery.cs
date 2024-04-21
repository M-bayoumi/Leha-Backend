using Leha.Core.BaseResponse;
using Leha.Core.Features.Posts.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Posts.Quaries.Models;

public class GetPostDetailsQuery : IRequest<Response<GetPostDetailsResponse>>
{
    public int Id { get; set; }

    public GetPostDetailsQuery(int postID)
    {
        Id = postID;
    }
    public GetPostDetailsQuery()
    {
    }
}
