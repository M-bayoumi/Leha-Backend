using Leha.Core.BaseResponse;
using Leha.Core.Features.HomeImages.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.HomeImages.Quaries.Models;

public class GetHomeImageListByCompanyIDQuery : IRequest<Response<List<GetHomeImageListByCompanyIDResponse>>>
{
    public int Id { get; set; }

    public GetHomeImageListByCompanyIDQuery(int companyID)
    {
        Id = companyID;
    }
    public GetHomeImageListByCompanyIDQuery()
    {
    }
}
