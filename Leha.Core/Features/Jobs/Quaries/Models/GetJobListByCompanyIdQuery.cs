using Leha.Core.BaseResponse;
using Leha.Core.Features.Jobs.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Jobs.Quaries.Models;

public class GetJobListByCompanyIDQuery : IRequest<Response<List<GetJobListByCompanyIDResponse>>>
{
    public int ID { get; set; }

    public GetJobListByCompanyIDQuery(int companyID)
    {
        ID = companyID;
    }
    public GetJobListByCompanyIDQuery()
    {
    }
}
