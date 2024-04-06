using Leha.Core.BaseResponse;
using Leha.Core.Features.Forms.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Forms.Quaries.Models;

public class GetFormListByJobIdQuery : IRequest<Response<List<GetFormListByJobIDResponse>>>
{
    public int ID { get; set; }

    public GetFormListByJobIdQuery(int jobID)
    {
        ID = jobID;
    }
    public GetFormListByJobIdQuery()
    {
    }
}
