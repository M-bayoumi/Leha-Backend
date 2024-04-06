using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Services.Commands.Models;
using Leha.Manager.Managers.Services;
using MediatR;

namespace Leha.Core.Features.Services.Commands.Handlers;

public class DeleteServiceCommandHandler : ResponseHandler, IRequestHandler<DeleteServiceCommand, Response<string>>
{

    #region Fields
    private readonly IServiceManager _serviceManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public DeleteServiceCommandHandler(IServiceManager serviceManager, IMapper mapper)
    {
        _serviceManager = serviceManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        var service = await _serviceManager.GetServiceByIDAsync(request.ID);
        if (service == null) return NotFound<string>("Service not found");
        return await _serviceManager.DeleteServiceAsync(service) ? Deleted<string>("Deleted Successfully") : BadRequest<string>();
    }

    #endregion
}