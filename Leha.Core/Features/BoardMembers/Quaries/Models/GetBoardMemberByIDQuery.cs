using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMembers.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.BoardMembers.Quaries.Models;


public class GetBoardMemberByIDQuery : IRequest<Response<GetBoardMemberByIDResponse>>
{
    public int ID { get; set; }

    public GetBoardMemberByIDQuery(int boardMemberID)
    {
        ID = boardMemberID;
    }
    public GetBoardMemberByIDQuery()
    {
    }
}

