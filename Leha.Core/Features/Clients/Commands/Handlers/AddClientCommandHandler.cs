using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Clients.Commands.Models;
using Leha.Data.Entities;
using Leha.Manager.Managers.Clients;
using MediatR;

namespace Leha.Core.Features.Clients.Commands.Handlers;


public class AddClientCommandHandler : ResponseHandler, IRequestHandler<AddClientCommand, Response<string>>
{

    #region Fields
    private readonly IClientManager _clientManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public AddClientCommandHandler(IClientManager clientManager, IMapper mapper)
    {
        _clientManager = clientManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(AddClientCommand request, CancellationToken cancellationToken)
    {
        var client = _mapper.Map<Client>(request);

        if (await _clientManager.AddClientAsync(client))
            return Created("Client Added Successfully");

        return BadRequest<string>("Failed To Add Client");
    }

    #endregion
}
