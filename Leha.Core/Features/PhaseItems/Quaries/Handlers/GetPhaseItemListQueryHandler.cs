using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.PhaseItems.Quaries.Models;
using Leha.Core.Features.PhaseItems.Quaries.Results;
using Leha.Manager.Managers.PhaseItems;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Leha.Core.Features.PhaseItems.Quaries.Handlers;

public class GetPhaseItemListQueryHandler : ResponseHandler, IRequestHandler<GetPhaseItemListQuery, Response<List<GetPhaseItemListResponse>>>
{
    #region Fields
    private readonly IPhaseItemManager _phaseItemManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetPhaseItemListQueryHandler(IPhaseItemManager phaseItemManager, IMapper mapper)
    {
        _phaseItemManager = phaseItemManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetPhaseItemListResponse>>> Handle(GetPhaseItemListQuery request, CancellationToken cancellationToken)
    {
        var phaseItemListDB = await _phaseItemManager.GetPhaseItemsListAsync().Include(x => x.ProjectPhase).ToListAsync();
        if (phaseItemListDB is null)
        {
            return NotFound<List<GetPhaseItemListResponse>>();
        }
        var phaseItemListMapper = _mapper.Map<List<GetPhaseItemListResponse>>(phaseItemListDB);
        return Success(phaseItemListMapper);
    }
    #endregion

}