using Leha.Manager.Managers.Companies;
using Microsoft.Extensions.DependencyInjection;

namespace Leha.Manager;

public static class ModuleManagerDependencies
{
    public static IServiceCollection AddManagerDependencies(this IServiceCollection services)
    {
        services.AddScoped<ICompanyManager, CompanyManager>();
        return services;
    }
}
