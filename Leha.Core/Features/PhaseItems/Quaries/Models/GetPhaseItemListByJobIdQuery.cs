using Leha.Core.BaseResponse;
using Leha.Core.Features.PhaseItems.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.PhaseItems.Quaries.Models;

public class GetPhaseItemListByProjectPhaseIDQuery : IRequest<Response<List<GetPhaseItemListByProjectPhaseIDResponse>>>
{
    public int ID { get; set; }

    public GetPhaseItemListByProjectPhaseIDQuery(int projectPhaseID)
    {
        ID = projectPhaseID;
    }
    public GetPhaseItemListByProjectPhaseIDQuery()
    {
    }
}
