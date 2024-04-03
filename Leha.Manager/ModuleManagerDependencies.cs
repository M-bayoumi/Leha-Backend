using Leha.Manager.Managers.BoardMembers;
using Leha.Manager.Managers.BoardMemberSpeeches;
using Leha.Manager.Managers.Clients;
using Leha.Manager.Managers.Companies;
using Leha.Manager.Managers.CompanyAddresses;
using Leha.Manager.Managers.Forms;
using Leha.Manager.Managers.HomeImages;
using Leha.Manager.Managers.Jobs;
using Leha.Manager.Managers.PhaseItems;
using Leha.Manager.Managers.Posts;
using Leha.Manager.Managers.Products;
using Leha.Manager.Managers.ProjectPhases;
using Leha.Manager.Managers.Projects;
using Leha.Manager.Managers.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Leha.Manager;

public static class ModuleManagerDependencies
{
    public static IServiceCollection AddManagerDependencies(this IServiceCollection services)
    {
        services.AddScoped<IBoardMemberManager, BoardMemberManager>();
        services.AddScoped<IBoardMemberSpeechManager, BoardMemberSpeechManager>();
        services.AddScoped<IClientManager, ClientManager>();
        services.AddScoped<ICompanyManager, CompanyManager>();
        services.AddScoped<ICompanyAddressManager, CompanyAddressManager>();
        services.AddScoped<IFormManager, FormManager>();
        services.AddScoped<IHomeImageManager, HomeImageManager>();
        services.AddScoped<IJobManager, JobManager>();
        services.AddScoped<IPhaseItemManager, PhaseItemManager>();
        services.AddScoped<IPostManager, PostManager>();
        services.AddScoped<IProductManager, ProductManager>();
        services.AddScoped<IProjectPhaseManager, ProjectPhaseManager>();
        services.AddScoped<IProjectManager, ProjectManager>();
        services.AddScoped<IServiceManager, ServiceManager>();
        return services;
    }
}
