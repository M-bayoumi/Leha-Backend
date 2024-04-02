using Leha.Core.BaseResponse;
using Leha.Core.Features.Companies.Queries.Results;
using MediatR;

namespace Leha.Core.Features.Companies.Queries.Models;

public class GetCompanyListQuery : IRequest<Response<List<GetCompanyListResponse>>>
{
}

