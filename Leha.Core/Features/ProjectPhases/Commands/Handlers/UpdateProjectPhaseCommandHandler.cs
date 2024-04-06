using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.ProjectPhases.Commands.Models;
using Leha.Data.Entities;
using Leha.Manager.Managers.ProjectPhases;
using Leha.Manager.Managers.Projects;
using MediatR;

namespace Leha.Core.Features.ProjectPhases.Commands.Handlers;

public class UpdateProjectPhaseCommandHandler : ResponseHandler, IRequestHandler<UpdateProjectPhaseCommand, Response<string>>
{

    #region Fields
    private readonly IProjectPhaseManager _projectPhaseManager;
    private readonly IProjectManager _projectManager;
    private readonly IMapper _mapper;

    #endregion

    #region Constructors

    public UpdateProjectPhaseCommandHandler(IProjectPhaseManager projectPhaseManager, IProjectManager projectManager, IMapper mapper)
    {
        _projectPhaseManager = projectPhaseManager;
        _projectManager = projectManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(UpdateProjectPhaseCommand request, CancellationToken cancellationToken)
    {
        var project = await _projectManager.GetProjectByIDAsync(request.ProjectID); // GetById without without include 
        if (project != null)
        {
            var projectPhase = _mapper.Map<ProjectPhase>(request);

            if (await _projectPhaseManager.UpdateProjectPhaseAsync(projectPhase))
                return Created("ProjectPhase Updated Successfully");
            return BadRequest<string>("Failed To Update ProjectPhase");
        }
        return NotFound<string>("Project not found");
    }

    #endregion
}
