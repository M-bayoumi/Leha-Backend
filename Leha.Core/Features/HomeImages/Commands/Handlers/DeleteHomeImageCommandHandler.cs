using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.HomeImages.Commands.Models;
using Leha.Manager.Managers.HomeImages;
using MediatR;

namespace Leha.Core.Features.HomeImages.Commands.Handlers;

public class DeleteHomeImageCommandHandler : ResponseHandler, IRequestHandler<DeleteHomeImageCommand, Response<string>>
{

    #region Fields
    private readonly IHomeImageManager _homeImageManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public DeleteHomeImageCommandHandler(IHomeImageManager homeImageManager, IMapper mapper)
    {
        _homeImageManager = homeImageManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(DeleteHomeImageCommand request, CancellationToken cancellationToken)
    {
        var homeImage = await _homeImageManager.GetHomeImageByIDAsync(request.ID);
        if (homeImage == null) return NotFound<string>("HomeImage not found");
        return await _homeImageManager.DeleteHomeImageAsync(homeImage) ? Deleted<string>("Deleted Successfully") : BadRequest<string>();
    }

    #endregion
}