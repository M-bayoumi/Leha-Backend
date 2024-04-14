using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Authentication.Quaries.Models;

public class SignInQuery : IRequest<Response<string>>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
