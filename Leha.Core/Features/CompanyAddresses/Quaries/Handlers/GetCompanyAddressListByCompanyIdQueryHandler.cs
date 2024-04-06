using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.CompanyAddresses.Quaries.Models;
using Leha.Core.Features.CompanyAddresses.Quaries.Results;
using Leha.Manager.Managers.CompanyAddresses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Leha.Core.Features.CompanyAddresses.Quaries.Handlers;

public class GetCompanyAddressListByCompanyIdQueryHandler : ResponseHandler, IRequestHandler<GetCompanyAddressListByCompanyIdQuery, Response<List<GetCompanyAddressListByCompanyIDResponse>>>
{
    #region Fields
    private readonly ICompanyAddressManager _companyAddressManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetCompanyAddressListByCompanyIdQueryHandler(ICompanyAddressManager companyAddressManager, IMapper mapper)
    {
        _companyAddressManager = companyAddressManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetCompanyAddressListByCompanyIDResponse>>> Handle(GetCompanyAddressListByCompanyIdQuery request, CancellationToken cancellationToken)
    {
        var companyAddressListDB = _companyAddressManager.GetCompanyAddressesListByCompanyId(request.ID).Include(x => x.Company).ToList();
        if (companyAddressListDB is null)
        {
            return NotFound<List<GetCompanyAddressListByCompanyIDResponse>>();
        }
        var companyAddressListMapper = _mapper.Map<List<GetCompanyAddressListByCompanyIDResponse>>(companyAddressListDB);
        return Success(companyAddressListMapper);
    }
    #endregion

}
