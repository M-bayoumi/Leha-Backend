using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMemberSpeeches.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.BoardMemberSpeeches.Quaries.Models;

public class GetBoardMemberSpeechDetailsQuery : IRequest<Response<GetBoardMemberSpeechDetailsResponse>>
{
    public int Id { get; set; }

    public GetBoardMemberSpeechDetailsQuery(int boardMemberSpeechID)
    {
        Id = boardMemberSpeechID;
    }
    public GetBoardMemberSpeechDetailsQuery()
    {
    }
}
