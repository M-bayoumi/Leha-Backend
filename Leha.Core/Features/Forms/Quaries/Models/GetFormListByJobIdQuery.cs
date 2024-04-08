using Leha.Core.BaseResponse;
using Leha.Core.Features.Forms.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Forms.Quaries.Models;

public class GetFormListByJobIDQuery : IRequest<Response<List<GetFormListByJobIDResponse>>>
{
    public int ID { get; set; }

    public GetFormListByJobIDQuery(int jobID)
    {
        ID = jobID;
    }
    public GetFormListByJobIDQuery()
    {
    }
}
