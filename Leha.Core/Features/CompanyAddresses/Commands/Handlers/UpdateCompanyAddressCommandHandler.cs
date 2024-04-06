using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.CompanyAddresses.Commands.Models;
using Leha.Data.Entities;
using Leha.Manager.Managers.Companies;
using Leha.Manager.Managers.CompanyAddresses;
using MediatR;

namespace Leha.Core.Features.CompanyAddresses.Commands.Handlers;

public class UpdateCompanyAddressCommandHandler : ResponseHandler, IRequestHandler<UpdateCompanyAddressCommand, Response<string>>
{

    #region Fields
    private readonly ICompanyAddressManager _companyAddressManager;
    private readonly ICompanyManager _companyManager;
    private readonly IMapper _mapper;

    #endregion

    #region Constructors

    public UpdateCompanyAddressCommandHandler(ICompanyAddressManager companyAddressManager, ICompanyManager companyManager, IMapper mapper)
    {
        _companyAddressManager = companyAddressManager;
        _companyManager = companyManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(UpdateCompanyAddressCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyManager.GetCompanyByIDAsync(request.CompanyID); // GetById without without include 
        if (company != null)
        {
            var companyAddress = _mapper.Map<CompanyAddress>(request);

            if (await _companyAddressManager.UpdateCompanyAddressAsync(companyAddress))
                return Created("CompanyAddress Updated Successfully");
            return BadRequest<string>("Failed To Update CompanyAddress");
        }
        return NotFound<string>("Company not found");
    }

    #endregion
}
