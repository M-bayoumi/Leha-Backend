using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.PhaseItems.Commands.Models;
using Leha.Core.Resources;
using Leha.Manager.Managers.PhaseItems;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.PhaseItems.Commands.Handlers;

public class DeletePhaseItemCommandHandler : ResponseHandler, IRequestHandler<DeletePhaseItemCommand, Response<string>>
{

    #region Fields
    private readonly IPhaseItemManager _phaseItemManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public DeletePhaseItemCommandHandler(IPhaseItemManager phaseItemManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _phaseItemManager = phaseItemManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(DeletePhaseItemCommand request, CancellationToken cancellationToken)
    {
        var phaseItem = await _phaseItemManager.GetPhaseItemByIDAsync(request.ID);
        if (phaseItem == null) return NotFound<string>("");
        if (await _phaseItemManager.DeletePhaseItemAsync(phaseItem))
            return Deleted<string>("");
        return BadRequest<string>();
    }

    #endregion
}