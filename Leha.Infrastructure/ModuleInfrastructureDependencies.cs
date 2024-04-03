﻿using Leha.Infrastructure.Repositories.BoardMemberSpeeches;
using Leha.Infrastructure.Repositories.Clients;
using Leha.Infrastructure.Repositories.Companies;
using Leha.Infrastructure.Repositories.CompanyAddresses;
using Leha.Infrastructure.Repositories.Forms;
using Leha.Infrastructure.Repositories.Generic;
using Leha.Infrastructure.Repositories.HomeImages;
using Leha.Infrastructure.Repositories.Jobs;
using Leha.Infrastructure.Repositories.PhaseItems;
using Leha.Infrastructure.Repositories.Posts;
using Leha.Infrastructure.Repositories.Products;
using Leha.Infrastructure.Repositories.ProjectPhases;
using Leha.Infrastructure.Repositories.Projects;
using Leha.Infrastructure.Repositories.Services;
using Leha.Infrastructure.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace Leha.Infrastructure;

public static class ModuleInfrastructureDependencies
{
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IBoardMemberRepository, BoardMemberRepository>();
        services.AddScoped<IBoardMemberSpeechRepository, BoardMemberSpeechRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<ICompanyAddressRepository, CompanyAddressRepository>();
        services.AddScoped<IFormRepository, FormRepository>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IHomeImageRepository, HomeImageRepository>();
        services.AddScoped<IJobRepository, JobRepository>();
        services.AddScoped<IPhaseItemRepository, PhaseItemRepository>();
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProjectPhaseRepository, ProjectPhaseRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IServiceRepository, ServiceRepository>();
        return services;
    }
}
