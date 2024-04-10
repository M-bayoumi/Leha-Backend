using Leha.Core.BaseResponse;
using Leha.Core.Features.Jobs.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Jobs.Quaries.Models;

public class GetJobListByCompanyIDQuery : IRequest<Response<List<GetJobListByCompanyIDResponse>>>
{
    public int Id { get; set; }

    public GetJobListByCompanyIDQuery(int companyID)
    {
        Id = companyID;
    }
    public GetJobListByCompanyIDQuery()
    {
    }
}
