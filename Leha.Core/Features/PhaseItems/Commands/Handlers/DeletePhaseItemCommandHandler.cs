using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.PhaseItems.Commands.Models;
using Leha.Manager.Managers.PhaseItems;
using MediatR;

namespace Leha.Core.Features.PhaseItems.Commands.Handlers;

public class DeletePhaseItemCommandHandler : ResponseHandler, IRequestHandler<DeletePhaseItemCommand, Response<string>>
{

    #region Fields
    private readonly IPhaseItemManager _phaseItemManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public DeletePhaseItemCommandHandler(IPhaseItemManager phaseItemManager, IMapper mapper)
    {
        _phaseItemManager = phaseItemManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(DeletePhaseItemCommand request, CancellationToken cancellationToken)
    {
        var phaseItem = await _phaseItemManager.GetPhaseItemByIDAsync(request.ID);
        if (phaseItem == null) return NotFound<string>("PhaseItem not found");
        return await _phaseItemManager.DeletePhaseItemAsync(phaseItem) ? Deleted<string>("Deleted Successfully") : BadRequest<string>();
    }

    #endregion
}