using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Clients.Commands.Models;
using Leha.Core.Resources;
using Leha.Manager.Managers.Clients;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.Clients.Commands.Handlers;

public class DeleteClientCommandHandler : ResponseHandler, IRequestHandler<DeleteClientCommand, Response<string>>
{

    #region Fields
    private readonly IClientManager _clientManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public DeleteClientCommandHandler(IClientManager clientManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _clientManager = clientManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        var client = await _clientManager.GetClientByIDAsync(request.ID);
        if (client == null) return NotFound<string>("");
        if (await _clientManager.DeleteClientAsync(client))
            return Deleted<string>("");
        return BadRequest<string>();
    }

    #endregion
}