using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMemberSpeeches.Quaries.Results;
using Leha.Core.Features.PhaseItems.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.PhaseItems.Quaries.Models;

public class GetPhaseItemListQuery : IRequest<Response<List<GetPhaseItemListResponse>>>
{
}
