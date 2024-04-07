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

public class GetCompanyAddressListQueryHandler : ResponseHandler, IRequestHandler<GetCompanyAddressListQuery, Response<List<GetCompanyAddressListResponse>>>
{
    #region Fields
    private readonly ICompanyAddressManager _companyAddressManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetCompanyAddressListQueryHandler(ICompanyAddressManager companyAddressManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _companyAddressManager = companyAddressManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetCompanyAddressListResponse>>> Handle(GetCompanyAddressListQuery request, CancellationToken cancellationToken)
    {
        var companyAddressListDB = _companyAddressManager.GetCompanyAddressesListAsync().Include(x => x.Company).ToList();
        if (companyAddressListDB is null)
        {
            return NotFound<List<GetCompanyAddressListResponse>>();
        }
        var companyAddressListMapper = _mapper.Map<List<GetCompanyAddressListResponse>>(companyAddressListDB);
        return Success(companyAddressListMapper);
    }
    #endregion

}