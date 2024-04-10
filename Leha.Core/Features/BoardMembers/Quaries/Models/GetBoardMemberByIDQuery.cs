using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMembers.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.BoardMembers.Quaries.Models;


public class GetBoardMemberByIdQuery : IRequest<Response<GetBoardMemberByIdResponse>>
{
    public int Id { get; set; }

    public GetBoardMemberByIdQuery(int boardMemberId)
    {
        Id = boardMemberId;
    }
    public GetBoardMemberByIdQuery()
    {
    }
}

