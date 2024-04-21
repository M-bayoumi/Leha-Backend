using Leha.Core.BaseResponse;
using Leha.Core.Features.Jobs.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Jobs.Quaries.Models;

public class GetJobDetailsQuery : IRequest<Response<GetJobDetailsResponse>>
{
    public int Id { get; set; }

    public GetJobDetailsQuery(int jobID)
    {
        Id = jobID;
    }
    public GetJobDetailsQuery()
    {
    }
}
