using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Services.Commands.Models;
using Leha.Core.Resources;
using Leha.Manager.Managers.Services;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.Services.Commands.Handlers;

public class DeleteServiceCommandHandler : ResponseHandler, IRequestHandler<DeleteServiceCommand, Response<string>>
{

    #region Fields
    private readonly IServiceManager _serviceManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public DeleteServiceCommandHandler(IServiceManager serviceManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _serviceManager = serviceManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        var service = await _serviceManager.GetByIdAsync(request.ID);
        if (service == null) return NotFound<string>("");
        if (await _serviceManager.DeleteAsync(service))
            return Deleted<string>("");
        return BadRequest<string>();
    }

    #endregion
}