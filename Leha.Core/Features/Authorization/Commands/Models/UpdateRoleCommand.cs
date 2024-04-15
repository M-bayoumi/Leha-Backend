using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Authorization.Commands.Models;


public class UpdateRoleCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

}
