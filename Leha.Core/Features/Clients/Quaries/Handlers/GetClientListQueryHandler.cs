﻿using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Clients.Quaries.Models;
using Leha.Core.Features.Clients.Quaries.Results;
using Leha.Core.Resources;
using Leha.Manager.Managers.Clients;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.Clients.Quaries.Handlers;

public class GetClientListQueryHandler : ResponseHandler, IRequestHandler<GetClientListQuery, Response<List<GetClientListResponse>>>
{
    #region Fields
    private readonly IClientManager _clientManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetClientListQueryHandler(IClientManager clientManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _clientManager = clientManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetClientListResponse>>> Handle(GetClientListQuery request, CancellationToken cancellationToken)
    {
        var clientListDB = await _clientManager.GetAll().Include(x => x.Company).ToListAsync();
        if (clientListDB is null)
        {
            return NotFound<List<GetClientListResponse>>();
        }
        var clientListMapper = _mapper.Map<List<GetClientListResponse>>(clientListDB);
        return Success(clientListMapper);
    }
    #endregion

}