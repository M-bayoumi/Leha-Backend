using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Jobs.Commands.Models;

public class DeleteJobCommand : IRequest<Response<string>>
{
    public int Id { get; set; }

    public DeleteJobCommand()
    {

    }

    public DeleteJobCommand(int iD)
    {
        Id = iD;
    }
}
