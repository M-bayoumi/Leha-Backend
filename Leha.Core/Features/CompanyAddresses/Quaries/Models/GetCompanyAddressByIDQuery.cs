using Leha.Core.BaseResponse;
using Leha.Core.Features.CompanyAddresses.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.CompanyAddresses.Quaries.Models;

public class GetCompanyAddressByIdQuery : IRequest<Response<GetCompanyAddressByIdResponse>>
{
    public int ID { get; set; }

    public GetCompanyAddressByIdQuery(int clientID)
    {
        ID = clientID;
    }
    public GetCompanyAddressByIdQuery()
    {
    }
}
