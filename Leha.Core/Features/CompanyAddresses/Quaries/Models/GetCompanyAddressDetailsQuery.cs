using Leha.Core.BaseResponse;
using Leha.Core.Features.CompanyAddresses.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.CompanyAddresses.Quaries.Models;

public class GetCompanyAddressDetailsQuery : IRequest<Response<GetCompanyAddressDetailsResponse>>
{
    public int Id { get; set; }

    public GetCompanyAddressDetailsQuery(int clientID)
    {
        Id = clientID;
    }
    public GetCompanyAddressDetailsQuery()
    {
    }
}
