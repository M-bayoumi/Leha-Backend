using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Projects.Commands.Models;
using Leha.Data.Entities;
using Leha.Manager.Managers.Companies;
using Leha.Manager.Managers.Projects;
using MediatR;

namespace Leha.Core.Features.Projects.Commands.Handlers;


public class AddProjectCommandHandler : ResponseHandler, IRequestHandler<AddProjectCommand, Response<string>>
{

    #region Fields
    private readonly IProjectManager _projectManager;
    private readonly ICompanyManager _companyManager;
    private readonly IMapper _mapper;

    #endregion

    #region Constructors

    public AddProjectCommandHandler(IProjectManager projectManager, ICompanyManager companyManager, IMapper mapper)
    {
        _projectManager = projectManager;
        _companyManager = companyManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(AddProjectCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyManager.GetCompanyByIDAsync(request.CompanyID); // GetById without without include 
        if (company != null)
        {
            var project = _mapper.Map<Project>(request);

            if (await _projectManager.AddProjectAsync(project))
                return Created("Project Added Successfully");
            return BadRequest<string>("Failed To Add Project");
        }
        return NotFound<string>("Company not found");
    }

    #endregion
}
