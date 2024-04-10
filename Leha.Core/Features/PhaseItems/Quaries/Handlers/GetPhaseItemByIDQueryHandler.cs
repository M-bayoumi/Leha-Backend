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


public class GetPhaseItemByIdQueryHandler : ResponseHandler, IRequestHandler<GetPhaseItemByIdQuery, Response<GetPhaseItemByIdResponse>>
{
    #region Fields
    private readonly IPhaseItemManager _phaseItemManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetPhaseItemByIdQueryHandler(IPhaseItemManager phaseItemManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _phaseItemManager = phaseItemManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetPhaseItemByIdResponse>> Handle(GetPhaseItemByIdQuery request, CancellationToken cancellationToken)
    {
        var phaseItemDB = await _phaseItemManager.GetAll().Include(x => x.ProjectPhase).FirstOrDefaultAsync(x => x.Id == request.Id);

        if (phaseItemDB is null)
        {
            return NotFound<GetPhaseItemByIdResponse>();
        }
        var phaseItemMapper = _mapper.Map<GetPhaseItemByIdResponse>(phaseItemDB);
        return Success(phaseItemMapper);
    }
    #endregion

}
