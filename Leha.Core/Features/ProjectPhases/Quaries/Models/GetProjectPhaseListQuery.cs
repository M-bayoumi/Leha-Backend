using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMemberSpeeches.Quaries.Results;
using Leha.Core.Features.ProjectPhases.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.ProjectPhases.Quaries.Models;

public class GetProjectPhaseListQuery : IRequest<Response<List<GetProjectPhaseListResponse>>>
{
}
