using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.PhaseItems.Commands.Models;

public class DeletePhaseItemCommand : IRequest<Response<string>>
{
    public int ID { get; set; }

    public DeletePhaseItemCommand()
    {

    }

    public DeletePhaseItemCommand(int iD)
    {
        ID = iD;
    }
}
