using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.HomeImages.Commands.Models;
using Leha.Core.Resources;
using Leha.Manager.Managers.HomeImages;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.HomeImages.Commands.Handlers;

public class DeleteHomeImageCommandHandler : ResponseHandler, IRequestHandler<DeleteHomeImageCommand, Response<string>>
{

    #region Fields
    private readonly IHomeImageManager _homeImageManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public DeleteHomeImageCommandHandler(IHomeImageManager homeImageManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _homeImageManager = homeImageManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(DeleteHomeImageCommand request, CancellationToken cancellationToken)
    {
        var homeImage = await _homeImageManager.GetByIdAsync(request.ID);
        if (homeImage == null) return NotFound<string>("");
        if (await _homeImageManager.DeleteAsync(homeImage))
            return Deleted<string>("");
        return BadRequest<string>();
    }

    #endregion
}