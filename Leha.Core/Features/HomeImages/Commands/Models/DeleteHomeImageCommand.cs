using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.HomeImages.Commands.Models;

public class DeleteHomeImageCommand : IRequest<Response<string>>
{
    public int ID { get; set; }

    public DeleteHomeImageCommand()
    {

    }

    public DeleteHomeImageCommand(int iD)
    {
        ID = iD;
    }
}
