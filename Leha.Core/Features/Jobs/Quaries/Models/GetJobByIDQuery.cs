using Leha.Core.BaseResponse;
using Leha.Core.Features.Jobs.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Jobs.Quaries.Models;

public class GetJobByIDQuery : IRequest<Response<GetJobByIDResponse>>
{
    public int ID { get; set; }

    public GetJobByIDQuery(int jobID)
    {
        ID = jobID;
    }
    public GetJobByIDQuery()
    {
    }
}
