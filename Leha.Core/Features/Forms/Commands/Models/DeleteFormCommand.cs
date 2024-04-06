using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Forms.Commands.Models;

public class DeleteFormCommand : IRequest<Response<string>>
{
    public int ID { get; set; }

    public DeleteFormCommand()
    {

    }

    public DeleteFormCommand(int iD)
    {
        ID = iD;
    }
}
