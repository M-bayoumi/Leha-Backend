using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Services.Quaries.Models;
using Leha.Core.Features.Services.Quaries.Results;
using Leha.Core.Resources;
using Leha.Manager.Managers.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.Services.Quaries.Handlers;

public class GetServiceListByCompanyIDQueryHandler : ResponseHandler, IRequestHandler<GetServiceListByCompanyIDQuery, Response<List<GetServiceListByCompanyIDResponse>>>
{
    #region Fields
    private readonly IServiceManager _serviceManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetServiceListByCompanyIDQueryHandler(IServiceManager serviceManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _serviceManager = serviceManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetServiceListByCompanyIDResponse>>> Handle(GetServiceListByCompanyIDQuery request, CancellationToken cancellationToken)
    {
        var serviceListDB = await _serviceManager.GetAllByCompanyId(request.Id).Include(x => x.Company).ToListAsync();
        if (serviceListDB is null)
        {
            return NotFound<List<GetServiceListByCompanyIDResponse>>();
        }
        var serviceListMapper = _mapper.Map<List<GetServiceListByCompanyIDResponse>>(serviceListDB);
        return Success(serviceListMapper);
    }
    #endregion

}
