using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.PhaseItems.Quaries.Models;
using Leha.Core.Features.PhaseItems.Quaries.Results;
using Leha.Core.Resources;
using Leha.Manager.Managers.PhaseItems;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.PhaseItems.Quaries.Handlers;


public class GetPhaseItemByIDQueryHandler : ResponseHandler, IRequestHandler<GetPhaseItemByIDQuery, Response<GetPhaseItemByIDResponse>>
{
    #region Fields
    private readonly IPhaseItemManager _phaseItemManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetPhaseItemByIDQueryHandler(IPhaseItemManager phaseItemManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _phaseItemManager = phaseItemManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetPhaseItemByIDResponse>> Handle(GetPhaseItemByIDQuery request, CancellationToken cancellationToken)
    {
        var phaseItemDB = await _phaseItemManager.GetPhaseItemsListAsync().Include(x => x.ProjectPhase).FirstOrDefaultAsync(x => x.ID == request.ID);

        if (phaseItemDB is null)
        {
            return NotFound<GetPhaseItemByIDResponse>();
        }
        var phaseItemMapper = _mapper.Map<GetPhaseItemByIDResponse>(phaseItemDB);
        return Success(phaseItemMapper);
    }
    #endregion

}
