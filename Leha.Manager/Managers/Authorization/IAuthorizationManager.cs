using Microsoft.AspNetCore.Identity;

namespace Leha.Manager.Managers.Authorization;

public interface IAuthorizationManager
{
    public Task<List<IdentityRole?>> GetAll();
    public Task<bool> AddRoleAsync(string roleName);
    public Task<bool> IsRoleExist(string roleName);
}
