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


public class GetServiceByIDQueryHandler : ResponseHandler, IRequestHandler<GetServiceByIDQuery, Response<GetServiceByIDResponse>>
{
    #region Fields
    private readonly IServiceManager _serviceManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetServiceByIDQueryHandler(IServiceManager serviceManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _serviceManager = serviceManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetServiceByIDResponse>> Handle(GetServiceByIDQuery request, CancellationToken cancellationToken)
    {
        var serviceDB = await _serviceManager.GetServicesListAsync().Include(x => x.Company).FirstOrDefaultAsync(x => x.ID == request.ID);

        if (serviceDB is null)
        {
            return NotFound<GetServiceByIDResponse>();
        }
        var serviceMapper = _mapper.Map<GetServiceByIDResponse>(serviceDB);
        return Success(serviceMapper);
    }
    #endregion

}
