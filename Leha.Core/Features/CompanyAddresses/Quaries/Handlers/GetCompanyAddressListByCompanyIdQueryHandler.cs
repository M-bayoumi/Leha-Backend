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

public class GetCompanyAddressListByCompanyIDQueryHandler : ResponseHandler, IRequestHandler<GetCompanyAddressListByCompanyIDQuery, Response<List<GetCompanyAddressListByCompanyIDResponse>>>
{
    #region Fields
    private readonly ICompanyAddressManager _companyAddressManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetCompanyAddressListByCompanyIDQueryHandler(ICompanyAddressManager companyAddressManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _companyAddressManager = companyAddressManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetCompanyAddressListByCompanyIDResponse>>> Handle(GetCompanyAddressListByCompanyIDQuery request, CancellationToken cancellationToken)
    {
        var companyAddressListDB = await _companyAddressManager.GetAllByCompanyID(request.ID).Include(x => x.Company).ToListAsync();
        if (companyAddressListDB is null)
        {
            return NotFound<List<GetCompanyAddressListByCompanyIDResponse>>();
        }
        var companyAddressListMapper = _mapper.Map<List<GetCompanyAddressListByCompanyIDResponse>>(companyAddressListDB);
        return Success(companyAddressListMapper);
    }
    #endregion

}
