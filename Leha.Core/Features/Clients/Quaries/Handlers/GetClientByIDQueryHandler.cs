using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Clients.Quaries.Models;
using Leha.Core.Features.Clients.Quaries.Results;
using Leha.Core.Resources;
using Leha.Manager.Managers.Clients;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.Clients.Quaries.Handlers;


public class GetClientByIdQueryHandler : ResponseHandler, IRequestHandler<GetClientByIdQuery, Response<GetClientByIdResponse>>
{
    #region Fields
    private readonly IClientManager _clientManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetClientByIdQueryHandler(IClientManager clientManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _clientManager = clientManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetClientByIdResponse>> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        var clientDB = await _clientManager.GetAll().Include(x => x.Company).FirstOrDefaultAsync(x => x.Id == request.Id);

        if (clientDB is null)
        {
            return NotFound<GetClientByIdResponse>();
        }
        var clientMapper = _mapper.Map<GetClientByIdResponse>(clientDB);
        return Success(clientMapper);
    }
    #endregion

}
