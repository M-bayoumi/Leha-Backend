using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Services.Commands.Models;

public class DeleteServiceCommand : IRequest<Response<string>>
{
    public int ID { get; set; }

    public DeleteServiceCommand()
    {

    }

    public DeleteServiceCommand(int iD)
    {
        ID = iD;
    }
}
