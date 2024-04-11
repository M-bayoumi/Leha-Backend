using Leha.Core.BaseResponse;
using Leha.Core.Features.Posts.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Posts.Quaries.Models;

public class GetPostListByCompanyIDQuery : IRequest<Response<List<GetPostListByCompanyIDResponse>>>
{
    public int Id { get; set; }

    public GetPostListByCompanyIDQuery(int companyID)
    {
        Id = companyID;
    }
    public GetPostListByCompanyIDQuery()
    {
    }
}
