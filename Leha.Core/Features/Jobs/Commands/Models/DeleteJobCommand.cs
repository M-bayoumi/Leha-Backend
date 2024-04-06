using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Jobs.Commands.Models;

public class DeleteJobCommand : IRequest<Response<string>>
{
    public int ID { get; set; }

    public DeleteJobCommand()
    {

    }

    public DeleteJobCommand(int iD)
    {
        ID = iD;
    }
}
