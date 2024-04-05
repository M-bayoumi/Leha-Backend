using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.BoardMemberSpeeches.Commands.Models;


public class UpdateBoardMemberSpeechCommand : IRequest<Response<string>>
{
    public int ID { get; set; }
    public string BoardMemberSpeechContent { get; set; } = string.Empty;
    public int BoardMemberID { get; set; }
    public UpdateBoardMemberSpeechCommand(int iD, string boardMemberSpeechContent, int boardMemberID)
    {
        ID = iD;
        BoardMemberSpeechContent = boardMemberSpeechContent;
        BoardMemberID = boardMemberID;
    }
    public UpdateBoardMemberSpeechCommand()
    {

    }
}
