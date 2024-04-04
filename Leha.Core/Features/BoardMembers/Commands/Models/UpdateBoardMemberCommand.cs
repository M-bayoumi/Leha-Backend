using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.BoardMembers.Commands.Models;


public class UpdateBoardMemberCommand : IRequest<Response<string>>
{
    public int ID { get; set; }
    public string BoardMemberName { get; set; } = string.Empty;
    public string BoardMemberImage { get; set; } = string.Empty;
    public string BoardMemberPosition { get; set; } = string.Empty;
}
