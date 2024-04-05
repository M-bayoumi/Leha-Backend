using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Clients.Commands.Models;

public class DeleteClientCommand : IRequest<Response<string>>
{
    public int ID { get; set; }

    public DeleteClientCommand()
    {

    }

    public DeleteClientCommand(int iD)
    {
        ID = iD;
    }
}
