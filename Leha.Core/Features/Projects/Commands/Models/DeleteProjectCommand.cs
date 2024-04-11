using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Projects.Commands.Models;

public class DeleteProjectCommand : IRequest<Response<string>>
{
    public int Id { get; set; }

    public DeleteProjectCommand()
    {

    }

    public DeleteProjectCommand(int iD)
    {
        Id = iD;
    }
}
