using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Projects.Commands.Models;
using Leha.Data.Entities;
using Leha.Manager.Managers.Projects;
using Leha.Manager.Managers.Companies;
using MediatR;

namespace Leha.Core.Features.Projects.Commands.Handlers;

public class UpdateProjectCommandHandler : ResponseHandler, IRequestHandler<UpdateProjectCommand, Response<string>>
{

    #region Fields
    private readonly IProjectManager _projectManager;
    private readonly ICompanyManager _companyManager;
    private readonly IMapper _mapper;

    #endregion

    #region Constructors

    public UpdateProjectCommandHandler(IProjectManager projectManager, ICompanyManager companyManager, IMapper mapper)
    {
        _projectManager = projectManager;
        _companyManager = companyManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyManager.GetCompanyByIDAsync(request.CompanyID); // GetById without without include 
        if (company != null)
        {
            var project = _mapper.Map<Project>(request);

            if (await _projectManager.UpdateProjectAsync(project))
                return Created("Project Updated Successfully");
            return BadRequest<string>("Failed To Update Project");
        }
        return NotFound<string>("Company not found");
    }

    #endregion
}
