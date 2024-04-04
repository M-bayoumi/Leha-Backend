using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.BoardMemberSpeeches.Commands.Models;

public class DeleteBoardMemberSpeachCommand : IRequest<Response<string>>
{
    public int ID { get; set; }
    public DeleteBoardMemberSpeachCommand(int iD)
    {
        ID = iD;
    }
    public DeleteBoardMemberSpeachCommand()
    {

    }
}

