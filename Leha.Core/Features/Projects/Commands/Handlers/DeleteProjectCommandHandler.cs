using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Projects.Commands.Models;
using Leha.Manager.Managers.Projects;
using MediatR;

namespace Leha.Core.Features.Projects.Commands.Handlers;

public class DeleteProjectCommandHandler : ResponseHandler, IRequestHandler<DeleteProjectCommand, Response<string>>
{

    #region Fields
    private readonly IProjectManager _projectManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public DeleteProjectCommandHandler(IProjectManager projectManager, IMapper mapper)
    {
        _projectManager = projectManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _projectManager.GetProjectByIDAsync(request.ID);
        if (project == null) return NotFound<string>("Project not found");
        return await _projectManager.DeleteProjectAsync(project) ? Deleted<string>("Deleted Successfully") : BadRequest<string>();
    }

    #endregion
}