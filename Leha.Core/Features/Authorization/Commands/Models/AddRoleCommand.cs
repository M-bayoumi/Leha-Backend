using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Authorization.Commands.Models;

public class AddRoleCommand : IRequest<Response<string>>
{
    public string Name { get; set; } = string.Empty;

    public AddRoleCommand()
    {

    }
    public AddRoleCommand(string name)
    {
        Name = name;
    }
}
