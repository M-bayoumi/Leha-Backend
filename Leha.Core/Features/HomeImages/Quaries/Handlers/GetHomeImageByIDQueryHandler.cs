using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.HomeImages.Quaries.Models;
using Leha.Core.Features.HomeImages.Quaries.Results;
using Leha.Core.Resources;
using Leha.Manager.Managers.HomeImages;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.HomeImages.Quaries.Handlers;


public class GetHomeImageByIdQueryHandler : ResponseHandler, IRequestHandler<GetHomeImageByIdQuery, Response<GetHomeImageByIdResponse>>
{
    #region Fields
    private readonly IHomeImageManager _homeImageManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetHomeImageByIdQueryHandler(IHomeImageManager homeImageManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _homeImageManager = homeImageManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetHomeImageByIdResponse>> Handle(GetHomeImageByIdQuery request, CancellationToken cancellationToken)
    {
        var homeImageDB = await _homeImageManager.GetAll().Include(x => x.Company).FirstOrDefaultAsync(x => x.Id == request.Id);

        if (homeImageDB is null)
        {
            return NotFound<GetHomeImageByIdResponse>();
        }
        var homeImageMapper = _mapper.Map<GetHomeImageByIdResponse>(homeImageDB);
        return Success(homeImageMapper);
    }
    #endregion

}
