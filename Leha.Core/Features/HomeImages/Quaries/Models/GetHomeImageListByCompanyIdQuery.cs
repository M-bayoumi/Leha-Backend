using Leha.Core.BaseResponse;
using Leha.Core.Features.HomeImages.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.HomeImages.Quaries.Models;

public class GetHomeImageListByCompanyIdQuery : IRequest<Response<List<GetHomeImageListByCompanyIDResponse>>>
{
    public int ID { get; set; }

    public GetHomeImageListByCompanyIdQuery(int companyID)
    {
        ID = companyID;
    }
    public GetHomeImageListByCompanyIdQuery()
    {
    }
}
