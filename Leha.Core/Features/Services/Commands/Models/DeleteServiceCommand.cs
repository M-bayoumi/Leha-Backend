using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Services.Commands.Models;

public class DeleteServiceCommand : IRequest<Response<string>>
{
    public int Id { get; set; }

    public DeleteServiceCommand()
    {

    }

    public DeleteServiceCommand(int iD)
    {
        Id = iD;
    }
}
