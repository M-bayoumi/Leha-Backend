using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.HomeImages.Commands.Models;

public class DeleteHomeImageCommand : IRequest<Response<string>>
{
    public int Id { get; set; }

    public DeleteHomeImageCommand()
    {

    }

    public DeleteHomeImageCommand(int iD)
    {
        Id = iD;
    }
}
