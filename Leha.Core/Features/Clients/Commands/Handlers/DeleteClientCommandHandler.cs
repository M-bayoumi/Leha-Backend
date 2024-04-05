using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Clients.Commands.Models;
using Leha.Manager.Managers.Clients;
using MediatR;

namespace Leha.Core.Features.Clients.Commands.Handlers;

public class DeleteClientCommandHandler : ResponseHandler, IRequestHandler<DeleteClientCommand, Response<string>>
{

    #region Fields
    private readonly IClientManager _clientManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public DeleteClientCommandHandler(IClientManager clientManager, IMapper mapper)
    {
        _clientManager = clientManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        var client = await _clientManager.GetClientByIDAsync(request.ID);
        if (client == null) return NotFound<string>("Client not found");
        return await _clientManager.DeleteClientAsync(client) ? Deleted<string>("Deleted Successfully") : BadRequest<string>();
    }

    #endregion
}