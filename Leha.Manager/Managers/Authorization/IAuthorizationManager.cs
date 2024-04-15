namespace Leha.Manager.Managers.Authorization;

public interface IAuthorizationManager
{
    public Task<bool> AddRoleAsync(string roleName);
    public Task<bool> IsRoleExist(string roleName);
}
