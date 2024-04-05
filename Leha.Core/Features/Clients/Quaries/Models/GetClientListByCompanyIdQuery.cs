using Leha.Core.BaseResponse;
using Leha.Core.Features.Clients.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Clients.Quaries.Models;

public class GetClientListByCompanyIdQuery : IRequest<Response<List<GetClientListByCompanyIDResponse>>>
{
    public int ID { get; set; }

    public GetClientListByCompanyIdQuery(int companyID)
    {
        ID = companyID;
    }
    public GetClientListByCompanyIdQuery()
    {
    }
}
