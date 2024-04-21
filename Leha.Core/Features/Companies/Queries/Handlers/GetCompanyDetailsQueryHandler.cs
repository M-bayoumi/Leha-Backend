using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Companies.Queries.Models;
using Leha.Core.Features.Companies.Queries.Results;
using Leha.Core.Resources;
using Leha.Manager.Managers.Companies;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.Companies.Queries.Handlers;

public class GetCompanyDetailsQueryHandler : ResponseHandler, IRequestHandler<GetCompanyDetailsQuery, Response<GetCompanyDetailsResponse>>
{
    #region Fields
    private readonly ICompanyManager _companyManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetCompanyDetailsQueryHandler(ICompanyManager companyManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _companyManager = companyManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetCompanyDetailsResponse>> Handle(GetCompanyDetailsQuery request, CancellationToken cancellationToken)
    {
        var companyDB = await _companyManager.GetByIdAsync(request.Id);
        if (companyDB is null)
        {
            return NotFound<GetCompanyDetailsResponse>();
        }
        var companyMapper = _mapper.Map<GetCompanyDetailsResponse>(companyDB);
        return Success(companyMapper);
    }
    #endregion

}
