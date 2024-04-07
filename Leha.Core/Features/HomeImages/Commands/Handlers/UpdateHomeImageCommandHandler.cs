using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.HomeImages.Commands.Models;
using Leha.Core.Resources;
using Leha.Data.Entities;
using Leha.Manager.Managers.HomeImages;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.HomeImages.Commands.Handlers;

public class UpdateHomeImageCommandHandler : ResponseHandler, IRequestHandler<UpdateHomeImageCommand, Response<string>>
{

    #region Fields
    private readonly IHomeImageManager _homeImageManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public UpdateHomeImageCommandHandler(IHomeImageManager homeImageManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _homeImageManager = homeImageManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(UpdateHomeImageCommand request, CancellationToken cancellationToken)
    {
        var homeImage = _mapper.Map<HomeImage>(request);

        if (await _homeImageManager.UpdateHomeImageAsync(homeImage))
            return Created("");

        return BadRequest<string>("");
    }

    #endregion
}
