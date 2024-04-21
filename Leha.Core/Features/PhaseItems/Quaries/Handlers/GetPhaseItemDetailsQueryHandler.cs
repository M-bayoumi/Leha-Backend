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

public class GetPhaseItemDetailsQueryHandler : ResponseHandler, IRequestHandler<GetPhaseItemDetailsQuery, Response<GetPhaseItemDetailsResponse>>
{
    #region Fields
    private readonly IPhaseItemManager _phaseItemManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetPhaseItemDetailsQueryHandler(IPhaseItemManager phaseItemManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _phaseItemManager = phaseItemManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetPhaseItemDetailsResponse>> Handle(GetPhaseItemDetailsQuery request, CancellationToken cancellationToken)
    {
        var phaseItemDB = await _phaseItemManager.GetAll().Include(x => x.ProjectPhase).FirstOrDefaultAsync(x => x.Id == request.Id);

        if (phaseItemDB is null)
        {
            return NotFound<GetPhaseItemDetailsResponse>();
        }
        var phaseItemMapper = _mapper.Map<GetPhaseItemDetailsResponse>(phaseItemDB);
        return Success(phaseItemMapper);
    }
    #endregion

}
