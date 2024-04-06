using Leha.Core.BaseResponse;
using Leha.Core.Features.PhaseItems.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.PhaseItems.Quaries.Models;

public class GetPhaseItemListByProjectPhaseIdQuery : IRequest<Response<List<GetPhaseItemListByProjectPhaseIDResponse>>>
{
    public int ID { get; set; }

    public GetPhaseItemListByProjectPhaseIdQuery(int projectPhaseID)
    {
        ID = projectPhaseID;
    }
    public GetPhaseItemListByProjectPhaseIdQuery()
    {
    }
}
