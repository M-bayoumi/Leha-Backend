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


public class GetCompanyAddressByIDQueryHandler : ResponseHandler, IRequestHandler<GetCompanyAddressByIDQuery, Response<GetCompanyAddressByIDResponse>>
{
    #region Fields
    private readonly ICompanyAddressManager _companyAddressManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetCompanyAddressByIDQueryHandler(ICompanyAddressManager companyAddressManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _companyAddressManager = companyAddressManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetCompanyAddressByIDResponse>> Handle(GetCompanyAddressByIDQuery request, CancellationToken cancellationToken)
    {
        var companyAddresstDB = await _companyAddressManager.GetCompanyAddressesListAsync().Include(x => x.Company).FirstOrDefaultAsync(x => x.ID == request.ID);

        if (companyAddresstDB is null)
        {
            return NotFound<GetCompanyAddressByIDResponse>();
        }
        var companyAddressMapper = _mapper.Map<GetCompanyAddressByIDResponse>(companyAddresstDB);
        return Success(companyAddressMapper);
    }
    #endregion

}
