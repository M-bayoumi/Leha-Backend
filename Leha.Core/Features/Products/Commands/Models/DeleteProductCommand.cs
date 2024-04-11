using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Products.Commands.Models;

public class DeleteProductCommand : IRequest<Response<string>>
{
    public int Id { get; set; }

    public DeleteProductCommand()
    {

    }

    public DeleteProductCommand(int iD)
    {
        Id = iD;
    }
}
