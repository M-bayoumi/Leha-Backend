using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.ProjectPhases.Commands.Models;
using Leha.Core.Resources;
using Leha.Manager.Managers.ProjectPhases;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.ProjectPhases.Commands.Handlers;

public class DeleteProjectPhaseCommandHandler : ResponseHandler, IRequestHandler<DeleteProjectPhaseCommand, Response<string>>
{

    #region Fields
    private readonly IProjectPhaseManager _projectPhaseManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public DeleteProjectPhaseCommandHandler(IProjectPhaseManager projectPhaseManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _projectPhaseManager = projectPhaseManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(DeleteProjectPhaseCommand request, CancellationToken cancellationToken)
    {
        var projectPhase = await _projectPhaseManager.GetByIdAsync(request.Id);
        if (projectPhase == null) return NotFound<string>("");
        if (await _projectPhaseManager.DeleteAsync(projectPhase))
            return Deleted<string>("");
        return BadRequest<string>();
    }

    #endregion
}