using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.BoardMembers.Commands.Models;


public class UpdateBoardMemberCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string PositionAr { get; set; } = string.Empty;
    public string PositionEn { get; set; } = string.Empty;

}
