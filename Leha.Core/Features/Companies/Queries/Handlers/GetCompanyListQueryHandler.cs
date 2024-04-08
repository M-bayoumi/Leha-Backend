using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Companies.Queries.Models;
using Leha.Core.Features.Companies.Queries.Results;
using Leha.Core.Resources;
using Leha.Manager.Managers.Companies;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.Companies.Queries.Handlers;

public class GetCompanyListQueryHandler : ResponseHandler, IRequestHandler<GetCompanyListQuery, Response<List<GetCompanyListResponse>>>
{
    #region Fields
    private readonly ICompanyManager _companyManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetCompanyListQueryHandler(ICompanyManager companyManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _companyManager = companyManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetCompanyListResponse>>> Handle(GetCompanyListQuery request, CancellationToken cancellationToken)
    {
        var companyListDB = _companyManager.GetAll().ToList();
        var companyListMapper = _mapper.Map<List<GetCompanyListResponse>>(companyListDB);
        return Success(companyListMapper);
    }
    #endregion

}
