using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.AppUsers.Commands.Models;

public class ChangeAppUserPasswordCommand : IRequest<Response<string>>
{
    public string Id { get; set; } = string.Empty;
    public string CurrentPassword { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
    public string ConfirmNewPassword { get; set; } = string.Empty;
}
