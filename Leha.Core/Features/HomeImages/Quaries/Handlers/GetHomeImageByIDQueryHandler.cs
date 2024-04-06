using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.HomeImages.Quaries.Models;
using Leha.Core.Features.HomeImages.Quaries.Results;
using Leha.Manager.Managers.HomeImages;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Leha.Core.Features.HomeImages.Quaries.Handlers;


public class GetHomeImageByIDQueryHandler : ResponseHandler, IRequestHandler<GetHomeImageByIDQuery, Response<GetHomeImageByIDResponse>>
{
    #region Fields
    private readonly IHomeImageManager _homeImageManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetHomeImageByIDQueryHandler(IHomeImageManager homeImageManager, IMapper mapper)
    {
        _homeImageManager = homeImageManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetHomeImageByIDResponse>> Handle(GetHomeImageByIDQuery request, CancellationToken cancellationToken)
    {
        var homeImageDB = await _homeImageManager.GetHomeImagesListAsync().Include(x => x.Company).FirstOrDefaultAsync(x => x.ID == request.ID);

        if (homeImageDB is null)
        {
            return NotFound<GetHomeImageByIDResponse>();
        }
        var homeImageMapper = _mapper.Map<GetHomeImageByIDResponse>(homeImageDB);
        return Success(homeImageMapper);
    }
    #endregion

}
