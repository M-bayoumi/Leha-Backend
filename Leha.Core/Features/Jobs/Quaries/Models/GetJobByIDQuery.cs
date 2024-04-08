using Leha.Core.BaseResponse;
using Leha.Core.Features.Jobs.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Jobs.Quaries.Models;

public class GetJobByIdQuery : IRequest<Response<GetJobByIdResponse>>
{
    public int ID { get; set; }

    public GetJobByIdQuery(int jobID)
    {
        ID = jobID;
    }
    public GetJobByIdQuery()
    {
    }
}
