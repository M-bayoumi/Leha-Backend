using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.BoardMembers.Commands.Models;

public class DeleteBoardMemberCommand : IRequest<Response<string>>
{
    public int ID { get; set; }
    public DeleteBoardMemberCommand(int iD)
    {
        ID = iD;
    }
    public DeleteBoardMemberCommand()
    {

    }
}

