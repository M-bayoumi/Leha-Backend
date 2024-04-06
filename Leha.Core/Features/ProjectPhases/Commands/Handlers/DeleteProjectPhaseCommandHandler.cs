using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.ProjectPhases.Commands.Models;
using Leha.Manager.Managers.ProjectPhases;
using MediatR;

namespace Leha.Core.Features.ProjectPhases.Commands.Handlers;

public class DeleteProjectPhaseCommandHandler : ResponseHandler, IRequestHandler<DeleteProjectPhaseCommand, Response<string>>
{

    #region Fields
    private readonly IProjectPhaseManager _projectPhaseManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public DeleteProjectPhaseCommandHandler(IProjectPhaseManager projectPhaseManager, IMapper mapper)
    {
        _projectPhaseManager = projectPhaseManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(DeleteProjectPhaseCommand request, CancellationToken cancellationToken)
    {
        var projectPhase = await _projectPhaseManager.GetProjectPhaseByIDAsync(request.ID);
        if (projectPhase == null) return NotFound<string>("ProjectPhase not found");
        return await _projectPhaseManager.DeleteProjectPhaseAsync(projectPhase) ? Deleted<string>("Deleted Successfully") : BadRequest<string>();
    }

    #endregion
}