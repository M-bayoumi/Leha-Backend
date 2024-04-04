using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMembers.Quaries.Results;
using Leha.Core.Features.BoardMemberSpeeches.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.BoardMemberSpeeches.Quaries.Models;

public class GetBoardMemberSpeechByIDQuery : IRequest<Response<GetBoardMemberSpeechByIDResponse>>
{
    public int ID { get; set; }

    public GetBoardMemberSpeechByIDQuery(int boardMemberSpeechID)
    {
        ID = boardMemberSpeechID;
    }
    public GetBoardMemberSpeechByIDQuery()
    {
    }
}

