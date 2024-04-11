using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.PhaseItems.Commands.Models;

public class DeletePhaseItemCommand : IRequest<Response<string>>
{
    public int Id { get; set; }

    public DeletePhaseItemCommand()
    {

    }

    public DeletePhaseItemCommand(int iD)
    {
        Id = iD;
    }
}
