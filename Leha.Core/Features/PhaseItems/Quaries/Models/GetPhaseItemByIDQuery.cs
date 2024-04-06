using Leha.Core.BaseResponse;
using Leha.Core.Features.PhaseItems.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.PhaseItems.Quaries.Models;

public class GetPhaseItemByIDQuery : IRequest<Response<GetPhaseItemByIDResponse>>
{
    public int ID { get; set; }

    public GetPhaseItemByIDQuery(int phaseItemID)
    {
        ID = phaseItemID;
    }
    public GetPhaseItemByIDQuery()
    {
    }
}
