using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMemberSpeeches.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.BoardMemberSpeeches.Quaries.Models;

public class GetBoardMemberSpeechesListByBoardMemberIDQuery : IRequest<Response<List<GetBoardMemberSpeechListByBoardMemberIDResponse>>>
{
    public int ID { get; set; }

    public GetBoardMemberSpeechesListByBoardMemberIDQuery(int boardMemberID)
    {
        ID = boardMemberID;
    }
    public GetBoardMemberSpeechesListByBoardMemberIDQuery()
    {
    }
}
