using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMemberSpeeches.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.BoardMemberSpeeches.Quaries.Models;

public class GetBoardMemberSpeechByIdQuery : IRequest<Response<GetBoardMemberSpeechByIdResponse>>
{
    public int Id { get; set; }

    public GetBoardMemberSpeechByIdQuery(int boardMemberSpeechID)
    {
        Id = boardMemberSpeechID;
    }
    public GetBoardMemberSpeechByIdQuery()
    {
    }
}
