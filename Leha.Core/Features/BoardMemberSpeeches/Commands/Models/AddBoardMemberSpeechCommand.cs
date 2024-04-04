using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.BoardMemberSpeeches.Commands.Models;

public class AddBoardMemberSpeechCommand : IRequest<Response<string>>
{
    public string BoardMemberSpeechContent { get; set; } = string.Empty;
    public int BoardMemberID { get; set; }

    public AddBoardMemberSpeechCommand(string boardMemberSpeechContent, int boardMemberID)
    {
        BoardMemberSpeechContent = boardMemberSpeechContent;
        BoardMemberID = boardMemberID;
    }
    public AddBoardMemberSpeechCommand()
    {

    }
}
