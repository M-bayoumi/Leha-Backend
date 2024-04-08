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


public class GetServiceByIdQueryHandler : ResponseHandler, IRequestHandler<GetServiceByIdQuery, Response<GetServiceByIdResponse>>
{
    #region Fields
    private readonly IServiceManager _serviceManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetServiceByIdQueryHandler(IServiceManager serviceManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _serviceManager = serviceManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetServiceByIdResponse>> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
    {
        var serviceDB = await _serviceManager.GetAll().Include(x => x.Company).FirstOrDefaultAsync(x => x.ID == request.ID);

        if (serviceDB is null)
        {
            return NotFound<GetServiceByIdResponse>();
        }
        var serviceMapper = _mapper.Map<GetServiceByIdResponse>(serviceDB);
        return Success(serviceMapper);
    }
    #endregion

}
