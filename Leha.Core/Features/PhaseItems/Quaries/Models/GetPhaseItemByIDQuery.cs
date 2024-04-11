using Leha.Core.BaseResponse;
using Leha.Core.Features.PhaseItems.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.PhaseItems.Quaries.Models;

public class GetPhaseItemByIdQuery : IRequest<Response<GetPhaseItemByIdResponse>>
{
    public int Id { get; set; }

    public GetPhaseItemByIdQuery(int phaseItemID)
    {
        Id = phaseItemID;
    }
    public GetPhaseItemByIdQuery()
    {
    }
}
