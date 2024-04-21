using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMembers.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.BoardMembers.Quaries.Models;

public class GetBoardMemberDetailsQuery : IRequest<Response<GetBoardMemberDetailsResponse>>
{
    public int Id { get; set; }

    public GetBoardMemberDetailsQuery(int boardMemberId)
    {
        Id = boardMemberId;
    }
    public GetBoardMemberDetailsQuery()
    {
    }
}


