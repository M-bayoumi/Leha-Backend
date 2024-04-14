using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.AppUsers.Commands.Models;

public class UpdateAppUserCommand : IRequest<Response<string>>
{
    public string Id { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}
