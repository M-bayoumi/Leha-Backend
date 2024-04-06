using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.HomeImages.Quaries.Models;
using Leha.Core.Features.HomeImages.Quaries.Results;
using Leha.Manager.Managers.HomeImages;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Leha.Core.Features.HomeImages.Quaries.Handlers;

public class GetHomeImageListQueryHandler : ResponseHandler, IRequestHandler<GetHomeImageListQuery, Response<List<GetHomeImageListResponse>>>
{
    #region Fields
    private readonly IHomeImageManager _homeImageManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetHomeImageListQueryHandler(IHomeImageManager homeImageManager, IMapper mapper)
    {
        _homeImageManager = homeImageManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetHomeImageListResponse>>> Handle(GetHomeImageListQuery request, CancellationToken cancellationToken)
    {
        var homeImageListDB = await _homeImageManager.GetHomeImagesListAsync().Include(x => x.Company).ToListAsync();
        if (homeImageListDB is null)
        {
            return NotFound<List<GetHomeImageListResponse>>();
        }
        var homeImageListMapper = _mapper.Map<List<GetHomeImageListResponse>>(homeImageListDB);
        return Success(homeImageListMapper);
    }
    #endregion

}