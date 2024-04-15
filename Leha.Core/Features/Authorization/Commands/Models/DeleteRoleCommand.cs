using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Authorization.Commands.Models;

public class DeleteRoleCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public DeleteRoleCommand(int id)
    {
        Id = id;
    }
    public DeleteRoleCommand()
    {

    }
}

