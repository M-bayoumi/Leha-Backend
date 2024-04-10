using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Clients.Commands.Models;

public class DeleteClientCommand : IRequest<Response<string>>
{
    public int Id { get; set; }

    public DeleteClientCommand()
    {

    }

    public DeleteClientCommand(int id)
    {
        Id = id;
    }
}
