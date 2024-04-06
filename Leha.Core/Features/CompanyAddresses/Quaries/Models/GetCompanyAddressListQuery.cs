using Leha.Core.BaseResponse;
using Leha.Core.Features.CompanyAddresses.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.CompanyAddresses.Quaries.Models;

public class GetCompanyAddressListQuery : IRequest<Response<List<GetCompanyAddressListResponse>>>
{
}
