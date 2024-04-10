using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.BoardMembers.Commands.Models;

public class DeleteBoardMemberCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public DeleteBoardMemberCommand(int id)
    {
        Id = id;
    }
    public DeleteBoardMemberCommand()
    {

    }
}

