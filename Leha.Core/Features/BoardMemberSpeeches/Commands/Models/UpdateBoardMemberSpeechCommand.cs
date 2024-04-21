using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.BoardMemberSpeeches.Commands.Models;


public class UpdateBoardMemberSpeechCommand : IRequest<Response<string>>
{
    public int ID { get; set; }
    public string ContentAr { get; set; } = string.Empty;
    public string ContentEn { get; set; } = string.Empty;
    public int BoardMemberId { get; set; }

    public UpdateBoardMemberSpeechCommand()
    {

    }

    public UpdateBoardMemberSpeechCommand(int iD, string contentAr, string contentEn, int boardMemberId)
    {
        ID = iD;
        ContentAr = contentAr;
        ContentEn = contentEn;
        BoardMemberId = boardMemberId;
    }
}
