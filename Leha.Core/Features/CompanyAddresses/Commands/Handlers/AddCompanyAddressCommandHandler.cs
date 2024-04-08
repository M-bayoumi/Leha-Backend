using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.CompanyAddresses.Commands.Models;
using Leha.Core.Resources;
using Leha.Data.Entities;
using Leha.Manager.Managers.Companies;
using Leha.Manager.Managers.CompanyAddresses;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.CompanyAddresses.Commands.Handlers;


public class AddCompanyAddressCommandHandler : ResponseHandler, IRequestHandler<AddCompanyAddressCommand, Response<string>>
{

    #region Fields
    private readonly ICompanyAddressManager _companyAddressManager;
    private readonly ICompanyManager _companyManager;
    private readonly IMapper _mapper;

    #endregion

    #region Constructors

    public AddCompanyAddressCommandHandler(ICompanyAddressManager companyAddressManager, ICompanyManager companyManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _companyAddressManager = companyAddressManager;
        _companyManager = companyManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(AddCompanyAddressCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyManager.GetByIdAsync(request.CompanyID);
        if (company != null)
        {
            var companyAddress = _mapper.Map<CompanyAddress>(request);

            if (await _companyAddressManager.AddAsync(companyAddress))
                return Created("");
            return BadRequest<string>("");
        }
        return NotFound<string>("");
    }

    #endregion
}
