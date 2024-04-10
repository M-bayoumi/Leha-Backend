using Leha.Core.BaseResponse;
using Leha.Core.Features.CompanyAddresses.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.CompanyAddresses.Quaries.Models;

public class GetCompanyAddressByIdQuery : IRequest<Response<GetCompanyAddressByIdResponse>>
{
    public int Id { get; set; }

    public GetCompanyAddressByIdQuery(int clientID)
    {
        Id = clientID;
    }
    public GetCompanyAddressByIdQuery()
    {
    }
}
