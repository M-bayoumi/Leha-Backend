using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.CompanyAddresses.Quaries.Models;
using Leha.Core.Features.CompanyAddresses.Quaries.Results;
using Leha.Core.Resources;
using Leha.Manager.Managers.CompanyAddresses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.CompanyAddresses.Quaries.Handlers;

public class GetCompanyAddressDetailsQueryHandler : ResponseHandler, IRequestHandler<GetCompanyAddressDetailsQuery, Response<GetCompanyAddressDetailsResponse>>
{
    #region Fields
    private readonly ICompanyAddressManager _companyAddressManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetCompanyAddressDetailsQueryHandler(ICompanyAddressManager companyAddressManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _companyAddressManager = companyAddressManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetCompanyAddressDetailsResponse>> Handle(GetCompanyAddressDetailsQuery request, CancellationToken cancellationToken)
    {
        var companyAddresstDB = await _companyAddressManager.GetAll().Include(x => x.Company).FirstOrDefaultAsync(x => x.Id == request.Id);

        if (companyAddresstDB is null)
        {
            return NotFound<GetCompanyAddressDetailsResponse>();
        }
        var companyAddressMapper = _mapper.Map<GetCompanyAddressDetailsResponse>(companyAddresstDB);
        return Success(companyAddressMapper);
    }
    #endregion

}
