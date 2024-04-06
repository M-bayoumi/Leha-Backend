using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.CompanyAddresses.Commands.Models;
using Leha.Data.Entities;
using Leha.Manager.Managers.Companies;
using Leha.Manager.Managers.CompanyAddresses;
using MediatR;

namespace Leha.Core.Features.CompanyAddresses.Commands.Handlers;


public class AddCompanyAddressCommandHandler : ResponseHandler, IRequestHandler<AddCompanyAddressCommand, Response<string>>
{

    #region Fields
    private readonly ICompanyAddressManager _companyAddressManager;
    private readonly ICompanyManager _companyManager;
    private readonly IMapper _mapper;

    #endregion

    #region Constructors

    public AddCompanyAddressCommandHandler(ICompanyAddressManager companyAddressManager, ICompanyManager companyManager, IMapper mapper)
    {
        _companyAddressManager = companyAddressManager;
        _companyManager = companyManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(AddCompanyAddressCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyManager.GetCompanyByIDAsync(request.CompanyID); // GetById without without include 
        if (company != null)
        {
            var companyAddress = _mapper.Map<CompanyAddress>(request);

            if (await _companyAddressManager.AddCompanyAddressAsync(companyAddress))
                return Created("CompanyAddress Added Successfully");
            return BadRequest<string>("Failed To Add CompanyAddress");
        }
        return NotFound<string>("Company not found");
    }

    #endregion
}
