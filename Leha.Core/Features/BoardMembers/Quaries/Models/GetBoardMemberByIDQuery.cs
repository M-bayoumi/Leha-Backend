using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMembers.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.BoardMembers.Quaries.Models;


public class GetBoardMemberByIdQuery : IRequest<Response<GetBoardMemberByIdResponse>>
{
    public int ID { get; set; }

    public GetBoardMemberByIdQuery(int boardMemberID)
    {
        ID = boardMemberID;
    }
    public GetBoardMemberByIdQuery()
    {
    }
}

