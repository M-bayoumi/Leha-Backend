using Leha.Infrastructure.Repositories.Companies;
using Leha.Infrastructure.Repositories.Generic;
using Leha.Infrastructure.Repositories.HomeImages;
using Leha.Infrastructure.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace Leha.Infrastructure;

public static class ModuleInfrastructureDependencies
{
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<IHomeImageRepository, HomeImageRepository>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        return services;
    }
}
