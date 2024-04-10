using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.BoardMembers.Commands.Models;

public class AddBoardMemberCommand : IRequest<Response<string>>
{
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string PositionAr { get; set; } = string.Empty;
    public string PositionEn { get; set; } = string.Empty;

    public AddBoardMemberCommand()
    {

    }

    public AddBoardMemberCommand(string nameAr, string nameEn, string image, string positionAr, string positionEn)
    {
        NameAr = nameAr;
        NameEn = nameEn;
        Image = image;
        PositionAr = positionAr;
        PositionEn = positionEn;
    }
}
