using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Services.Commands.Models;
using Leha.Core.Resources;
using Leha.Data.Entities;
using Leha.Manager.Managers.Companies;
using Leha.Manager.Managers.Services;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.Services.Commands.Handlers;

public class UpdateServiceCommandHandler : ResponseHandler, IRequestHandler<UpdateServiceCommand, Response<string>>
{

    #region Fields
    private readonly IServiceManager _serviceManager;
    private readonly ICompanyManager _companyManager;
    private readonly IMapper _mapper;

    #endregion

    #region Constructors

    public UpdateServiceCommandHandler(IServiceManager serviceManager, ICompanyManager companyManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _serviceManager = serviceManager;
        _companyManager = companyManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyManager.GetByIdAsync(request.CompanyID);
        if (company != null)
        {
            var service = _mapper.Map<Service>(request);

            if (await _serviceManager.UpdateAsync(service))
                return Created("");
            return BadRequest<string>("");
        }
        return NotFound<string>("");
    }

    #endregion
}
