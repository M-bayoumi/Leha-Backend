using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Leha.Manager.Managers.Authorization;

public class AuthorizationManager : IAuthorizationManager
{
    #region Fields
    private readonly RoleManager<IdentityRole> _roleManager;

    #endregion

    #region Constructors
    public AuthorizationManager(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    #endregion

    #region Handle Functions
    public async Task<List<IdentityRole?>> GetAll()
    {
        var result = await _roleManager.Roles.ToListAsync();
        return result;
    }

    public async Task<bool> AddRoleAsync(string roleName)
    {
        var identityRole = new IdentityRole();
        identityRole.Name = roleName;
        var result = await _roleManager.CreateAsync(identityRole);
        return result.Succeeded;
    }

    public async Task<bool> IsRoleExist(string roleName)
    {
        var role = await _roleManager.FindByNameAsync(roleName);
        return role != null;
    }

    #endregion
}
