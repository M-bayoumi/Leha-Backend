using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.CompanyAddresses.Commands.Models;
using Leha.Core.Resources;
using Leha.Manager.Managers.CompanyAddresses;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.CompanyAddresses.Commands.Handlers;

public class DeleteCompanyAddressCommandHandler : ResponseHandler, IRequestHandler<DeleteCompanyAddressCommand, Response<string>>
{

    #region Fields
    private readonly ICompanyAddressManager _companyAddressManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public DeleteCompanyAddressCommandHandler(ICompanyAddressManager companyAddressManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _companyAddressManager = companyAddressManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(DeleteCompanyAddressCommand request, CancellationToken cancellationToken)
    {
        var companyAddress = await _companyAddressManager.GetByIdAsync(request.ID);
        if (companyAddress == null) return NotFound<string>("");
        if (await _companyAddressManager.DeleteAsync(companyAddress))
            return Deleted<string>("");
        return BadRequest<string>();
    }

    #endregion
}