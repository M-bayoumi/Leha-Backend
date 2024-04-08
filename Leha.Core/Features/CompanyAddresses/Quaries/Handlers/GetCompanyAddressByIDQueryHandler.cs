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


public class GetCompanyAddressByIdQueryHandler : ResponseHandler, IRequestHandler<GetCompanyAddressByIdQuery, Response<GetCompanyAddressByIdResponse>>
{
    #region Fields
    private readonly ICompanyAddressManager _companyAddressManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetCompanyAddressByIdQueryHandler(ICompanyAddressManager companyAddressManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _companyAddressManager = companyAddressManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetCompanyAddressByIdResponse>> Handle(GetCompanyAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var companyAddresstDB = await _companyAddressManager.GetAll().Include(x => x.Company).FirstOrDefaultAsync(x => x.ID == request.ID);

        if (companyAddresstDB is null)
        {
            return NotFound<GetCompanyAddressByIdResponse>();
        }
        var companyAddressMapper = _mapper.Map<GetCompanyAddressByIdResponse>(companyAddresstDB);
        return Success(companyAddressMapper);
    }
    #endregion

}
