using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Posts.Commands.Models;

public class DeletePostCommand : IRequest<Response<string>>
{
    public int Id { get; set; }

    public DeletePostCommand()
    {

    }

    public DeletePostCommand(int iD)
    {
        Id = iD;
    }
}
