namespace Leha.Core.Features.AppUsers.Quaries.Results;

public class GetAppUserByIdResponse
{
    public string FullName { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}
