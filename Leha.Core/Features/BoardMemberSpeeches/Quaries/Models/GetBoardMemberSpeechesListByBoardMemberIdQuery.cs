using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMemberSpeeches.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.BoardMemberSpeeches.Quaries.Models;

public class GetBoardMemberSpeechesListByBoardMemberIDQuery : IRequest<Response<List<GetBoardMemberSpeechListByBoardMemberIDResponse>>>
{
    public int Id { get; set; }

    public GetBoardMemberSpeechesListByBoardMemberIDQuery(int boardMemberID)
    {
        Id = boardMemberID;
    }
    public GetBoardMemberSpeechesListByBoardMemberIDQuery()
    {
    }
}
