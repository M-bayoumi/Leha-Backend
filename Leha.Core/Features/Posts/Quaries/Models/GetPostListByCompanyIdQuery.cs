using Leha.Core.BaseResponse;
using Leha.Core.Features.Posts.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Posts.Quaries.Models;

public class GetPostListByCompanyIdQuery : IRequest<Response<List<GetPostListByCompanyIDResponse>>>
{
    public int ID { get; set; }

    public GetPostListByCompanyIdQuery(int companyID)
    {
        ID = companyID;
    }
    public GetPostListByCompanyIdQuery()
    {
    }
}
