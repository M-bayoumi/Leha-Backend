using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.AppUsers.Commands.Models;

public class DeleteAppUserCommand : IRequest<Response<string>>
{
    public string Id { get; set; }

    public DeleteAppUserCommand(string userId)
    {
        Id = userId;
    }
    public DeleteAppUserCommand()
    {

    }
}
