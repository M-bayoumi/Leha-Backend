using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMemberSpeeches.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.BoardMemberSpeeches.Quaries.Models;

public class GetBoardMemberSpeechByIdQuery : IRequest<Response<GetBoardMemberSpeechByIdResponse>>
{
    public int ID { get; set; }

    public GetBoardMemberSpeechByIdQuery(int boardMemberSpeechID)
    {
        ID = boardMemberSpeechID;
    }
    public GetBoardMemberSpeechByIdQuery()
    {
    }
}
