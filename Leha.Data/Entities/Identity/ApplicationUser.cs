using Microsoft.AspNetCore.Identity;

namespace Leha.Data.Entities.Identity;

public class ApplicationUser : IdentityUser
{
    public string Address { get; set; } = string.Empty;

}
