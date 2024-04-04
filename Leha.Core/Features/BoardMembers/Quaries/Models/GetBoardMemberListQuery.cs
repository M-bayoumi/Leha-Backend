using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMembers.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.BoardMembers.Quaries.Models;

public class GetBoardMemberListQuery : IRequest<Response<List<GetBoardMemberListResponse>>>
{
}

