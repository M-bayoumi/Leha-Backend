﻿using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.PhaseItems.Quaries.Models;
using Leha.Core.Features.PhaseItems.Quaries.Results;
using Leha.Core.Resources;
using Leha.Manager.Managers.PhaseItems;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.PhaseItems.Quaries.Handlers;

public class GetPhaseItemListByProjectPhaseIDQueryHandler : ResponseHandler, IRequestHandler<GetPhaseItemListByProjectPhaseIDQuery, Response<List<GetPhaseItemListByProjectPhaseIDResponse>>>
{
    #region Fields
    private readonly IPhaseItemManager _phaseItemManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetPhaseItemListByProjectPhaseIDQueryHandler(IPhaseItemManager phaseItemManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _phaseItemManager = phaseItemManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetPhaseItemListByProjectPhaseIDResponse>>> Handle(GetPhaseItemListByProjectPhaseIDQuery request, CancellationToken cancellationToken)
    {
        var phaseItemListDB = await _phaseItemManager.GetAllByProjectPhaseID(request.Id).Include(x => x.ProjectPhase).ToListAsync();
        if (phaseItemListDB is null)
        {
            return NotFound<List<GetPhaseItemListByProjectPhaseIDResponse>>();
        }
        var phaseItemListMapper = _mapper.Map<List<GetPhaseItemListByProjectPhaseIDResponse>>(phaseItemListDB);
        return Success(phaseItemListMapper);
    }
    #endregion

}
