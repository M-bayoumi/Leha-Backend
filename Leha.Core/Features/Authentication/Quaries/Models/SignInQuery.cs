using Leha.Core.BaseResponse;
using Leha.Core.Features.Authentication.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Authentication.Quaries.Models;

public class SignInQuery : IRequest<Response<SignInResponse>>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
