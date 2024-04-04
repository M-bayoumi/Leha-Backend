using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.BoardMembers.Commands.Models;

public class AddBoardMemberCommand : IRequest<Response<string>>
{
    public string BoardMemberName { get; set; } = string.Empty;
    public string BoardMemberImage { get; set; } = string.Empty;
    public string BoardMemberPosition { get; set; } = string.Empty;
    public AddBoardMemberCommand(string boardMemberName, string boardMemberImage, string boardMemberPosition)
    {
        BoardMemberName = boardMemberName;
        BoardMemberImage = boardMemberImage;
        BoardMemberPosition = boardMemberPosition;
    }
    public AddBoardMemberCommand()
    {

    }

}
