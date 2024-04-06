using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.CompanyAddresses.Commands.Models;
using Leha.Manager.Managers.CompanyAddresses;
using MediatR;

namespace Leha.Core.Features.CompanyAddresses.Commands.Handlers;

public class DeleteCompanyAddressCommandHandler : ResponseHandler, IRequestHandler<DeleteCompanyAddressCommand, Response<string>>
{

    #region Fields
    private readonly ICompanyAddressManager _companyAddressManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public DeleteCompanyAddressCommandHandler(ICompanyAddressManager companyAddressManager, IMapper mapper)
    {
        _companyAddressManager = companyAddressManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(DeleteCompanyAddressCommand request, CancellationToken cancellationToken)
    {
        var companyAddress = await _companyAddressManager.GetCompanyAddressByIDAsync(request.ID);
        if (companyAddress == null) return NotFound<string>("Company Address not found");
        return await _companyAddressManager.DeleteCompanyAddressAsync(companyAddress) ? Deleted<string>("Deleted Successfully") : BadRequest<string>();
    }

    #endregion
}