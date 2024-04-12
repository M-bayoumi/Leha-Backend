using Microsoft.AspNetCore.Identity;

namespace Leha.Data.Entities.Identity;

public class AppUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

}
