using Leha.Core.BaseResponse;
using Leha.Core.Features.PhaseItems.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.PhaseItems.Quaries.Models;

public class GetPhaseItemDetailsQuery : IRequest<Response<GetPhaseItemDetailsResponse>>
{
    public int Id { get; set; }

    public GetPhaseItemDetailsQuery(int phaseItemID)
    {
        Id = phaseItemID;
    }
    public GetPhaseItemDetailsQuery()
    {
    }
}
