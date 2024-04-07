using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.PhaseItems.Commands.Models;
using Leha.Core.Resources;
using Leha.Data.Entities;
using Leha.Manager.Managers.PhaseItems;
using Leha.Manager.Managers.ProjectPhases;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.PhaseItems.Commands.Handlers;


public class AddPhaseItemCommandHandler : ResponseHandler, IRequestHandler<AddPhaseItemCommand, Response<string>>
{

    #region Fields
    private readonly IPhaseItemManager _phaseItemManager;
    private readonly IProjectPhaseManager _projectPhaseManager;
    private readonly IMapper _mapper;

    #endregion

    #region Constructors

    public AddPhaseItemCommandHandler(IPhaseItemManager phaseItemManager, IProjectPhaseManager projectPhaseManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _phaseItemManager = phaseItemManager;
        _projectPhaseManager = projectPhaseManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(AddPhaseItemCommand request, CancellationToken cancellationToken)
    {
        var projectPhase = await _projectPhaseManager.GetProjectPhaseByIDAsync(request.ProjectPhaseID);
        if (projectPhase != null)
        {
            var phaseItem = _mapper.Map<PhaseItem>(request);

            if (await _phaseItemManager.AddPhaseItemAsync(phaseItem))
                return Created("");
            return BadRequest<string>("");
        }
        return NotFound<string>("");
    }

    #endregion
}
