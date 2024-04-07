using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Companies.Queries.Models;
using Leha.Core.Features.Companies.Queries.Results;
using Leha.Core.Resources;
using Leha.Manager.Managers.Companies;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.Companies.Queries.Handlers;

public class GetCompanyByIDQueryHandler : ResponseHandler, IRequestHandler<GetCompanyByIDQuery, Response<GetCompanyByIDResponse>>
{
    #region Fields
    private readonly ICompanyManager _companyManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetCompanyByIDQueryHandler(ICompanyManager companyManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _companyManager = companyManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetCompanyByIDResponse>> Handle(GetCompanyByIDQuery request, CancellationToken cancellationToken)
    {
        var companyDB = await _companyManager.GetCompanyByIDAsync(request.ID);
        if (companyDB is null)
        {
            return NotFound<GetCompanyByIDResponse>();
        }
        var companyMapper = _mapper.Map<GetCompanyByIDResponse>(companyDB);
        return Success(companyMapper);
    }
    #endregion

}
