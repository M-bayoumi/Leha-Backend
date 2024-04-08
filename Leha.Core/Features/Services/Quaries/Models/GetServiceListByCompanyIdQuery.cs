using Leha.Core.BaseResponse;
using Leha.Core.Features.Services.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Services.Quaries.Models;

public class GetServiceListByCompanyIDQuery : IRequest<Response<List<GetServiceListByCompanyIDResponse>>>
{
    public int ID { get; set; }

    public GetServiceListByCompanyIDQuery(int companyID)
    {
        ID = companyID;
    }
    public GetServiceListByCompanyIDQuery()
    {
    }
}
