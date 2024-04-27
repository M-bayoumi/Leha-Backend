using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Leha.Infrastructure.Seeder;

public static class RoleSeeder
{
    public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
    {
        var rolesCount = await roleManager.Roles.CountAsync();
        if (rolesCount <= 0)
        {
            await roleManager.CreateAsync(new IdentityRole()
            {
                Name = "SuperAdmin",
            });

            await roleManager.CreateAsync(new IdentityRole()
            {
                Name = "Admin",
            });

            await roleManager.CreateAsync(new IdentityRole()
            {
                Name = "Supervisor",
            });

            await roleManager.CreateAsync(new IdentityRole()
            {
                Name = "Engineer",
            });
        }
    }
}