using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.BoardMemberSpeeches.Commands.Models;

public class AddBoardMemberSpeechCommand : IRequest<Response<string>>
{
    public string ContentAr { get; set; } = string.Empty;
    public string ContentEn { get; set; } = string.Empty;
    public int BoardMemberID { get; set; }

    public AddBoardMemberSpeechCommand()
    {

    }

    public AddBoardMemberSpeechCommand(string contentAr, string contentEn, int boardMemberID)
    {
        ContentAr = contentAr;
        ContentEn = contentEn;
        BoardMemberID = boardMemberID;
    }
}
