﻿namespace Leha.Core.Features.Authentication.Quaries.Results;

public class SignInResponse
{
    public string UserName { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
}
