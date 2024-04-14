using Leha.Data.Entities.Identity;

namespace Leha.Manager.Managers.Authentication;

public interface IAuthenticationManager
{
    public string GenerateJwtToken(AppUser appUser);
}
