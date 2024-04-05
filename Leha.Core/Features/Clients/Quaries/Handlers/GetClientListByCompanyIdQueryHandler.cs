using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Clients.Quaries.Models;
using Leha.Core.Features.Clients.Quaries.Results;
using Leha.Manager.Managers.Clients;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Leha.Core.Features.Clients.Quaries.Handlers;

public class GetClientListByCompanyIdQueryHandler : ResponseHandler, IRequestHandler<GetClientListByCompanyIdQuery, Response<List<GetClientListByCompanyIDResponse>>>
{
    #region Fields
    private readonly IClientManager _clientManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetClientListByCompanyIdQueryHandler(IClientManager clientManager, IMapper mapper)
    {
        _clientManager = clientManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetClientListByCompanyIDResponse>>> Handle(GetClientListByCompanyIdQuery request, CancellationToken cancellationToken)
    {
        var clientListDB = await _clientManager.GetClientsListByCompanyId(request.ID).Include(x => x.Company).ToListAsync();
        if (clientListDB is null)
        {
            return NotFound<List<GetClientListByCompanyIDResponse>>();
        }
        var clientListMapper = _mapper.Map<List<GetClientListByCompanyIDResponse>>(clientListDB);
        return Success(clientListMapper);
    }
    #endregion

}
