using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Forms.Commands.Models;

public class DeleteFormCommand : IRequest<Response<string>>
{
    public int Id { get; set; }

    public DeleteFormCommand()
    {

    }

    public DeleteFormCommand(int iD)
    {
        Id = iD;
    }
}
