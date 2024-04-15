using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.AppUsers.Commands.Models;

public class AddAppUserCommand : IRequest<Response<string>>
{
    public string FullName { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}
