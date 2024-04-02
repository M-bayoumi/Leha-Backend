using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Companies.Queries.Models;
using Leha.Core.Features.Companies.Queries.Results;
using Leha.Manager.Managers.Companies;
using MediatR;

namespace Leha.Core.Features.Companies.Queries.Handlers;

public class GetCompanyListQueryHandler : ResponseHandler, IRequestHandler<GetCompanyListQuery, Response<List<GetCompanyListResponse>>>
{
    #region Fields
    private readonly ICompanyManager _companyService;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetCompanyListQueryHandler(ICompanyManager companyService, IMapper mapper)
    {
        _companyService = companyService;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetCompanyListResponse>>> Handle(GetCompanyListQuery request, CancellationToken cancellationToken)
    {
        var companyListDB = await _companyService.GetCompaniesListAsync();
        var companyListMapper = _mapper.Map<List<GetCompanyListResponse>>(companyListDB);
        return Success(companyListMapper);
    }
    #endregion

}
