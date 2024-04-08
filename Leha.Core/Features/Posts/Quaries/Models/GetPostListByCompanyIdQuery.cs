using Leha.Core.BaseResponse;
using Leha.Core.Features.Posts.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Posts.Quaries.Models;

public class GetPostListByCompanyIDQuery : IRequest<Response<List<GetPostListByCompanyIDResponse>>>
{
    public int ID { get; set; }

    public GetPostListByCompanyIDQuery(int companyID)
    {
        ID = companyID;
    }
    public GetPostListByCompanyIDQuery()
    {
    }
}
