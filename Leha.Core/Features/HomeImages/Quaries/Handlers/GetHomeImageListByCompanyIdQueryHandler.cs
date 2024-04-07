﻿using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.HomeImages.Quaries.Models;
using Leha.Core.Features.HomeImages.Quaries.Results;
using Leha.Core.Resources;
using Leha.Manager.Managers.HomeImages;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.HomeImages.Quaries.Handlers;

public class GetHomeImageListByCompanyIdQueryHandler : ResponseHandler, IRequestHandler<GetHomeImageListByCompanyIdQuery, Response<List<GetHomeImageListByCompanyIDResponse>>>
{
    #region Fields
    private readonly IHomeImageManager _homeImageManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetHomeImageListByCompanyIdQueryHandler(IHomeImageManager homeImageManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _homeImageManager = homeImageManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetHomeImageListByCompanyIDResponse>>> Handle(GetHomeImageListByCompanyIdQuery request, CancellationToken cancellationToken)
    {
        var homeImageListDB = await _homeImageManager.GetHomeImagesListByCompanyId(request.ID).Include(x => x.Company).ToListAsync();
        if (homeImageListDB is null)
        {
            return NotFound<List<GetHomeImageListByCompanyIDResponse>>();
        }
        var homeImageListMapper = _mapper.Map<List<GetHomeImageListByCompanyIDResponse>>(homeImageListDB);
        return Success(homeImageListMapper);
    }
    #endregion

}
