﻿using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Services.Quaries.Models;
using Leha.Core.Features.Services.Quaries.Results;
using Leha.Core.Resources;
using Leha.Manager.Managers.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.Services.Quaries.Handlers;

public class GetServiceListQueryHandler : ResponseHandler, IRequestHandler<GetServiceListQuery, Response<List<GetServiceListResponse>>>
{
    #region Fields
    private readonly IServiceManager _serviceManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetServiceListQueryHandler(IServiceManager serviceManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _serviceManager = serviceManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetServiceListResponse>>> Handle(GetServiceListQuery request, CancellationToken cancellationToken)
    {
        var serviceListDB = await _serviceManager.GetAll().Include(x => x.Company).ToListAsync();
        if (serviceListDB is null)
        {
            return NotFound<List<GetServiceListResponse>>();
        }
        var serviceListMapper = _mapper.Map<List<GetServiceListResponse>>(serviceListDB);
        return Success(serviceListMapper);
    }
    #endregion

}