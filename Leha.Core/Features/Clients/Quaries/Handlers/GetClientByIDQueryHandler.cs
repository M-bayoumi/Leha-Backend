using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMemberSpeeches.Quaries.Models;
using Leha.Core.Features.Clients.Quaries.Models;
using Leha.Core.Features.Clients.Quaries.Results;
using Leha.Manager.Managers.BoardMemberSpeeches;
using Leha.Manager.Managers.Clients;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leha.Core.Features.Clients.Quaries.Handlers;


public class GetClientByIDQueryHandler : ResponseHandler, IRequestHandler<GetClientByIDQuery, Response<GetClientByIDResponse>>
{
    #region Fields
    private readonly IClientManager _clientManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetClientByIDQueryHandler(IClientManager clientManager, IMapper mapper)
    {
        _clientManager = clientManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetClientByIDResponse>> Handle(GetClientByIDQuery request, CancellationToken cancellationToken)
    {
        var clientDB = await _clientManager.GetClientsListAsync().Include(x => x.Company).FirstOrDefaultAsync(x => x.ID == request.ID);

        if (clientDB is null)
        {
            return NotFound<GetClientByIDResponse>();
        }
        var clientMapper = _mapper.Map<GetClientByIDResponse>(clientDB);
        return Success(clientMapper);
    }
    #endregion

}
