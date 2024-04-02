#region Fields
using Leha.Infrastructure.Context;
using Leha.Infrastructure.Repositories.BoardMemberSpeeches;
using Leha.Infrastructure.Repositories.Clients;
using Leha.Infrastructure.Repositories.Companies;
using Leha.Infrastructure.Repositories.CompanyAddresses;
using Leha.Infrastructure.Repositories.Forms;
using Leha.Infrastructure.Repositories.HomeImages;
using Leha.Infrastructure.Repositories.Jobs;
using Leha.Infrastructure.Repositories.PhaseItems;
using Leha.Infrastructure.Repositories.Posts;
using Leha.Infrastructure.Repositories.Products;
using Leha.Infrastructure.Repositories.ProjectPhases;
using Leha.Infrastructure.Repositories.Projects;
using Leha.Infrastructure.Repositories.Services;
#endregion

namespace Leha.Infrastructure.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    #region Fields
    public AppDbContext AppDbContext { get; }
    public IBoardMemberRepository BoardMemberRepository { get; }
    public IBoardMemberSpeechRepository BoardMemberSpeechRepository { get; }
    public IClientRepository ClientRepository { get; }
    public ICompanyRepository CompanyRepository { get; }
    public ICompanyAddressRepository CompanyAddressRepository { get; }
    public IFormRepository FormRepository { get; }
    public IHomeImageRepository HomeImageRepository { get; }
    public IJobRepository JobRepository { get; }
    public IPhaseItemRepository PhaseItemRepository { get; }
    public IPostRepository PostRepository { get; }
    public IProductRepository ProductRepository { get; }
    public IProjectRepository ProjectRepository { get; }
    public IProjectPhaseRepository ProjectPhaseRepository { get; }
    public IServiceRepository ServiceRepository { get; }
    #endregion

    #region Constructors

    public UnitOfWork(AppDbContext appDbContext,
        IBoardMemberRepository boardMemberRepository,
        IBoardMemberSpeechRepository boardMemberSpeechRepository,
        IClientRepository clientRepository,
        ICompanyRepository companyRepository,
        ICompanyAddressRepository companyAddressRepository,
        IFormRepository formRepository,
        IHomeImageRepository homeImageRepository,
        IJobRepository jobRepository,
        IPhaseItemRepository phaseItemRepository,
        IPostRepository postRepository,
        IProductRepository productRepository,
        IProjectRepository projectRepository,
        IProjectPhaseRepository projectPhaseRepository,
        IServiceRepository serviceRepository)
    {
        AppDbContext = appDbContext;
        BoardMemberRepository = boardMemberRepository;
        BoardMemberSpeechRepository = boardMemberSpeechRepository;
        ClientRepository = clientRepository;
        CompanyRepository = companyRepository;
        CompanyAddressRepository = companyAddressRepository;
        FormRepository = formRepository;
        HomeImageRepository = homeImageRepository;
        JobRepository = jobRepository;
        PhaseItemRepository = phaseItemRepository;
        PostRepository = postRepository;
        ProductRepository = productRepository;
        ProjectRepository = projectRepository;
        ProjectPhaseRepository = projectPhaseRepository;
        ServiceRepository = serviceRepository;
    }


    #endregion

    #region Handle Functions
    public async Task<int> SaveChangesAsync()
    {
        return await AppDbContext.SaveChangesAsync();
    }
    #endregion




}
